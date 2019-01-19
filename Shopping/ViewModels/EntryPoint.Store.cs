using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Shopping.Controllers.Api;

namespace Shopping.ViewModels
{
    [HalActionLink(typeof(StoresController), nameof(StoresController.List), "ListStores")]
    [HalActionLink(typeof(StoresController), nameof(StoresController.Add), "AddStore")]
    public partial class EntryPoint
    {
        
    }
}