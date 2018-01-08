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
    }
}
