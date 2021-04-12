using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;

namespace App.RLB.Domain.Core.Shared.Validations.Commands
{
    public class CommandNewCliente : ClienteDTOValidation
    {
        public CommandNewCliente(IServiceBase<Person> service)
        {
            ValidatePerson(service);
        }
    }

    public class CommandUpdateCliente : ClienteDTOValidation
    {
        public CommandUpdateCliente(IServiceBase<Person> service)
        {
            ValidateId();
            ValidatePerson(service);
        }
    }

    public class CommandDeleteCliente : ClienteDTOValidation
    {
        public CommandDeleteCliente()
        {
            ValidateId();
        }
    }
}
