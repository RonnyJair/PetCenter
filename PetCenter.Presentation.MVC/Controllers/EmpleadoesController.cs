using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetCenter.Common.Core.Entities;
using PetCenter.Presentation.MVC.Models;
using PetCenter.Infrastucture.Domain.Main;

namespace PetCenter.Presentation.MVC.Controllers
{
    public class EmpleadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleadoes
        public ActionResult Index()
        {
            BL_Empleado BLEmpleado = new BL_Empleado();
            var empleadoes = BLEmpleado.ListarEmpleados();
            return View(empleadoes.ToList());
        }



        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            BL_Banco BLBanco = new BL_Banco();
            BL_Moneda BLMoneda = new BL_Moneda();
            BL_TipoCuenta BLTipoCuenta = new BL_TipoCuenta();
            BL_TipoDocumento BLTipoDocumento = new BL_TipoDocumento();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();

            ViewBag.BancoId = new SelectList(BLBanco.ListarEmpleadosActivos(), "BancoId", "Nombre");
            ViewBag.MonedaId = new SelectList(BLMoneda.ListarMoneda(), "MonedaId", "Nombre");
            ViewBag.TipoCuentaId = new SelectList(BLTipoCuenta.ListarTipoCuenta(), "TipoCuentaId", "Nombre");
            ViewBag.TipoDocumentoId = new SelectList(BLTipoDocumento.ListarTipoDocumento(), "TipoDocumentoId", "Nombre");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "Codigo");
           
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId,TipoDocumentoId,CodigoEmpleado,ApellidoPaterno,ApellidoMaterno,Nombres,FechaNacimiento,Sexo,Direccion,Telefono,Movil,Correo,TieneHijo,Documento,Habilitado,EsAfp,LugarNacimiento,CodigoEsSalud,UbigeoId,Referencia,BancoId,TipoCuentaId,NumeroCuenta,MonedaId,TipoRegimen,FechaIngreso,CUSSP,FechaInicioContrato,FechaFinContrato,EstadoCivil,xSueldoBase,xIngresos,xDescuento,xNeto,xAporte,xSueldoDiario,xSueldoHora,xFechaPago,XNombreCompleto")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                BL_Empleado BLEmpleado = new BL_Empleado();
                empleado.Habilitado = true;
                BLEmpleado.GuardarEmpleado(empleado);
                return RedirectToAction("Index");
            }

            BL_Banco BLBanco = new BL_Banco();
            BL_Moneda BLMoneda = new BL_Moneda();
            BL_TipoCuenta BLTipoCuenta = new BL_TipoCuenta();
            BL_TipoDocumento BLTipoDocumento = new BL_TipoDocumento();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();

            ViewBag.BancoId = new SelectList(BLBanco.ListarEmpleadosActivos(), "BancoId", "Nombre");
            ViewBag.MonedaId = new SelectList(BLMoneda.ListarMoneda(), "MonedaId", "Nombre");
            ViewBag.TipoCuentaId = new SelectList(BLTipoCuenta.ListarTipoCuenta(), "TipoCuentaId", "Nombre");
            ViewBag.TipoDocumentoId = new SelectList(BLTipoDocumento.ListarTipoDocumento(), "TipoDocumentoId", "Nombre");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "Codigo");

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Empleado BLEmpleado = new BL_Empleado();
            Empleado empleado = BLEmpleado.GetEmpleadoId((Int32)id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            BL_Banco BLBanco = new BL_Banco();
            BL_Moneda BLMoneda = new BL_Moneda();
            BL_TipoCuenta BLTipoCuenta = new BL_TipoCuenta();
            BL_TipoDocumento BLTipoDocumento = new BL_TipoDocumento();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();

            ViewBag.BancoId = new SelectList(BLBanco.ListarEmpleadosActivos(), "BancoId", "Nombre");
            ViewBag.MonedaId = new SelectList(BLMoneda.ListarMoneda(), "MonedaId", "Nombre");
            ViewBag.TipoCuentaId = new SelectList(BLTipoCuenta.ListarTipoCuenta(), "TipoCuentaId", "Nombre");
            ViewBag.TipoDocumentoId = new SelectList(BLTipoDocumento.ListarTipoDocumento(), "TipoDocumentoId", "Nombre");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "Codigo");

            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoId,TipoDocumentoId,CodigoEmpleado,ApellidoPaterno,ApellidoMaterno,Nombres,FechaNacimiento,Sexo,Direccion,Telefono,Movil,Correo,TieneHijo,Documento,Habilitado,EsAfp,LugarNacimiento,CodigoEsSalud,UbigeoId,Referencia,BancoId,TipoCuentaId,NumeroCuenta,MonedaId,TipoRegimen,FechaIngreso,CUSSP,FechaInicioContrato,FechaFinContrato,EstadoCivil,xSueldoBase,xIngresos,xDescuento,xNeto,xAporte,xSueldoDiario,xSueldoHora,xFechaPago,XNombreCompleto")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                BL_Empleado BLEmpleado = new BL_Empleado();
                BLEmpleado.GuardarEmpleado(empleado);
                return RedirectToAction("Index");
            }
            BL_Banco BLBanco = new BL_Banco();
            BL_Moneda BLMoneda = new BL_Moneda();
            BL_TipoCuenta BLTipoCuenta = new BL_TipoCuenta();
            BL_TipoDocumento BLTipoDocumento = new BL_TipoDocumento();
            BL_Ubigeo BLUbigeo = new BL_Ubigeo();

            ViewBag.BancoId = new SelectList(BLBanco.ListarEmpleadosActivos(), "BancoId", "Nombre");
            ViewBag.MonedaId = new SelectList(BLMoneda.ListarMoneda(), "MonedaId", "Nombre");
            ViewBag.TipoCuentaId = new SelectList(BLTipoCuenta.ListarTipoCuenta(), "TipoCuentaId", "Nombre");
            ViewBag.TipoDocumentoId = new SelectList(BLTipoDocumento.ListarTipoDocumento(), "TipoDocumentoId", "Nombre");
            ViewBag.UbigeoId = new SelectList(BLUbigeo.ListarUbigeo(), "UbigeoId", "Codigo");
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BL_Empleado BLEmpleado = new BL_Empleado();
            Empleado empleado = BLEmpleado.GetEmpleadoId((Int32)id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BL_Empleado BLEmpleado = new BL_Empleado();
            Empleado empleado = BLEmpleado.GetEmpleadoId((Int32)id);
            BLEmpleado.EliminarEmpleado(empleado);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
