using System.ComponentModel.DataAnnotations;

namespace Authentication_Appplication.Model
{
    public class Heel
    {
        [Key]
        public int HeelId { get; set; }

        [Required]
        [Display(Name = "Model Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]

        public string Description { get; set; }

        [Required]
        public string Brand { get; set; }

    }
}
