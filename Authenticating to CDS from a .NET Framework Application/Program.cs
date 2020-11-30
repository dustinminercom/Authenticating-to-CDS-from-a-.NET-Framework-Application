using System;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Authenticating_to_CDS_from_a.NET_Framework_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "AuthType = ClientSecret;" +
                                           "url = https://rmservername.crmx.dynamics.com; " +
                                           "ClientId =  " +
                                           "ClientSecret =  ";

                CrmServiceClient crmSvc = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(connectionString);
                WhoAmIResponse whoAmI = (WhoAmIResponse)crmSvc.Execute(new WhoAmIRequest());
                var organizationId = whoAmI.OrganizationId;
                Entity org = crmSvc.Retrieve("organization", organizationId, new Microsoft.Xrm.Sdk.Query.ColumnSet("businessclosurecalendarid"));
            }
            catch (Exception e)
            {
                Console.WriteLine("The following exception has been generated " + e);
            }
        }
    }
}
