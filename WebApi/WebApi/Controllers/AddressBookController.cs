using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Data.Entity;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    public class AddressBookController : ApiController
    {
        DBEntities db = new DBEntities();

        //Add Post request
        public string Post(AddressBook addressBook)
        { 
            db.AddressBooks.Add(addressBook);
            db.SaveChanges();
            return "Address added";
        }

        //Get all records
        public IEnumerable<AddressBook> GET()
        { 
            return db.AddressBooks.ToList();
        }

        //Get single record
        [ResponseType(typeof(AddressBook))]
        public IHttpActionResult Get(int id)
        { 
            AddressBook addressBook = db.AddressBooks.Find(id);
            if (addressBook == null)
            {
                return NotFound();
            }
            return Ok(addressBook);
        }

        //update the record
        public IHttpActionResult Put(int id, AddressBook addressBook)
        {
            if (id != addressBook.Id)
            {
                return BadRequest();
            }

            var address_ = db.AddressBooks.Find(id);
            address_.FirstName = addressBook.FirstName;
            address_.Surname = addressBook.Surname;
            address_.Age = addressBook.Age;
            address_.Birthday = addressBook.Birthday;
            address_.Tel = addressBook.Tel;
            address_.Address = addressBook.Address;

            db.Entry(address_).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(address_);
        }

        //Delete the record
        [ResponseType(typeof(AddressBook))]
        public IHttpActionResult Delete(int id)
        {
            AddressBook addressBook = db.AddressBooks.Find(id);
            if (addressBook == null)
            {
                return NotFound();
            }

            db.AddressBooks.Remove(addressBook);
            db.SaveChanges();
            return Ok(addressBook);
        }
    }
}
