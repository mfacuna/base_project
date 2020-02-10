using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Filters
{
    public class AddVersionHeader : IOperationFilter
    {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation == null) return;

                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                foreach (var parameter in operation.Parameters)
                {
                    parameter.Name = "api-version";
                    parameter.In = ParameterLocation.Header;
                    parameter.Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Default = new OpenApiString(context.ApiDescription.GroupName),
                    };
                }
                //var version = swaggerDoc.Info.Version;
            }
        }
}
