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
        [PostProcess]
        public static void PostProcessOne()
        {
            Console.WriteLine("post deal~");
        }

    }
}