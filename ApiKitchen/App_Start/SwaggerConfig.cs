using ApiKitchen;
using ApiKitchen.SwaggerExtensions;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Library.Service;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ApiKitchen
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ApiKitchen");
                    
                    c.GroupActionsBy(apiDesc => apiDesc.GetControllerAndActionAttributes<GroupSwagger>().Any()
                        ? apiDesc.GetControllerAndActionAttributes<GroupSwagger>().First().GroupName
                        : apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName);

                    c.OrderActionGroupsBy(new StringComparerAscendingService());

                    c.IncludeXmlComments(String.Format("{0}\\bin\\ApiKitchen.xml",
                        AppDomain.CurrentDomain.BaseDirectory));

                    c.DescribeAllEnumsAsStrings();

                    c.DocumentFilter<AuthTokenOperation>();

                    c.DocumentFilter<SortOperationsByPathDocumentFilter>();
                })
                .EnableSwaggerUi(c =>
                {
                    c.InjectJavaScript(thisAssembly,
                        "ApiKitchen.SwaggerExtensions.AddBearerAuthHeader.js");
                });
        }
    }
}