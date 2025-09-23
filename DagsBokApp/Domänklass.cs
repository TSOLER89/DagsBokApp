using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagsBokApp
{
    public class DiaryEntry
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }

     public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Text}";
        }
    }
}
