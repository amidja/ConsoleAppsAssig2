using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Threading.Tasks;

namespace Assig2Task3
{
    class CarUtil
    {
        public static PropertyInfo[] GetProperties()
        {
            // get all public properties for the Car type
            PropertyInfo[] propertyInfos;
            
            propertyInfos = typeof(Car).GetProperties(BindingFlags.SetProperty |
                        BindingFlags.Public |
                        BindingFlags.Instance);

            ArrayList list = new ArrayList();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetSetMethod() != null)
                {
                    list.Add(propertyInfo);
                }
            }
            return list.ToArray(typeof(PropertyInfo)) as PropertyInfo[];
        }
    }
}