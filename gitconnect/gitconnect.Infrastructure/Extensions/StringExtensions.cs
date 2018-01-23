using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private static Uri ToUri(string path, UriKind kind)
        {
            return new Uri(path, kind);
        }

        public static Uri ToUri(this string path)
        {
            return ToUri(path, UriKind.Absolute);
        }

        public static Uri ToRelativeUri(this string path)
        {
            return ToUri(path, UriKind.Relative);
        }
    }
}
