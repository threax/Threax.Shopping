using Halcyon.HAL.Attributes;
using Shopping.Controllers.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.UserBuilder.Entities.Mvc;

namespace Shopping
{
    /// <summary>
    /// This class makes it easy to keep track of role constants throught the system.
    /// </summary>
    public static class Roles
    {
        /// <summary>
        /// A default role to edit values, you will probably want to replace this role.
        /// </summary>
        public const String EditStores = nameof(EditStores);

        /// <summary>
        /// All roles, any roles added above that you want to add to the database should be defined here.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<String> DatabaseRoles()
        {
            yield return EditStores;
        }
    }

    [HalModel]
    [HalSelfActionLink(RolesControllerRels.GetUser, typeof(RolesController))]
    [HalActionLink(RolesControllerRels.SetUser, typeof(RolesController))]
    [HalActionLink(CrudRels.Update, RolesControllerRels.SetUser, typeof(RolesController))]
    [HalActionLink(CrudRels.Delete, RolesControllerRels.DeleteUser, typeof(RolesController))]
    public class RoleAssignments : ReflectedRoleAssignments
    {
        public bool EditStores { get; set; }
    }
}
