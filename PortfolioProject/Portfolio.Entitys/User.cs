﻿using Microsoft.AspNetCore.Identity;

namespace Portfolio.Entitys;

public class User : IdentityUser
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
}