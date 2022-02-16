

namespace UnluCoProductCatalog.Domain.Entities
{
    public class User : BaseEntity
    {
        public int AccountDetailId { get; set; }
        public AccountDetail AccountDetail { get; set; }
    }
}
