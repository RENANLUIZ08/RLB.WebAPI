using Microsoft.AspNetCore.Mvc;
using System;

namespace App.RLB.Domain.Entity
{
    public class EntityBase
    {
        [HiddenInput]
        public Guid Id { get; set; }
    }
}
