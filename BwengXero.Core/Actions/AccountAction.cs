using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;
using Xero.Api.Example.Applications.Public;

namespace BwengXero.Core.Actions
{
    public class AccountAction
    {
        /// <summary>
        ///     Get all accounts
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Account> GetAllAccounts()
        {
            try
            {
                var accounts = XeroApiHelper.CoreApi()
                    .Accounts
                    .Find()
                    .ToList();

                return accounts;
            }
            catch (Exception)
            {
                throw new RenewTokenException();
            }
        }
    }
}