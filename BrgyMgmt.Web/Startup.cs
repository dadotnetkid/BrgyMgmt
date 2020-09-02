using Audit.SqlServer;
using Audit.SqlServer.Providers;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(BrgyMgmt.Web.Startup))]
namespace BrgyMgmt.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            Audit.Core.Configuration.DataProvider = new SqlDataProvider() {
                ConnectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString,
                Schema = "dbo",
                TableName = "CustomLogs",
                IdColumnName = "EventId",
                JsonColumnName = "JsonData",
                LastUpdatedDateColumnName = "LastUpdatedDate",
                CustomColumns = new List<CustomColumn>() {
                    new CustomColumn("EventType", ev => ev.EventType),
                    new CustomColumn("ByUser", ev => ev.Environment.UserName)
                }
            };

        }
    }
}
