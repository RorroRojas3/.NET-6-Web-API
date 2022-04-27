using System.ComponentModel.DataAnnotations;

namespace Rodrigo.Rojas.Repository.Sets
{
    public class ItemSet
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }
    }
}
