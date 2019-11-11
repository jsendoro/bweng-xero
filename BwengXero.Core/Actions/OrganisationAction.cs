using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;
using Xero.Api.Example.Applications.Public;

namespace BwengXero.Core.Actions
{
    public class OrganisationAction
    {
        /// <summary>
        ///     Get the organisation
        /// </summary>
        /// <returns></returns>
        public static Organisation GetOrganisation()
        {
            try { 
                var organisation = XeroApiHelper.CoreApi()?
                    .Organisation;

                return organisation;
            }
            catch(Exception)
            {
                throw new RenewTokenException();
            }
        }
    }
}
