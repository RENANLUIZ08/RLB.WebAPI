using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Domain.Core.Shared.Validations.Commands
{
    public class CommandNewEndereco : EnderecoDTOValidation
    {
        public CommandNewEndereco()
        {
            ValidateEndereco();
        }
    }

    public class CommandUpdateEndereco : EnderecoDTOValidation
    {
        public CommandUpdateEndereco()
        {
            ValidateEndereco();
            ValidateId();
        }
    }

    public class CommandDeleteEndereco : EnderecoDTOValidation
    {
        public CommandDeleteEndereco()
        {
            ValidateId();
        }
    }
}
