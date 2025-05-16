using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CnpjValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is not string cnpj) return false;

        cnpj = Regex.Replace(cnpj, @"\D", ""); // Remove não dígitos

        if (cnpj.Length != 14) return false;

        // Validação de dígitos
        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj[..12];
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        string digito = (resto < 2 ? 0 : 11 - resto).ToString();
        tempCnpj += digito;
        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        digito += (resto < 2 ? 0 : 11 - resto).ToString();

        return cnpj.EndsWith(digito);
    }
}
