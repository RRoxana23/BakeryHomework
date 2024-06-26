﻿using Microsoft.AspNetCore.Identity;

namespace Bakery_H.Models
{
    public class User: IdentityUser<Guid>
    {
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? NumarTelefon { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
