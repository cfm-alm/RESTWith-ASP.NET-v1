using System.ComponentModel.DataAnnotations.Schema;

namespace RestwithASPNETUdemy.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
