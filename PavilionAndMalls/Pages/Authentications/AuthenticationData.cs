namespace PavilionAndMalls.Pages.Authentications
{
    /// <summary>
    /// Свойства с данными для аутентификации
    /// </summary>
    public static class AuthenticationData
    {
        public static string? Login { get; set; }
        public static string? Password { get; set; }
        public static int? IdRole { get; set; }
        public static int AttemptsCaptcha { get; set; } = 0;
    }
}
