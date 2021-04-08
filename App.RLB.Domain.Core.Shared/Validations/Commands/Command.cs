using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Domain.Core.Shared.Validations.Commands
{
    public abstract class Command
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
