using System;
using System.ComponentModel.DataAnnotations;

namespace Hob.Models
{
    public class LogUser
    {
        [Required]
        public string LUserName {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string LPassword {get;set;}
    }
}