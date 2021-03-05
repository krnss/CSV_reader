using CsvHelper;
using CVS_data_reader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVS_data_reader.Controllers
{
    public class HomeController : Controller
    {
        PersonContext db = new PersonContext();
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = upload.FileName;

                upload.SaveAs(Server.MapPath("~/Files/" + fileName));

                using (var reader = new StreamReader(Server.MapPath("~/Files/" + fileName)))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Person>();

                    foreach (var item in records)
                    {
                        db.Persons.Add(item);
                    }
                    db.SaveChanges();
                }
            }

            return View(db.Persons.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Person person = db.Persons.Find(id);
            if (person != null)
            {
                return View(person);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Person b = db.Persons.Find(id);
            if (b != null)
            {
                db.Persons.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }    
    }
}