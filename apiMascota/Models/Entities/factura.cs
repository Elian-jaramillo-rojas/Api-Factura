using apiMascota.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiMascota.Models.NewFolder
{
    public class factura
    {
        public  string id { get; set; }
        public  string id_cliente { get; set; }
        public  string cod { get; set; }
        public List<detallesFactura> listaDetallesFactura { get; internal set; }
    }
}
