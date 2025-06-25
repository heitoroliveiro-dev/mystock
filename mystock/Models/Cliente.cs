using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace MyStockClientes
{

    public enum TipoCliente
    {
        Fisica,
        Juridica
    }
    
    public enum StatusCliente
    {
        Ativo,
        Inativo
    }

    public class Cliente : IValidatableObject
    {
        public int Id { get; set; }


        // Nome do cliente
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome do cliente deve ter no máximo 200 caracteres")]
        public string NomeRazaoSocial { get; set; } = string.Empty;

        // Tipo do cliente
        [Required(ErrorMessage = "O tipo do cliente é obrigatório")]
        public TipoCliente Tipo { get; set; }

        // CPF ou CNPJ
        private string _cpfCnpj = string.Empty;
        [Required(ErrorMessage = "O CPF ou CNPJ é obrigatório")]
        [StringLength(18, ErrorMessage = "O CPF ou CNPJ deve ter no máximo 18 caracteres")]
        public string CpfCnpj
        {
            get => _cpfCnpj;
            set
            {
                string apenasNumerosCpfCnpj = new string(value.Where(char.IsDigit).ToArray());
                // string apenasNumeros recebe um novo objeto string que contém apenas os números digitados e cria um Array de caracteres.

                // Lógica para formatação do campo conforme o Tipo do cliente
                // Se o Tipo for Física e o comprimento for 11
                if (Tipo == TipoCliente.Fisica && apenasNumerosCpfCnpj.Length == 11)
                {
                    // Formata como CPF: 000.000.000-00
                    _cpfCnpj = Convert.ToUInt64(apenasNumerosCpfCnpj).ToString(@"000\.000\.000\-00");
                }
                // Se o Tipo for Jurídica e o comprimento for 14
                else if (Tipo == TipoCliente.Juridica && apenasNumerosCpfCnpj.Length == 14)
                {
                    // Formata como CNPJ: 00.000.000/0000-00
                    _cpfCnpj = Convert.ToInt64(apenasNumerosCpfCnpj).ToString(@"00\.000\.000\/0000\-00");
                }
                else
                {
                    // Mantém apenas os números, sem formatação
                    _cpfCnpj = string.Empty;
                }
            }
        }

        // Telefone do cliente
        [StringLength(14, ErrorMessage = "O telefone deve ter no máximo 14 caracteres")]
        private string _Telefone = string.Empty;
        public string Telefone
        {
            get => _Telefone;
            set
            {
                string apenasNumerosTelefone = new string(value.Where(char.IsDigit).ToArray());
                {
                    if (apenasNumerosTelefone.Length == 11)
                    {
                        _Telefone = Convert.ToInt64(apenasNumerosTelefone).ToString(@"(00) 00000\-0000");
                    }
                    else if (apenasNumerosTelefone.Length == 10)
                    {
                        _Telefone = Convert.ToInt64(apenasNumerosTelefone).ToString(@"(00) 0000\-0000");
                    }
                    else
                    {
                        _Telefone = string.Empty;
                    }
                }
            }
        }


        // E-mail do cliente
        [StringLength(200, ErrorMessage = "O e-mail deve ter no máximo 200 caracteres")]
        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                // Verifica se o e-mail é válido
                if (string.IsNullOrWhiteSpace(value) || !new EmailAddressAttribute().IsValid(value))
                // EmailAdressAttribute é uma classe do framework .NET que valida se o e-mail é válido.
                {
                    _email = string.Empty; // Se não for válido, define como vazio
                }
                else
                {
                    _email = value; // Se for válido, atribui o valor
                }
            }
        }


        // Endereço do cliente
        [StringLength(500, ErrorMessage = "O endereço deve ter no máximo 500 caracteres")]
        public string Endereco { get; set; } = string.Empty;

        // Status do cliente
        [Required(ErrorMessage = "O status do cliente é obrigatório")]
        public StatusCliente Status { get; set; } = StatusCliente.Ativo;

        // Esta classe IEnumerable<ValidationResult> é usada para validar o modelo Cliente.
        // Ela implementa a interface IValidatableObject, que permite realizar validações personalizadas
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // CPF/CNPJ
            string apenasNumerosCpfCnpj = new string(CpfCnpj.Where(char.IsDigit).ToArray());
            if (!apenasNumerosCpfCnpj.All(char.IsDigit))
            {
                yield return new ValidationResult("O campo deve conter apenas números.", new[] { nameof(CpfCnpj) });
                yield break;
            }
            if (Tipo == TipoCliente.Fisica && apenasNumerosCpfCnpj.Length != 11)
            {
                yield return new ValidationResult("CPF deve ter 11 dígitos numéricos.", new[] { nameof(CpfCnpj) });
            }
            else if (Tipo == TipoCliente.Juridica && apenasNumerosCpfCnpj.Length != 14)
            {
                yield return new ValidationResult("CNPJ deve ter 14 dígitos numéricos.", new[] { nameof(CpfCnpj) });
            }

            // Telefone
            string apenasNumerosTelefone = new string(Telefone.Where(char.IsDigit).ToArray());
            if (!apenasNumerosTelefone.All(char.IsDigit))
            {
                yield return new ValidationResult("O telefone deve conter apenas números.", new[] { nameof(Telefone) });
                yield break;
            }
            if (apenasNumerosTelefone.Length != 10 && apenasNumerosTelefone.Length != 11)
            {
                yield return new ValidationResult("Telefone deve ter 10 ou 11 dígitos.", new[] { nameof(Telefone) });
            }

            // E-mail
            if (!string.IsNullOrWhiteSpace(Email) && !new EmailAddressAttribute().IsValid(Email))
            {
                yield return new ValidationResult("E-mail inválido.", new[] { nameof(Email) });
            }
        }
    }
}