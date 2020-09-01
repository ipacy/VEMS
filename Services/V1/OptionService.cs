using VEMS.Data;
using VEMS.Models.DB.Options;

namespace VEMS.Services.V1
{
    public class OptionService : BaseEntityService<Option>
    {
        private readonly ApplicationDbContext dbContext;

        public OptionService(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
