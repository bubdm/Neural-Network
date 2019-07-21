using Dots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Randomize
{
    static class RandomizeMode
    {
        public static void Simple(NetworkDataModel N)
        {

        }
    }

    static class Helper
    {
        public static MethodInfo[] GetRandomizers()
        {
            return typeof(RandomizeMode).GetMethods().Where(r => r.IsStatic).ToArray();
        }

        public static void Invoke(string name, NetworkDataModel N)
        {
            MethodInfo method = typeof(RandomizeMode).GetMethod(name);
            method.Invoke(null, new object[] { N });
        }
    }
}
