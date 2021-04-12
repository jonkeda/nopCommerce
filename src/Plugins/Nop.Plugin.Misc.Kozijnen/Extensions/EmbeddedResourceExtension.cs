using System;
using System.IO;

namespace Nop.Plugin.Misc.Kozijnen.Extensions
{
    public static class EmbeddedResourceExtension
    {
        public static string GetNamespace(this Type type)
        {
            var space = type.FullName;
            var index = space.LastIndexOf('.');
            return space.Substring(0, index);
        }

        public static string Combine(this Type type, string name)
        {
            return $"{type.GetNamespace()}.{name}";
        }

        public static Stream GetStream(this Type type, string name)
        {
            return type.Assembly.GetManifestResourceStream( Combine(type, name));
        }

        public static bool ResourceExists(this Type type, string name)
        {
            return type.Assembly.GetManifestResourceInfo(Combine(type, name)) != null;
        }

        public static string ResourceAsString(this Type type, string name)
        {
            using (var stream = GetStream(type, name))
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
        
        public static byte[] ResourceAsBytes(this Type type, string name)
        {
            using (var stream = GetStream(type, name))
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
