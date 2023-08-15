using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lasmart.Domain
{
    public class Comment
    {
        [Key]
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string BackgroundColor { get; set; }

        [ForeignKey("Point")]
        public Guid PointID { get; set; }        
        public virtual Point Point { get; set; }
    }
}
