using System;
using System.IO;
using System.Reflection;

namespace Walker
{
    static class Help
    {
        public static void WriteTo(TextWriter writer)
        {
            Stream helpFile = GetFirstEmbeddedResource(Assembly.GetExecutingAssembly());
            using (TextReader reader = new StreamReader(helpFile))
            {
                writer.Write(reader.ReadToEnd());
            }
        }

        static Stream GetFirstEmbeddedResource(Assembly a)
        {
            string[] list = a.GetManifestResourceNames();
            return a.GetManifestResourceStream(list[0]);
        }
    }
}
