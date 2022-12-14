using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagementSystemSK.Models;

namespace UserManagementSystemSK.Controllers
{
    public class RegisteredUsersController : Controller
    {
        // GET: RegisteredUsers
        public ActionResult Index()
        {
            using (training_dbEntities dbmodel = new training_dbEntities())
            {
                return View(dbmodel.users_sk.ToList());
            }
        }

        // GET: RegisteredUsers/Details/5
        public ActionResult Details(int id)
        {
            using (training_dbEntities dbModel = new training_dbEntities())
            {
                return View(dbModel.users_sk.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // GET: RegisteredUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisteredUsers/Create
        [HttpPost]
        public ActionResult Create(users_sk customer)
        {
            try
            {
                using (training_dbEntities dbModel = new training_dbEntities())
                {
                    dbModel.users_sk.Add(customer);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insertion/Edit/5
        public ActionResult Edit(int id)
        {
            using (training_dbEntities dbModel = new training_dbEntities())
            {
                return View(dbModel.users_sk.Where(x => x.UserID == id).FirstOrDefault());
            }

        }

        // POST: Insertion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, users_sk customer)
        {
            try
            {
                using (training_dbEntities dbModel = new training_dbEntities())
                {
                    dbModel.Entry(customer).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insertion/Delete/5
        public ActionResult Delete(int id)
        {
            using (training_dbEntities dbModel = new training_dbEntities())
            {
                return View(dbModel.users_sk.Where(x => x.UserID == id).FirstOrDefault());
            }
        }

        // POST: Insertion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (training_dbEntities dbModel = new training_dbEntities())
                {
                    users_sk customer = dbModel.users_sk.Where(x => x.UserID == id).FirstOrDefault();
                    dbModel.users_sk.Remove(customer);
                    dbModel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
