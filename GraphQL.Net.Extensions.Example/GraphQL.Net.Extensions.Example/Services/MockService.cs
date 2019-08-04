using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Net.Extensions.Example.Models;

namespace GraphQL.Net.Extensions.Example.Services
{
    public class MockService : IMockService
    {
        public async Task<List<MockModel>> GetMockData()
        {
            List<MockModel> list = new List<MockModel>();
            list.Add(new MockModel {Id = 1, Name = "First", Description = "test 1"});
            list.Add(new MockModel {Id = 2, Name = "Second", Description = "test 2"});

            return list;
        }

        public async Task<MockModel> GetMockDataById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }

            return new  MockModel
                    {
                        Id = 1, Name = "First", Description = "test 1"
                    };
        }
    }
}
