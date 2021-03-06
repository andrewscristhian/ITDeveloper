﻿using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Curso.ITDeveloper.Domain.Interfaces
{
    public interface IUserInContext
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
        string GetUserApelido();
        string GetUserNomeCompleto();
        string GetUserDataNascimento();
        string GetUserImgProfilePath();
    }
}
