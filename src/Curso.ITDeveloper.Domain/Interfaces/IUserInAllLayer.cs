using System.Collections.Generic;
using System.Security.Claims;

namespace Curso.ITDeveloper.Domain.Interfaces
{
    public interface IUserInAllLayer
    {
        IDictionary<string, string> DictionaryOfClaims();
        IEnumerable<Claim> ListOfClaims();
    }
}
