using System.ComponentModel.DataAnnotations;

namespace Vinsjansen.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string? Owner { get; set; }
		public bool IsTaken { get; set; }
	}
}
