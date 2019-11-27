using System;

namespace Curso.ITDeveloper.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
