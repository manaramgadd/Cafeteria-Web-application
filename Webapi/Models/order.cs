using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
namespace Cafeteria.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public int EmpID { get; set; }
        public int productID { get; set; }
        public int quantityRequired { get; set; }
        public int totalprice { get; set; }
        public DateTime dateandTime { get; set; }
        public double completed { get; set; }

        internal AppDb Db { get; set; }
        public Order()
        {
        }
        internal Order(AppDb db)
        {
            Db = db;
        }
        public async Task Insert()
        {
            using var cmd = Db.Connection.CreateCommand();
            string spName = @"Add_order";
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@empID",
                DbType = DbType.Int32,
                Value = EmpID,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@ProdID",
                DbType = DbType.Int32,
                Value = productID,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@quantityRequired",
                DbType = DbType.Int32,
                Value = quantityRequired,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@totalPrice",
                DbType = DbType.Int32,
                Value = totalprice,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@dateAndTime",
                DbType = DbType.Int32,
                Value = dateandTime,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@completed",
                DbType = DbType.Int32,
                Value = completed,
            });
            await cmd.ExecuteNonQueryAsync();
            orderID = (int)cmd.LastInsertedId;
        }



    }
}