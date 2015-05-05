using System.Collections.Generic;

namespace SqliteDb_FluentNhibernate.Models.Repositories
{
    public interface IContactsRepositories
    {
        IEnumerable<Contacts> GetAll();

        Contacts Get(int id);

        bool Post(Contacts contact);

        bool Delete(int id);

        bool Update(Contacts contact);
    }
}