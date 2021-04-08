using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;

namespace App.RLB.Domain.Core.Shared.Validations.Commands
{
    public class CommandNewContato : ContatoDTOValidation
    {
        public CommandNewContato(IServiceBase<Contact> service)
        {
            ValidateEmail();
            ValidateExists(service);
        }
    }

    public class CommandUpdateContato : ContatoDTOValidation
    {
        public CommandUpdateContato(IServiceBase<Contact> service)
        {
            ValidateId();
            ValidateEmail();
            ValidateExists(service);
        }
    }

    public class CommandDeleteContato : ContatoDTOValidation
    {
        public CommandDeleteContato()
        {
            ValidateId();
        }
    }
}
