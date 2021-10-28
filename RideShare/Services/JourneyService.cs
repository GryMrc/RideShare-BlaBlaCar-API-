using RideShare.DataModels;
using RideShare.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.Services
{
    public class JourneyService : IJournerService
    {
        private static List<Journey> Journeys = new();

        public JourneyService()
        {
        }

        public async Task<ServiceResponse> Create(Journey model)
        {
            try
            {
                model.Id = Journeys.Count > 0 ? (Journeys.Last().Id + 1) : 1;
                Journeys.Add(model);
                return ServiceResponse.SuccessfulResponse("Created Succes");
            }
            catch (Exception ex)
            {
                return ServiceResponse.FailedResponse(ex.Message);
            }

        }

        public async Task<ServiceResponse> Delete(int Id)
        {
            try
            {
                var journey = Journeys.FirstOrDefault(j => j.Id == Id);
                if (journey != null)
                {
                    Journeys.Remove(journey);
                    return ServiceResponse.SuccessfulResponse("Deleted Succes");
                }
                else
                {
                    return ServiceResponse.FailedResponse("Journey not Found");
                }

            }
            catch (Exception ex)
            {

                return ServiceResponse.FailedResponse(ex.Message);
            }

        }

        public async Task<ServiceResponse<Journey>> List(string depature, string destination)
        {
            if (Journeys.Count > 0)
            {
                var journies = Journeys.Where(j => j.Departure == depature && j.Destination == destination && j.JourneyDate > DateTime.Now); // Hangi zamanlarda ToList kullanilmasi gerektigi arastirilacak
                return new ServiceResponse<Journey>() { DataList = journies, Total = journies.Count(), Success = true };
            }

            return new ServiceResponse<Journey>() { DataList = null, Total = 0, Success = false, Message = "Data Not Found" };
        }


        public async Task<ServiceResponse> Join(int Id)
        {
            var journey = Journeys.FirstOrDefault(j => j.Id == Id);

            if (journey == null)
            {
                return ServiceResponse.FailedResponse("Journey Not Found");
            }

            if (journey.SeatNumber == 0)
            {
                return ServiceResponse.FailedResponse("There is no seat for this journey plesae look for another one");
            }

            journey.SeatNumber--;
            return new ServiceResponseSingleData<Journey>() { Data = journey, Success = true, Message = "Your join request is sent!" };
        }
    }
}
