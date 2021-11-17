using apiMascota.Models;
using apiMascota.Models.NewFolder;
using apiMascota.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace apiMascota.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<cliente> getPersonas()
        {
            List<cliente> listacliente = new List<cliente>();
            List<factura> listafactura = new List<factura>();
            List<detallesFactura> listaDetallesFactura = new List<detallesFactura>();

            cliente cliente = new cliente();
            cliente.id = " ";
            cliente.nombre = "Elian";
            cliente.apellido = "jaramillo";
            cliente.documento_id = "1007603426";
            listacliente.Add(cliente);

            factura factura = new factura();
            factura.id = " ";
            factura.id_cliente = " ";
            listafactura.Add(factura);

            detallesFactura detallesFactura = new detallesFactura();
            
             detallesFactura.id = "";
             detallesFactura.id_factura = "";
             detallesFactura.descripcion = "";
             detallesFactura.valor = "";
             listaDetallesFactura.Add(detallesFactura);
            cliente.listafactura = listafactura;
            factura.listaDetallesFactura = listaDetallesFactura;
            return listacliente;
        }
        public string InsertarCliente(cliente model)
        {
            string sql = "BEGIN TRANSACTION; " + Environment.NewLine + Environment.NewLine;
            sql += "INSERT INTO usuarios VALUES(" + model.nombre + ", '" + model.apellido + "','" + model.documento_id + "')" + Environment.NewLine;
            string result = cmd.ExeccuteQuery(sql);
            return result;
        }
        public string InsertarFactura(factura model)
        {

            string sql = "BEGIN TRANSACTION; " + Environment.NewLine + Environment.NewLine;
            sql+="INSERT INTO invoice(id_client,cod) VALUES(" + model.id_cliente + ",'" + model.cod + "');" + Environment.NewLine;
            sql += "" + Environment.NewLine;
            sql += "declare @id_factura int;" + Environment.NewLine;
            sql += "set @id_factura = SCOPE_IDENTIFY();" + Environment.NewLine;
            sql += "" + Environment.NewLine;
            sql += "" + Environment.NewLine;
            foreach(detallesFactura item in model.listaDetallesFactura)
            {
                sql+="INSERT INTO invoice_datail (id_invoice,[description],[value]) VALUES(@id_invoice,'" + item.descripcion + "','" + item.valor + "') ";
            }
            sql += "" + Environment.NewLine;
            sql += "" + Environment.NewLine;
            sql += "COMMIT;";
            string result = cmd.ExecuteQuery(sql);
            return result;
        }
        public List<cliente> insertarLista([FromBody] List<cliente> listacliente)
        {
            return listacliente;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
