﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundoApp.Data.Models.Dto
{
    public class UserDto
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public virtual UserRoleDto Role { get; set; }

        public string Token { get; set; }

    }
}
