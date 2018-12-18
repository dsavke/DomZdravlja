using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MainSearch:Attribute
    {

        object Vrijednost { get; set; }

        public MainSearch(string vrijednost)
        {
            Vrijednost = vrijednost;
        }

        public MainSearch(int vrijednost)
        {
            Vrijednost = vrijednost;
        }

        public MainSearch(DateTime vrijednost)
        {
            Vrijednost = vrijednost;
        }

    }
}
