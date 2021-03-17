
namespace App.RLB.WebAPI.Service.Interface
{
    public interface IPessoaService
    {
        bool ValidaCPF(string CPF);
        bool ValidaCNPJ(string CNPJ);
    }
}
