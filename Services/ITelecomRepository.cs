using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAnalyze.Net.Infrastructure;
using DataAnalyze.Net.Entity;

namespace DataAnalyze.Net.Services
{
    public interface ITelecomRepository
    {
        public Task<IEnumerable<TelecomRecord>> GetLeast(int count);

        public Task<IEnumerable<TelecomRecord>> GetAll();
        public Task<IEnumerable<TelecomRecord>> GetByCity(string cityName);
        public Task<IEnumerable<TelecomRecord>> GetByPhone(string phoneNum);
        public Task<int> GetCount();

    }
}