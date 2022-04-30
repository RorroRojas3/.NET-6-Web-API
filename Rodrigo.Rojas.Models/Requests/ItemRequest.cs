using System.ComponentModel.DataAnnotations;

namespace Rodrigo.Rojas.Models.Requests
{
    public class ItemRequest
    { 
        [Required]
        public string Name { get; set; }
    }
}
