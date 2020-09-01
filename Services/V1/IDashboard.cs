using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;
using VEMS.Models.DB.DTO;

namespace VEMS.Services.V1
{
    public interface IDashboard
    {
        Task<ApiResponse<DashboardDTO>> Get();
    }
}
