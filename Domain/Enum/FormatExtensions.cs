using System.Globalization;
using System.Text.RegularExpressions;

namespace Cobranca.PortalWeb.Domain.Enum
{
    public static class FormatExtensions
    {
        private static readonly CultureInfo PtBr = new("pt-BR");

        // ------------------------------
        // DATAS
        // ------------------------------
        public static string ToBrDate(this DateTime? date) =>
            date?.ToString("dd/MM/yyyy") ?? "-";

        public static string ToBrDateTime(this DateTime? date) =>
            date?.ToString("dd/MM/yyyy HH:mm") ?? "-";

        // ------------------------------
        // VALORES MONETÁRIOS E %
        // ------------------------------
        public static string ToBrCurrency(this decimal? value) =>
            value.HasValue ? value.Value.ToString("C", PtBr) : "-";

        public static string ToBrCurrency(this double? value) =>
            value.HasValue ? value.Value.ToString("C", PtBr) : "-";

        public static string ToBrPercent(this decimal? value, int decimals = 2) =>
            value.HasValue ? $"{Math.Round(value.Value, decimals):N2}%" : "-";

        public static string ToBrPercent(this double? value, int decimals = 2) =>
            value.HasValue ? $"{Math.Round(value.Value, decimals):N2}%" : "-";

        // ------------------------------
        // DOCUMENTOS (CPF / CNPJ)
        // ------------------------------
        public static string ToCpf(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "-";

            var digits = Regex.Replace(value, "[^0-9]", "");
            if (digits.Length != 11)
                return value; // não é CPF

            return Convert.ToUInt64(digits).ToString(@"000\.000\.000\-00");
        }

        public static string ToCnpj(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "-";

            var digits = Regex.Replace(value, "[^0-9]", "");
            if (digits.Length != 14)
                return value; // não é CNPJ

            return Convert.ToUInt64(digits).ToString(@"00\.000\.000\/0000\-00");
        }

        // ------------------------------
        // FORMATAÇÃO AUTOMÁTICA (CPF OU CNPJ)
        // ------------------------------
        public static string ToCpfCnpj(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "-";

            var digits = Regex.Replace(value, "[^0-9]", "");
            return digits.Length switch
            {
                11 => digits.ToCpf(),
                14 => digits.ToCnpj(),
                _ => value
            };
        }
    }
}
