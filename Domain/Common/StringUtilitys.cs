namespace Cobranca.PortalWeb.Domain.Common
{
    public static class StringUtilitys
    {
        public static string MaskCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return cnpj;

            // Remove tudo que não for número
            var numeros = new string(cnpj.Where(char.IsDigit).ToArray());

            // Se menor que 14, retorna original sem máscara
            if (numeros.Length != 14)
                return cnpj;

            // Aplica máscara
            return Convert.ToUInt64(numeros).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string MaskTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return telefone;

            var numeros = new string(telefone.Where(char.IsDigit).ToArray());

            // Remove DDI Brasil
            if (numeros.Length == 13 && numeros.StartsWith("55"))
                numeros = numeros.Substring(2);

            if (numeros.Length == 11)
                return $"({numeros[..2]}) {numeros[2]} {numeros.Substring(3, 4)}-{numeros.Substring(7, 4)}";

            if (numeros.Length == 10)
                return $"({numeros[..2]}) {numeros.Substring(2, 4)}-{numeros.Substring(6, 4)}";

            return telefone;
        }


        public static string MaskCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return cep;

            var numeros = new string(cep.Where(char.IsDigit).ToArray());

            // CEP deve ter 8 dígitos
            if (numeros.Length != 8)
                return cep;

            return $"{numeros.Substring(0, 5)}-{numeros.Substring(5, 3)}";
        }

        public static string MaskIE(string ie)
        {
            if (string.IsNullOrWhiteSpace(ie))
                return ie;

            var numeros = new string(ie.Where(char.IsDigit).ToArray());

            // 9 dígitos
            if (numeros.Length == 9)
            {
                return $"{numeros.Substring(0, 3)}.{numeros.Substring(3, 3)}.{numeros.Substring(6, 3)}";
            }

            // 12 dígitos
            if (numeros.Length == 12)
            {
                return $"{numeros.Substring(0, 3)}.{numeros.Substring(3, 3)}.{numeros.Substring(6, 3)}.{numeros.Substring(9, 3)}";
            }

            return ie;
        }
    }
}
