using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Models
{
    public class ToDo
    {
       public int Id { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public int Iscompleted { get; set;}
        public int Status { get; set; }
    }
}
