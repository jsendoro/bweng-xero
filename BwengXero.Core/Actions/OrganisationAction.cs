using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Api.Core.Model;

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
            var organisation = XeroApiHelper.CoreApi()?
                .Organisation;

            return organisation;
        }
    }
}
