namespace App.RLB.Domain.Interface.Repositories
{
    public interface IPessoaService
    {
        bool ValidaCPF(string CPF);
        bool ValidaCNPJ(string CNPJ);
    }
}
