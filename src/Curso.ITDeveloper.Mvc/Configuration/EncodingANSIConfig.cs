﻿using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Curso.ITDeveloper.Mvc.Configuration
{
    public static class EncodingANSIConfig
    {
        public static IServiceCollection AddCodePageProviderNotSupportedInDotNetCoreForAnsi(this IServiceCollection services)
        {
            /* Fornece acesso a um provedor de codificação para páginas de código que de 
             * outra forma, estão disponíveis apenas no .Net Framework para Desktop */
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return services;
        }
    }
}