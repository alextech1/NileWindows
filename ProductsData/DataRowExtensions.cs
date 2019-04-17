using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject2.Data
{
    public static class DataRowExtensions
    {
        public static IEnumerable<DataRow> RowsAsEnumerable(this DataTable source)
        {
            if (source == null)
                return Enumerable.Empty<DataRow>();

            return source.Rows.OfType<DataRow>();
        }
    }
}
