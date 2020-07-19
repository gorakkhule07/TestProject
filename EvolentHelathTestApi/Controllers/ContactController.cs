using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvolentHelathTestApi.Controllers
{
    [Produces("application/json")]
    public class ContactController : Controller
    {
        IContactDataAccess contactobj;
        public ContactController(IContactDataAccess contactobj)
        {
            this.contactobj = contactobj;
        }

        [Route("api/Contact/SaveContact")]
        [HttpPost]
        public string AddContact([FromBody]ContactEntity contact)
        {
            if (contactobj.CheckDuplicateEmail(contact.Id, contact.Email) == 0)
            {
                int status = contactobj.SaveContact(contact);
                string result = status == 1 ? "Success" : "Failed";

                return result;
            }
            else
            {
                return "DuplicateEmail";
            }
        }

        [Route("api/Contact/UpdateContact")]
        [HttpPut]
        public string UpdateContact([FromBody]ContactEntity contact)
        {
            if (contactobj.CheckDuplicateEmail(contact.Id, contact.Email) == 0)
            {
                int status = contactobj.UpdateContact(contact);
                string result = status == 1 ? "Success" : "Failed";

                return result;
            }
            else
            {
                return "DuplicateEmail";
            }
        }

        [Route("api/Contact/GetAllContact")]
        [HttpGet]
        public List<ContactEntity> GetAllContact()
        {
            List<ContactEntity> lstContact = contactobj.GetAllContact();
            return lstContact;
        }

        [Route("api/Contact/DeleteContact")]
        [HttpDelete]
        public string DeleteContact(int Id)
        {


            int ResultStatus = contactobj.DeleteContactByid(Id);
            return ResultStatus == 1 ? "Success" : "Failed";


        }

        [Route("api/Contact/GetContactById")]
        [HttpGet]
        public ContactEntity GetContactById(int Id)
        {
            ContactEntity contactEntiry = contactobj.GetContactById(Id);
            return contactEntiry;
        }

    }
}