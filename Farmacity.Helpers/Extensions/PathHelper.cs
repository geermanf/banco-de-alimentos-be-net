using System;
using System.IO;

namespace Farmacity.Helpers.Extensions
{
    public static class PathHelper
    {
        public static string GetCommentsFileForAssemblyOf<T>()
        {
            var baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            var fileName = typeof(T).Assembly.GetName().Name + ".XML";
            var path = Path.Combine(baseDirectory, fileName);

            return path;
        }

    }
}
