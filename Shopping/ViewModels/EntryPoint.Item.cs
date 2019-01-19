using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Shopping.Controllers.Api;

namespace Shopping.ViewModels
{
    [HalActionLink(typeof(ItemsController), nameof(ItemsController.List), "ListItems")]
    [HalActionLink(typeof(ItemsController), nameof(ItemsController.Add), "AddItem")]
    public partial class EntryPoint
    {
        
    }
}