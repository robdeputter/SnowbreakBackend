﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.DTO_s
{
    public class LoginDTO
    {
        [Required] [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
