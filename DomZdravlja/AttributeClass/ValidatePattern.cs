using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomZdravlja.AttributeClass
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidatePattern:ValidationAttribute
    {

        public Regex Regex { get; set; }

        public ValidatePattern(string pattern)
        {
            Regex = new Regex(pattern);
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString().Trim());
        }
    }
}
