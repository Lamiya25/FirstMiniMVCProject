﻿using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.ViewModels
{
    public class RegiasterVM
    {
        public string Name { get; set; }
       
        public string LastName { get; set; }
     
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
