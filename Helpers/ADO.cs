using System.Collections.ObjectModel;
using System.Linq;

namespace Keedoozle_Fine_Food.Helpers
{
    public static class ADO
    {

        //using var sqlConnection = new SqlConnetion();
        public static async Task<List<Item>> GetItemsByCategoryId(int categoryId)
        {
            List<Item> Items = new();

            try
            {
                using SqlConnection connection = new(DBConnection.ConnectionString);
                SqlCommand command = new();
                if (connection.State == ConnectionState.Closed) { await connection.OpenAsync(); }
                command.CommandText = "GetItemByCategroy";
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", categoryId);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Items.Add(new Item()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = Convert.ToString(reader[1]),
                        Quantiy = Convert.ToInt32(reader[2]),
                        Price = Convert.ToInt32(reader[3]),
                        ItemCategoryId = Convert.ToInt32(reader[4]),
                        Tax = Convert.ToInt32(reader[5]),
                    });
                }
                if (connection.State == ConnectionState.Open) { await connection.CloseAsync(); }

                await reader.CloseAsync();
                await reader.DisposeAsync();

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return Items;
        }
        public static async Task<List<ItemCategory>> GetAllCategories()
        {
            List<ItemCategory> ItemCategories = new();

            try
            {
                using SqlConnection connection = new(DBConnection.ConnectionString);
                SqlCommand command = new();
                if (connection.State == ConnectionState.Closed) { await connection.OpenAsync(); }
                command.CommandText = "GetAllCategories";
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ItemCategories.Add(new()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        CategoryName = Convert.ToString(reader[1]),
                    });
                }
                if (connection.State == ConnectionState.Open) { await connection.CloseAsync(); }
                await reader.CloseAsync();
                await reader.DisposeAsync();

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return ItemCategories;
        }
        public static async Task<List<Order>> GetAllOrders()
        {
            List<Order> ItemCategories = new();

            try
            {
                using SqlConnection connection = new(DBConnection.ConnectionString);
                SqlCommand command = new();
                if (connection.State == ConnectionState.Closed) { await connection.OpenAsync(); }
                command.CommandText = "GetAllOrders";
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ItemCategories.Add(new Order()
                    {
                        OrderId = Convert.ToInt32(reader[0]),
                        Discount = Convert.ToDouble(reader[1]),
                    });
                }
                if (connection.State == ConnectionState.Open) { await connection.CloseAsync(); }

                await reader.CloseAsync();
                await reader.DisposeAsync();

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return ItemCategories;
        }
        public static async Task<List<Item>> GetAllItems()
        {
            List<Item> Items = new();

            try
            {
                using SqlConnection connection = new(DBConnection.ConnectionString);
                SqlCommand command = new();
                if (connection.State == ConnectionState.Closed) { await connection.OpenAsync(); }
                command.CommandText = "GetAllItems";
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Items.Add(new Item()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = Convert.ToString(reader[1]),
                        Quantiy = Convert.ToInt32(reader[2]),
                        Price = Convert.ToInt32(reader[3]),
                        ItemCategoryId = Convert.ToInt32(reader[4]),
                        Tax = Convert.ToInt32(reader[5]),
                    });
                }
                if (connection.State == ConnectionState.Open) { await connection.CloseAsync(); }

                await reader.CloseAsync();
                await reader.DisposeAsync();

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return Items;
        }
        public static int SaveOrder(Order order, List<OrderItem> orderItems, List<Item> items)
        {
            using SqlConnection connection = new(DBConnection.ConnectionString);
            try
            {
                order.DateCreated = DateTime.Now;
                SqlCommand command = new("INSERT INTO food_order (discount, subTotal, tax, grandTotal, date_created) VALUES (@discount, @subTotal, @tax, @grandTotal, @date_created); SELECT SCOPE_IDENTITY();", connection);
                command.Parameters.Add(new SqlParameter("@discount", order.Discount));
                command.Parameters.Add(new SqlParameter("@subTotal", order.SubTotal));
                command.Parameters.Add(new SqlParameter("@tax", order.Tax));
                command.Parameters.Add(new SqlParameter("@grandTotal", order.GrandTotal));
                command.Parameters.Add(new SqlParameter("@date_created", order.DateCreated));
                int lastInsertedId = Convert.ToInt32(command.ExecuteScalar());
                SqlCommand insertOrderItemCommand = new("INSERT INTO order_items (order_id, item_id, comments) VALUES (@order_id, @item_id, @comments)", connection);
                SqlCommand updateItemQuantity = new("UPDATE item SET quantity =@newQuantity WHERE id = @item_id", connection);
                foreach (OrderItem orderItem in orderItems)
                {
                    var item = items.Where(item => item.Id == orderItem.Item_id).FirstOrDefault();
                    if (item != null)
                    {
                        insertOrderItemCommand.Parameters.Add(new SqlParameter("@order_id", lastInsertedId));
                        insertOrderItemCommand.Parameters.Add(new SqlParameter("@item_id", item.Id));
                        insertOrderItemCommand.Parameters.Add(orderItem.Comments == null ?
                              new SqlParameter("@comments", DBNull.Value)
                            : new SqlParameter("@comments", orderItem.Comments));
                        if (insertOrderItemCommand.ExecuteNonQuery() != -1)
                        {
                            updateItemQuantity.Parameters.Add(new SqlParameter("@newQuantity", item.Quantiy));
                            updateItemQuantity.Parameters.Add(new SqlParameter("@item_id", item.Id));
                            updateItemQuantity.ExecuteNonQuery();
                            updateItemQuantity.Parameters.Clear();
                        }
                        insertOrderItemCommand.Parameters.Clear();
                    }
                }
                return lastInsertedId;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public static ObservableCollection<AdditionalItem> GetadditionalItemsName()
        {
            ObservableCollection<AdditionalItem> AdditionalItems = new()
            {
                new AdditionalItem() { Name = "Milk" ,IsSelected=true },
                new AdditionalItem() { Name = "Sugar" },
                new AdditionalItem() { Name = "Salt" },
                new AdditionalItem() { Name = "Cream" },
                new AdditionalItem() { Name = "Spicy" },
                new AdditionalItem() { Name = "Sauce" },
                new AdditionalItem() { Name = "Ice" },
                new AdditionalItem() { Name = "Tomotto" }
            };

            return AdditionalItems;
        }
    }
}
