using FlexiSchools.Application.Common.Enums;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FlexiSchools.API.Headers
{
    public class ApiHeader : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();



            operation.Parameters.Add(new OpenApiParameter
            {
                AllowEmptyValue = true,
                Name = HeadersConst.Token,
                In = ParameterLocation.Header,
                Style = ParameterStyle.Form,
                //Type = "int",
                Required = true // set to false if this is optional
            });
        }
    }
}
