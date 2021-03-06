﻿using System;
using System.Collections.Generic;

namespace base_project.Models
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? Active { get; set; }
    }
}
