using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Net.Extensions.Example.Models;

namespace GraphQL.Net.Extensions.Example.Services
{
    public interface IMockService
    {
        Task<List<MockModel>> GetMockData();

        Task<MockModel> GetMockDataById(int id);
    }
}
