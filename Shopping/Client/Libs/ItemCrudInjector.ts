import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class ItemCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listItems(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListItems();
    }

    public getDeletePrompt(item: client.ItemResult): string {
        return "Delete " + item.data.description + "?";
    }

    public getItemId(item: client.ItemResult): string | null {
        return String(item.data.itemId);
    }

    public createIdQuery(id: string): client.ItemQuery | null {
        return {
            itemId: id
        };
    }

    public async getSearchSchema() {
        const entry = await this.injector.load();
        const schema = await entry.getListItemsDocs({ includeRequest: true, includeResponse: false });
        return schema.requestSchema;
    }
}