using Ok.Framework.Db.Model;
using Ok.Framework.Db.Repository;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ok.Net.Web.Services
{
    public class AccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IQueryable<Account> GetAll()
        {
            return _accountRepository.GetAllAsNoTracking();
        }

        public Account GetById(Guid accountId)
        {
            return _accountRepository.GetById(accountId);
        }
    }
}