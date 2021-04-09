using System;
using System.IO;

namespace Nop.Plugin.Misc.Settings.Extensions
{
    public static class EmbeddedResourceExtension
    {
        public static string GetNamespace(this Type type)
        {
            var space = type.FullName;
            var index = space.LastIndexOf('.');
            return space.Substring(0, index);
        }

        public static string Combine(this Type type, string fullname)
        {
            return $"{type.GetNamespace()}.{fullname}";
        }

        public static Stream GetStream(this Type type, string name)
        {
            return type.Assembly.GetManifestResourceStream( Combine(type, name));
        }

        public static string ReadAsString(this Type type, string fullname)
        {
            using (var stream = GetStream(type, fullname))
            {
                if (stream == null)
                {
                    return null;
                }
                using(var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        
        public static byte[] ReadAsBytes(this Type type, string fullname)
        {
            //string fullname = $"Nop.Plugin.Misc.Settings.Images.Vouwwanden.{name}";
            using (var stream = GetStream(type, fullname))
            {
                if (stream == null)
                {
                    return Array.Empty<byte>();
                }
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
