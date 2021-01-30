using System.Collections.Generic;

namespace DataAnalyze.Net.Services
{
    public interface IProvinceConversionService
    {
        IDictionary<string, string> GetProvinceByProvincePrefix();
        float?[] GetLocationsByCity(string city);
    }
}