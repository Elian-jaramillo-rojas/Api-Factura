using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMascota.Models.Entities
{
    public class detallesFactura
    {

        public string id { get; set; }
        public string id_factura { get; set; }
        public string descripcion { get; set; }
        public string valor { get; set; }
    }
}
