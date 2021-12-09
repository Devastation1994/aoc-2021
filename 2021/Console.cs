using System;
using System.Linq;
using System.Reflection;

namespace Year2021
{
    class Console
    {
        static void Main(string[] args)
        {
            var days = Assembly.GetExecutingAssembly().GetTypes().Where(i => i.Name.StartsWith("Day")).Last();

            days.GetMethod("Run").Invoke(Activator.CreateInstance(days), null);
        }
    }
}
