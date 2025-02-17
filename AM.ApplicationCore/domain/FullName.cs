﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    //tp4 Q11
    [Owned]
    public class FullName
    {
        [MaxLength(25, ErrorMessage = "la longeur maximale 25")] 
        [MinLength(3, ErrorMessage = "la longeur minimale 3")]    
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
