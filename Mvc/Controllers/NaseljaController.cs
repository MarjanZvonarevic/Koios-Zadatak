using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class NaseljaController : Controller
    {
        // GET: Naselja
        public ActionResult Index()
        {
            IEnumerable<mvcNaseljaModel> nasList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Naselja").Result;
            nasList = response.Content.ReadAsAsync<IEnumerable<mvcNaseljaModel>>().Result;
            return View(nasList);
        }

        //Http GET
        public ActionResult AddEdit(int id = 0)
        {
            if (id==0)
            return View(new mvcNaseljaModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Naselja/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcNaseljaModel>().Result);
            }
        }

        //Http POST
        [HttpPost]
        public ActionResult AddEdit(mvcNaseljaModel nas)
        {
            if(nas.NaseljeId == 0) 
            { 
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Naselja", nas).Result;
                TempData["SuccessMessage"] = "Uspješno snimljeno";
                
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Naselja/"+nas.NaseljeId, nas).Result;
                TempData["SuccessMessage"] = "Uspješno ažurirano";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Naselja/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Uspješno izbrisano";
            return RedirectToAction("Index");
        }
    }
}