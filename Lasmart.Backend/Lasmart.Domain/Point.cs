using System.ComponentModel.DataAnnotations;

namespace Lasmart.Domain
{
    public class Point
    {
        [Key]
        public Guid PointID { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
