using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Data;
using VEMS.Models;
using VEMS.Models.DB.DTO;

namespace VEMS.Services.V1
{
    public class DashboardService : IDashboard
    {
        private readonly ApplicationDbContext dbContext;

        public DashboardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ApiResponse<DashboardDTO>> Get()
        {
            var result = new ApiResponse<DashboardDTO>();
            var dashboard = new DashboardDTO();
            try
            {
                dashboard.AllExams = dbContext.Exams.Count().ToString();
                dashboard.Questions = dbContext.Questions.Count().ToString();
                result.Data = dashboard;
                result.AddSuccess();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                return await Task.FromResult(result);
            }

        }
    }
}
