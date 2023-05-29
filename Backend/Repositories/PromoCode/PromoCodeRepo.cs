using Backend.Contexts;
using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;

namespace Backend.Repositories.PromoCode
{
    public class PromoCodeRepo : PromoCodeRepository<PromoCodeEntity>, IPromoCodeRepo
    {
        public PromoCodeRepo(NoSqlContext context) : base(context)
        {
        }
    }
}
