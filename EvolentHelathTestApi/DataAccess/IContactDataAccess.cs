using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHelathTestApi
{
    public interface IContactDataAccess
    {
        int SaveContact(ContactEntity contactEntity);

        int UpdateContact(ContactEntity contactEntity);

        List<ContactEntity> GetAllContact();

       ContactEntity GetContactById(int  Id);

        int DeleteContactByid(int Id);

        int CheckDuplicateEmail(int Id, string Email);
        
    }
}
