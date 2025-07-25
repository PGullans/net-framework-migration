using Ok.Framework.Db.Model;
using Ok.Framework.Db.Repository;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ok.Net.Web.Services
{
    public class ContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IQueryable<Contact> GetAll()
        {
            return _contactRepository.GetAllAsNoTracking();
        }

        public Contact GetById(Guid contactId)
        {
            return _contactRepository.GetById(contactId);
        }
    }
}