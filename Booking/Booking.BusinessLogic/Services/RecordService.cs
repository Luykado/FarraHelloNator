using System.Threading.Tasks;
using Booking.BusinessLogic.Interfaces;
using Booking.BusinessLogic.ContractModels;
using Booking.DataAccess.Models;
using Booking.DataAccess.Interfaces;
using Booking.Core.Enums;
using Booking.BusinessLogic.Extensions.Mappers;
using System;
namespace Booking.BusinessLogic.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            this.recordRepository = recordRepository;
        }

        public async Task<int> CreateRecordAsync(RecordContract recordContract)
        {
            if (default(DateTime) == recordContract.CreatedDate)
                recordContract.CreatedDate = DateTime.Now;

            if (default(DateTime) == recordContract.LastModifiedDate)
                recordContract.LastModifiedDate = recordContract.CreatedDate; 

            Record record = recordContract.ToDataModel();

            return await recordRepository.CreateAsync(record);
        }
    }
}