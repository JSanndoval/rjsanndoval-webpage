using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJS_WS.Entities.Input
{
    public class IN_Access
    {
        //Constructor por defecto
        public IN_Access() { }


        //Propiedades de la clase IN_Access
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
