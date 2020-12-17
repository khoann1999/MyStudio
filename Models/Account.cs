﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MyStudioApp.Models
{
    public partial class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
