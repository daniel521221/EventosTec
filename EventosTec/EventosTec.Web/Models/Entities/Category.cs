using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventosTec.Web.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Categoria")]
        public string Name { get; set; }
        [Display(Name="Descripcion")]
        public string Description { get; set; }

        public ICollection<Event> Events { get; set; }



    }
}
