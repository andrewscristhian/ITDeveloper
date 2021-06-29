using Curso.ITDeveloper.Domain.Entities;

namespace Curso.ITDeveloper.Domain.Entities
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
