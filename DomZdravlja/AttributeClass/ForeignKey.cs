using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKey : Attribute
    {
        public string ReferencedTable { get; set; }
        public string ReferencedColumn { get; set; }
        public Tip Tip { get; set; }

        public ForeignKey(string referencedTable, string referencedColumn)
        {
            this.ReferencedTable = referencedTable;
            this.ReferencedColumn = referencedColumn;
        }

        public ForeignKey(string referencedTable, string referencedColumn, Tip tip)
        {
            this.ReferencedTable = referencedTable;
            this.ReferencedColumn = referencedColumn;
            Tip = tip;
        }

    }
}
