using App.RLB.Domain.Core.Shared.Validations.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Domain.Core.Shared.DTO
{
    public class DTOBase : Command
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
