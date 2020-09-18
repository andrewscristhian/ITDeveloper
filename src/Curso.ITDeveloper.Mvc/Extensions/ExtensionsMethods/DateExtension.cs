using System;
using Microsoft.Extensions.Options;

namespace Curso.ITDeveloper.Mvc.Extensions.ExtensionsMethods
{
    public static class DateExtension
    {
        //Em vez de usar o ToString para formatacao de data para formato Brasil, usar essas classes
        public static string ToBrazilianDate(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy");
        }

        public static string ToBrazilianDateTime(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy: HH:mm:ss");
        }
    }
}
