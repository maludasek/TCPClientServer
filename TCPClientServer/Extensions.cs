using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientServer
{
    public static class Extensions
    {
        public static MemoryStream Append(this MemoryStream destination, MemoryStream source)
        {
            var pos = destination.Length;
            destination.SetLength(destination.Length + source.Length);
            destination.Position = pos;
            source.CopyTo(destination);

            return destination;
        }

        public static T[] Concatenate<T>(this T[] array1, T[] array2)
        {
            T[] result = new T[array1.Length + array2.Length];
            array1.CopyTo(result, 0);
            array2.CopyTo(result, array1.Length);
            return result;
        }
    }
}
