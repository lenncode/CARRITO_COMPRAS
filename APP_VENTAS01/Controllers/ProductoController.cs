using APP_VENTAS01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_VENTAS01.Controllers
{
    public class ProductoController : Controller
    {
        private CARRITODBEntities db = new CARRITODBEntities();

        // GET: Producto
        public ActionResult Index()
        {

            return View(db.PRODUCTO.ToList().OrderBy(x=>x.NOMBRE));
        }
    }
}