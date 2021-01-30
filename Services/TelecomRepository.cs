using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAnalyze.Net.Entity;
using DataAnalyze.Net.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAnalyze.Net.Services
{
    public class TelecomRepository:ITelecomRepository
    {
        private readonly TelecomRecordContext _telecomRecordContext;

        public TelecomRepository(TelecomRecordContext telecomRecordContext)
        {
            _telecomRecordContext = telecomRecordContext;
        }
        public async Task<IEnumerable<TelecomRecord>> GetLeast(int count)
        {
            return await _telecomRecordContext.TelecomRecord.TakeLast(count).ToListAsync();
        }

        public async Task<IEnumerable<TelecomRecord>> GetAll()
        {
            return await _telecomRecordContext.TelecomRecord.ToListAsync();
        }

        public async Task<IEnumerable<TelecomRecord>> GetByCity(string cityName)
        {
            return await _telecomRecordContext.TelecomRecord
                .Where(record => record.CallerSite1 == cityName || record.CallerSite2 == cityName).ToListAsync();
        }

        public async Task<IEnumerable<TelecomRecord>> GetByPhone(string phoneNum)
        {
            return await _telecomRecordContext.TelecomRecord
                .Where(record => record.Phone1 == phoneNum || record.Phone2 == phoneNum).ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return _telecomRecordContext.TelecomRecord.Count();
        }
    }
}