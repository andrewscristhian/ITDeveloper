using Microsoft.AspNetCore.Http;

namespace Curso.ITDeveloper.Mvc.Infra
{
    public interface IUnitOfUpload
    {
        void UploadImage(IFormFile file);
    }
}
