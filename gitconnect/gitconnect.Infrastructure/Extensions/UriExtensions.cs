using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Extensions
{
    public static class UriExtensions
    {
        public static Uri Append(this Uri uri, Uri uriToAppend)
        {
            return new Uri(uri, uriToAppend);
        }

        public static Uri Append(this Uri uri, string pathToAppend)
        {
            return Append(uri, new Uri(pathToAppend, UriKind.Relative));
        }
    }
}
