using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API.Swagger
{
public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string apiHost,string scope)
        {
            services.AddSwaggerGen(c =>
            {
             
               // c.OperationFilter<AddAcceptLanguageParameter>();
                c.CustomSchemaIds(obj => obj.FullName);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture.API", Version = "v1" });
                c.OperationFilter<AddOperationId>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri($"{apiHost}connect/token", UriKind.Absolute),
                            Scopes = new Dictionary<string, string>
                        {
                            {scope, scope}
                        }
                        }
                    }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            }
                        },
                       new string[] { scope }
                    }
                });
            });
            services.ConfigureSwaggerGen(options =>
            {
                var pathDivider = System.Environment.OSVersion.ToString().Contains("Windows", StringComparison.InvariantCultureIgnoreCase) ? @"\" : @"/";
                var xmlDocFile = Path.Combine(AppContext.BaseDirectory, Environment.CurrentDirectory + $@"{pathDivider}JobariaAPI.xml");
                if (File.Exists(xmlDocFile))
                {
                    options.IncludeXmlComments(xmlDocFile);
                }
            });
            return services;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app,string clientId,string secret)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jobaria API V1");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "Jobaria API";
                c.DocExpansion(DocExpansion.None);

                c.OAuthClientId("");
                c.OAuthClientSecret("");
                c.OAuthScopeSeparator(" ");
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();

            });

            return app;
        }
        public class AddOperationId : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                operation.OperationId = context.MethodInfo.Name;
            }
        }
    }
}
