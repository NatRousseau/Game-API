using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CICD_API.Models
{
    [Table("Game")]
    public partial class Game
    {
        [Key] // def Primary Key (id)
        public int id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
    }
}