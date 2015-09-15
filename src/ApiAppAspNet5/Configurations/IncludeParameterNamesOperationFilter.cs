namespace ApiAppAspNet5.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Swashbuckle.Swagger;

    public class IncludeParameterNamesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            var parameters = operation.Parameters.Select(p => p.Name);
            operation.OperationId = string.Format("{0}_by_{1}", operation.OperationId, string.Join("_and_", parameters));
        }
    }
}
