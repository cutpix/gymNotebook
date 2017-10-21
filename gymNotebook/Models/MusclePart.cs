using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gymNotebook.Models
{
    public class MusclePart
    {
        [Key]
        public int MusclePartID { get; set; }

        [Required(ErrorMessage = "Wprowadz nazwę Partii Mięsniowej"), Display(Name = "Partia Mięśniowa"), StringLength(50)]
        public string MuscleName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

    }
}