﻿using Core.Domain.Bases;

namespace Core.Domain
{
    public class User : BaseEntity<int>
    {

        public string Email { get; set; }
        public string Password { get; set; }



    }
}
