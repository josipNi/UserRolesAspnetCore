using System;
using System.Collections.Generic;
using System.Reflection;

namespace UserTable.Server.Models.Helpers
{
    public class Helpers<T>
    {
        public static Func<IEnumerable<T>, string, string> RoleNamesFn = (role_list, propertyName) =>
        {
            try
            {
                string result = string.Empty;
                long counter = 0;
                foreach (var item in role_list)
                {
                    dynamic variable_value = item.GetType().GetProperty(propertyName).GetValue(item, null);
                   
                    if (counter == 0)
                        result = string.Format("{0}", variable_value as string);
                    else
                        result += string.Format("|   {0}   ", variable_value as string);

                    counter++;
                }
                return result;
            }
            catch
            {
                return null;
            }
        };
    }
}