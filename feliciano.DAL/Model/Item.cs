using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feliciano.DAL.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedTime { get; set; }
        public int? PortfolioId { get; set; }
        public Portfolio portfolio { get; set; }
    }
}
