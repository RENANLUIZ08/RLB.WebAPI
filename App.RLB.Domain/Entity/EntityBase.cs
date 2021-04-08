using System;

namespace App.RLB.Domain.Entity
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        protected EntityBase()
        { Id = Guid.NewGuid(); }
    }
}
