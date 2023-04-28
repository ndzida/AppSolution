using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;

namespace Common.SqlServerManagement
{
    public class SqlServerHelpers
    {
        static Dictionary<SqlDataType, string> typeAlias = new Dictionary<SqlDataType, string>
        {
            { SqlDataType.Bit, "bool" },
            { SqlDataType.Binary, "byte[]" },
            { SqlDataType.VarBinary, "byte[]" },
            { SqlDataType.Char, "char" },
            { SqlDataType.Decimal, "decimal" },
            { SqlDataType.Float, "double" },
            { SqlDataType.Real, "float" },
            { SqlDataType.Int, "int" },
            { SqlDataType.BigInt, "long" },
            { SqlDataType.Date, "DateTime" },
            { SqlDataType.DateTime, "DateTime" },
            { SqlDataType.DateTime2, "DateTime" },
            { SqlDataType.SmallInt, "short" },
            { SqlDataType.TinyInt, "short" },
            { SqlDataType.VarChar, "string" },
            { SqlDataType.NVarChar, "string" },
        };

        public static string GetTypeAlias(Column column)
        {
            SqlDataType type = column.DataType.SqlDataType;
            string alias = "";
            if (typeAlias.TryGetValue(type, out alias))
            {
                if (column.Nullable &&
                    column.DataType.SqlDataType != SqlDataType.VarChar &&
                    column.DataType.SqlDataType != SqlDataType.NVarChar)
                {
                    alias = alias + "?";
                }
            }
            return alias;
        }
    }
}
