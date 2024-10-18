using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feliciano.DAL.Model
{
    public class Portfolio
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }   
        public ICollection<Item> Items { get; set; }
    }
}
