using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string source)
        {
            source = source ?? "";
            if (!String.IsNullOrEmpty(source))
            {
                if (Char.IsLower(source[0]))
                    source = Char.ToUpper(source[0]) +
                            source.Substring(1);
            };
            return source;
        }
    }
}
