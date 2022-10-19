using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Public.Dtos.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "User name mandatory.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password mandatory.")]
        public string Password { get; set; }
    }
}
