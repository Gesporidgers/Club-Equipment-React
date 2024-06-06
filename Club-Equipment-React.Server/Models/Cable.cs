using System.Numerics;

namespace Club_Equipment_React.Server.Models
{
	public class Cable
	{
		public long Id { get; set; }

		public string? Type { get; set; }
		public float length { get; set; }
		public ushort quantity { get; set; }
	}
}
