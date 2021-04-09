using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;

namespace App.RLB.Domain.Core.Shared.Validations.Commands
{
    public class CommandNewPessoaJuridica : PessoaDTOValidation
    {
        public CommandNewPessoaJuridica(IServiceBase<Person> service)
        {
            ValidatorNomeFantasia();
            ValidatorNomeProprietario();
            ValidatorRazaoSocial();
            ValidatorCNPJ();
            ValidateExists(service);
        }
    }

    public class CommandUpdatePessoaJuridica : PessoaDTOValidation
    {
        public CommandUpdatePessoaJuridica(IServiceBase<Person> service)
        {
            ValidateId();
            ValidatorNomeFantasia();
            ValidatorNomeProprietario();
            ValidatorRazaoSocial();
            ValidatorCNPJ();
            ValidateExists(service);
        }
    }

    public class CommandDeletePessoaJuridica : PessoaDTOValidation
    {
        public CommandDeletePessoaJuridica()
        {
            ValidateId();
        }
    }
}
