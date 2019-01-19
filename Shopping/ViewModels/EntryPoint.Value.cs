using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Shopping.Controllers.Api;

namespace Shopping.ViewModels
{
    [HalActionLink(typeof(ValuesController), nameof(ValuesController.List), "ListValues")]
    [HalActionLink(typeof(ValuesController), nameof(ValuesController.Add), "AddValue")]
    public partial class EntryPoint
    {
        
    }
}