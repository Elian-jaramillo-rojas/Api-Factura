using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMascota.Models.NewFolder
{
    public class cliente
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento_id { get; set; }

        public List<factura> listafactura { get; set; }
    }
}
