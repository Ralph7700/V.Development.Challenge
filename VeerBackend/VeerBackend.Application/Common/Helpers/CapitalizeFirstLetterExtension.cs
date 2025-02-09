using System.Globalization;

namespace VeerBackend.Application.Common.Helpers;

public static class CapitalizeFirstLetterExtension
{
    public static string? CapitalizeFirstLetter(this string? input)
    {
        return string.IsNullOrEmpty(input)
            ? input
            : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower().Trim());
    }
}