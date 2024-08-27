namespace Pustok2.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Createdtime { get; set; }
        public DateTime Updatedtime { get; set;}
    }
}
