using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace ApiTrim.Filter
{
    public class CustomeTrimmingModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext objModelBinderProviderContext)
        {
            if (objModelBinderProviderContext == null)
            {
                throw new ArgumentNullException(nameof(objModelBinderProviderContext));
            }
            if (!objModelBinderProviderContext.Metadata.IsComplexType &&
               objModelBinderProviderContext.Metadata.ModelType == typeof(string))
            {
                return new CustomeModelBinder(new SimpleTypeModelBinder(objModelBinderProviderContext.Metadata.ModelType));
            }
            return null;
        }
    }
}
