using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hob.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {get;set;}
        public int HobbyId {get;set;}
        public int UserId {get;set;}
        public Hobby Hobby {get;set;}
        public User User {get;set;}
    }
}