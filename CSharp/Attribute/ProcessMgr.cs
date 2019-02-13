using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TFW
{
    public partial class ProcessMgr
    {


        public class PreProcessAttribute : Attribute
        {
        }

        public class PostProcessAttribute : Attribute
        {
        }

        public static void PreProcess()
        {
            try
            {
                CallAllMethodWithAttribute(typeof(PreProcessAttribute));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void PostProcess()
        {
            try
            {
                CallAllMethodWithAttribute(typeof(PostProcessAttribute));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void CallAllMethodWithAttribute(Type attributeType, params object[] param)
        {
            List<Type> types = new List<Type>()
            {
                typeof(ProcessMgr)
            };

            foreach (var method in (
                from type in types
                from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                where method.IsDefined(attributeType,false)
                select method))
            {
                method.Invoke(null, param);
            }

        }

    }
}
