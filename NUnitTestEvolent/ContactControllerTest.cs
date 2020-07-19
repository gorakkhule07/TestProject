using EvolentHelathTestApi;
using EvolentHelathTestApi.Controllers;
using NUnit.Framework;

namespace NUnitTestEvolent
{
    public class ContactControllerTest
    {
        ContactController contactController = null;

        [SetUp]
        public void Setup()
        {
           
            contactController = new ContactController(new ContactDataAccess());
        }
        [Test, Order(1)]
        public void SaveContact_retursSuccessOrDuplicateFlag()
        {
            ContactEntity contact = new ContactEntity
            {
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "9569856699",
                Status = "Active",
                Email = "TestEmail@gmail.com",
            };

            string Result = contactController.AddContact(contact);
            Assert.AreNotEqual("failed", Result.ToLower());
            Assert.AreNotEqual("", Result);
            Assert.AreNotEqual(null, Result);

        }

        [Test, Order(2)]
        public void GetAllContact_retursListofAllContacts()
        {

            var Result = contactController.GetAllContact();
            Assert.AreNotEqual(null, Result);
            Assert.AreNotEqual(0, Result.Count);

        }


        [Test, Order(3)]
        public void GetContactById_retursContacts()
        {
            var result = contactController.GetAllContact();
            if (result != null && result.Count > 0)
            {
                int id = result[0].Id;
                ContactEntity ResultByID = contactController.GetContactById(id);
                Assert.AreNotEqual(null, ResultByID);
            }
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [Test, Order(4)]
        public void UpdateContactById_retursSuccessFlag()
        {
            var result = contactController.GetAllContact();
            if (result != null && result.Count > 0)
            {
                ContactEntity contact = new ContactEntity()
                {
                    Email = "gorakkhuleTestuni@gmail.com",
                    FirstName = "UpdateFirstName",
                    LastName = "UpdateLastName",
                    Status = "Active",
                    PhoneNumber = "1234567890",
                    Id = result[0].Id
                }
                ;
                string UpdateResult = contactController.UpdateContact(contact);
                Assert.AreNotEqual("failed", UpdateResult.ToLower());
                Assert.AreNotEqual("", UpdateResult);
                Assert.AreNotEqual(null, UpdateResult);
            }
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [Test, Order(5)]
        public void DeleteContactById_retursSuccessFlag()
        {
            var result = contactController.GetAllContact();
            if (result != null && result.Count > 0)
            {
                int id = result[0].Id;
                string DeleteResult = contactController.DeleteContact(id);
                Assert.AreNotEqual("failed", DeleteResult.ToLower());
            }
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }


    }
}
