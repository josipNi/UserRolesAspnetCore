using System;
using System.Collections.Generic;
using System.Reflection;

namespace UserTable.Server.Models.Helpers
{
    public class Helpers<T>
    {
        public static Func<IEnumerable<T>, string, string> RoleNamesFn = (role_list, propertyName) =>
        {
            string result = string.Empty;
            long counter = 0;
            foreach (var item in role_list)
            {
                Type typeof_variable = item.GetType();
                dynamic variable_value = typeof_variable.GetProperty(propertyName).GetValue(item, null);

                if(typeof_variable != typeof(string))
                {
                    if (counter == 0)
                        result = string.Format("{0}", variable_value as string);
                    else
                        result += string.Format("|   {0}   ", variable_value as string);
                }               

                counter++;
            }
            return result;
        };
    }
}