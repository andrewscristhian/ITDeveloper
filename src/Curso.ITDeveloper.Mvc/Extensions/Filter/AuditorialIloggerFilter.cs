using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Curso.ITDeveloper.Mvc.Extensions.Filter
{
    public class AuditorialIloggerFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public AuditorialIloggerFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Todo: Logar algo antes da execucao.
            _logger.Info($"Url Acessada: {context.HttpContext.Request.GetDisplayUrl()} \n\n___________________________\n\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = context.HttpContext.User.Identity.Name;
                var tipoAuth = context.HttpContext.User.Identity.AuthenticationType;
                var urlAcessada = context.HttpContext.Request.GetDisplayUrl();
                var valueHost = context.HttpContext.Request.Host.Value;
                var tipoContent = context.HttpContext.Request.ContentType;

                var logMsg = $"O usuario {user} acesou a Url {urlAcessada} \nEm: {DateTime.Now}" +
                             $"\n==============================\n{valueHost}\n{tipoContent}\nTipo de" +
                             $"Autenticacao: {tipoAuth}";

                _logger.Info(logMsg);
            }
        }
    }
}
