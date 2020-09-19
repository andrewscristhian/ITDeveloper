using Curso.ITDeveloper.Domain.Entities;

namespace Curso.ITDeveloper.Domain.Models
{
    public class Generico : EntityBase
    {
        public Generico()
        {

        }

        public int Codigo { get; set; }
        public string Nome { get; set; }

    }
}
