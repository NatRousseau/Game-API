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
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Genre { get; set; }
        public string Categorie { get; set; }
        public string Stock { get; set; }
        public string Prix { get; set; }
        public string Collector { get; set; }
        public string Editeur { get; set; }
        public int? Quantite { get; set; }
    }
}