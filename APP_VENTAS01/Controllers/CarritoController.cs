using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_VENTAS01.Models;
namespace APP_VENTAS01.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito

        CARRITODBEntities db = new CARRITODBEntities();

        public int getIndice(int id)
        {
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Producto.ID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult AgregarCarrito(int id)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> lista = new List<CarritoItem>();
                lista.Add(new CarritoItem(db.PRODUCTO.Find(id), 1));
                Session["carrito"] = lista;
            }
            else
            {
                List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
                int indice = getIndice(id);
                if (indice == -1)
                {
                    lista.Add(new CarritoItem(db.PRODUCTO.Find(id), 1));
                }
                else
                {
                    lista[indice].Cantidad++;
                }
                Session["carrito"] = lista;

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            lista.RemoveAt(getIndice(id));
            return View("AgregarCarrito");

        }

        public ActionResult FinalizarCompra()
        {
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            if (lista != null && lista.Count > 0)
            {
                VENTA nuevaVenta = new VENTA();
                nuevaVenta.DIA_VENTA = DateTime.Now;
                nuevaVenta.SUBTOTAL = lista.Sum(x => x.Producto.PRECIO * x.Cantidad);
                nuevaVenta.IVA = nuevaVenta.SUBTOTAL * 0.18;
                nuevaVenta.TOTAL = nuevaVenta.SUBTOTAL + nuevaVenta.IVA;

                nuevaVenta.ListaVenta = (from PRODUCTO in lista
                                         select new ListaVenta
                                         {
                                             PRODUCTO_ID = PRODUCTO.Producto.ID,
                                             CANTIDAD = PRODUCTO.Cantidad,
                                             TOTAL = PRODUCTO.Cantidad * PRODUCTO.Producto.PRECIO
                                         }).ToList();
                db.VENTA.Add(nuevaVenta);
                db.SaveChanges();
                Session["carrito"] = new List<CarritoItem>();
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}