using System.Collections.Generic;

namespace DataAnalyse.Net.Services
{
    public interface IProvinceConversionService
    {
        IDictionary<string, string> GetProvinceByProvincePrefix();
        float?[] GetLocationsByCity(string city);
    }
}