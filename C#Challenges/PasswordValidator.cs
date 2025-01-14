using System.Text.RegularExpressions;


namespace CsharpChallenges
{
    public static class PasswordValidator
    {
            public static string Validate(string contraseña)
        {
            if (contraseña.Length < 8)
                return "La contraseña debe tener al menos 8 caracteres.";

            if (!Regex.IsMatch(contraseña, @"[A-Z]"))
                return "La contraseña debe contener al menos una letra mayúscula.";

            if (!Regex.IsMatch(contraseña, @"[a-z]"))
                return "La contraseña debe contener al menos una letra minúscula.";

            if (!Regex.IsMatch(contraseña, @"[0-9]"))
                return "La contraseña debe contener al menos un número.";

            if (!Regex.IsMatch(contraseña, @"[@#\$%\^&\*\(\)_\+\-=\[\]{};':"",\.<>\/?!\\|]"))
                return "La contraseña debe contener al menos un carácter especial.";

            return "Contraseña válida.";
        }
    }
}