using System;
using System.Data;

namespace Common
{
    public class SqlParameterAttribute : Attribute
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public DbType DbType { get; set; }
        public bool IsOutput { get; set; }
    }
}
