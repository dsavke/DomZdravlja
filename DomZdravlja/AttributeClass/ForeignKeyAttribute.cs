using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public string referencedTable;
        public string referencedColumn;

        public ForeignKeyAttribute(string referencedTable, string referencedColumn)
        {
            this.referencedTable = referencedTable;
            this.referencedColumn = referencedColumn;
        }
    }
}
