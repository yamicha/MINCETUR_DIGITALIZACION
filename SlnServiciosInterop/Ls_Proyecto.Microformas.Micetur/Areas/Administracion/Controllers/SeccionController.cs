using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ls_Proyecto.Microformas.Micetur.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Route("[controller]")]
    public class SeccionController : Controller
    {
        // GET: SeccionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SeccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeccionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeccionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeccionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
