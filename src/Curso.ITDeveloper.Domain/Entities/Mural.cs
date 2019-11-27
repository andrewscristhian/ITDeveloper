using System;

namespace Curso.ITDeveloper.Domain.Entities
{
    public class Mural
    {
        public int MuralId { get; set; }
        public DateTime Data { get; set; }
        public String Titulo { get; set; }
        public string Aviso { get; set; }
        public string Autor { get; set; }
        public string Email { get; set; }
    }
}
