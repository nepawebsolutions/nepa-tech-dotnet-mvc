using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NEPATechDotnetCoreMVC.Constants
{
    public class RoleConstants
    {
        public static IEnumerable<string> GetAllRoles()
        {
            return typeof(RoleConstants).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(field => field.FieldType == typeof(string))
                .Select(field => (string)field.GetValue(null));
        }

        public static readonly string Webmaster = "Webmaster";
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";
    }
}
