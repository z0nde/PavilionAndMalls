using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PavilionAndMalls.Pages.Authentications
{
    /// <summary>
    /// Свойства с данными для аутентификации
    /// </summary>
    public static class AuthenticationData
    {
        public static string? Login { get; set; }
        public static string? Password { get; set; }
        public static int IdEmployee { get; set; }
        public static int? IdRole { get; set; }
        public static int AttemptsCaptcha { get; set; } = 0;
    }
}
