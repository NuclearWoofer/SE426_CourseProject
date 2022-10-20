using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Db;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly ISqlDb _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public FoodData(ISqlDb dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public Task<List<FoodModel>> GetFood()
        {
            return _dataAccess.LoadData<FoodModel, dynamic>("dbo.spFood_All", new { }, _connectionStringData.SqlConnectionName);
        }
    }
}
