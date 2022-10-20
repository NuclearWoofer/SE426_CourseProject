using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public class OrderData : IOrderData
    {
        private readonly ISqlDb _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public OrderData(ISqlDb dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> CreateOrder(OrderModel order)
        {

            DynamicParameters p = new DynamicParameters(); //Dapper version of params.

            p.Add("OrderName", order.OrderName);
            p.Add("OrderDate", order.OrderDate);
            p.Add("FoodId", order.FoodId);
            p.Add("Quantity", order.Quantity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);


            //Perform the actual insert
            await _dataAccess.SaveData("dbo.spOrders_Inserts", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");

        }

        public Task<int> UpdateOrderName(int orderId, string orderName)
        {
            //updates the data and returns the response (int)
            //Three pieces of data needed:
            //The stored proceedure, the parameters and values, the name of the connection string we're using.

            return _dataAccess.SaveData("spOrders_UpdateName",
                new
                {
                    Id = orderId,
                    OrderName = orderName
                },
                _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteOrder(int orderId)
        {
            //Delete the specified record and return the response (int)
            //Three pieces of data needed:
            //The stored proceedure, the parameters and values, the name of the connection string we're using.
            return _dataAccess.SaveData("spOrders_Delete",
                new { Id = orderId },
                _connectionString.SqlConnectionName);
        }

        public async Task<OrderModel> GetOrderById(int orderId)
        {
            //this returns a list of records that should either consist of one record or null.
            //We pass in the id as a parameter.

            var recs = await _dataAccess.LoadData<OrderModel, dynamic>("dbo.spOrders_GetByID",
                new { Id = orderId },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
    }
}
