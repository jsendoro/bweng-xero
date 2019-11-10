using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Api.Core.Model;

namespace BwengXero.Core.Actions
{
    public class VendorAction
    {
        /// <summary>
        ///     Get all vendors
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Contact> GetAllVendors()
        {
            var contacts = XeroApiHelper.CoreApi()?
                .Contacts
                .Find()
                .ToList();

            return contacts;
        }
    }
}
