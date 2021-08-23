using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Departaments
    {       
        [Key]
        public int DepartamentsId { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<City> Cities { get; set; }
        //public virtual ICollection<Company> Company { get; set; }
        //public virtual ICollection<WareHouse> WareHouse { get; set; }
        //public virtual ICollection<Customer> Customer { get; set; }
    }
}