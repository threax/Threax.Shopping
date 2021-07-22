import * as client from 'Client/Libs/ServiceClient';
import * as hyperCrud from 'htmlrapier.widgets/src/HypermediaCrudService';
import * as di from 'htmlrapier/src/di';

export class StoreCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listStores(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListStores();
    }

    public getDeletePrompt(item: client.StoreResult): string {
        return "Are you sure you want to delete the store?";
    }

    public getItemId(item: client.StoreResult): string | null {
        return String(item.data.storeId);
    }

    public createIdQuery(id: string): client.StoreQuery | null {
        return {
            storeId: id
        };
    }
}