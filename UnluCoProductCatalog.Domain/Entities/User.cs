namespace UnluCoProductCatalog.Domain.Entities
{
    public class User : BaseEntity
    {
        //Microsoft.Identity ile oluşturulacak.

        public AccountDetail AccountDetail { get; set; }
    }
}