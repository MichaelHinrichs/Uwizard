using System;
using System.Reflection;

namespace Uwizard.Entities.Helpers
{
    public static class AssemblyHelper
    {
        public static string GetProductVersionString()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        }

        public static Version GetProductVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
