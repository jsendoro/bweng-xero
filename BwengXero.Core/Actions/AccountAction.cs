using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;

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
            var accounts = XeroApiHelper.CoreApi()
                .Accounts
                .Find()
                .ToList();

            return accounts;
        }
    }
}