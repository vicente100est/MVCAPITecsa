using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPITecsa.Models
{
    public class Working
    {
        public int Id_Work { get; set; }
        public string Title_Work { get; set; }
        public string Description_Work { get; set; }
        public string Status_Work { get; set; }
        public int Id_Rol { get; set; }
    }
}
