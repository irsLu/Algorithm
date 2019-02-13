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
        [PreProcess]
        public static void PreProcessOne()
        {
            Console.WriteLine("pre deal~");
        }

    }
}