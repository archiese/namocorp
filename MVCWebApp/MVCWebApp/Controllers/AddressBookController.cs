using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class AddressBookController : Controller
    {
        // GET: AddressBook
        public ActionResult Index()
        {
            IEnumerable<AddressBook> addressBooksList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("AddressBook").Result;
            addressBooksList = response.Content.ReadAsAsync<IEnumerable<AddressBook>>().Result;
            return View(addressBooksList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new AddressBook());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("AddressBook/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<AddressBook>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(AddressBook AddressBook)
        {
            if (AddressBook.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("AddressBook", AddressBook).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("AddressBook/" + AddressBook.Id, AddressBook).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("AddressBook/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}