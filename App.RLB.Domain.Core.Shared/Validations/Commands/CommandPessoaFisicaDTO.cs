using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;

namespace App.RLB.Domain.Core.Shared.Validations.Commands
{
    public class CommandNewPessoaFisica : PessoaDTOValidation
    {
        public CommandNewPessoaFisica(IServiceBase<Person> service)
        {
            ValidatorNome();
            ValidatorIdadeMinima();
            ValidatorCPF();
            ValidateExists(service);
        }
    }

    public class CommandUpdatePessoaFisica : PessoaDTOValidation
    {
        public CommandUpdatePessoaFisica(IServiceBase<Person> service)
        {
            ValidateId();
            ValidatorNome();
            ValidatorIdadeMinima();
            ValidatorCPF();
            ValidateExists(service);
        }
    }

    public class CommandDeletePessoaFisica : PessoaDTOValidation
    {
        public CommandDeletePessoaFisica()
        {
            ValidateId();
        }
    }
}
