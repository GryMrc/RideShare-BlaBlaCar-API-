using RideShare.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.ServiceContracts
{
    public interface IJournerService
    {
        Task<ServiceResponse> Create(Journey model);
        Task<ServiceResponse<Journey>> List(string depature, string destination);
        Task<ServiceResponse> Delete(int Id);
        Task<ServiceResponse> Join(int Id);
    }
}
