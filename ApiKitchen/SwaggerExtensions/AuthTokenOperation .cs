using Library.Resources;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace ApiKitchen.SwaggerExtensions
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/oauth2/token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Token" },
                    summary = MessageResource.AuthenticateUserToGrantAuthorizationToken,
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter> {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            description = MessageResource.TypeOnlyPassword,
                            required = true,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            description = MessageResource.LoginThatWasRegistred,
                            required = true,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            description = MessageResource.PasswordThatWasRegistred,
                            required = true,
                            @in = "formData"
                        }
                    }
                }
            });
        }
    }
}