using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Threading;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataAccess
{
    public class TestDapper
    {
        public static User TestQueryOne()
        {
            string UserId = "0491f966-fad3-401f-86d4-a64fbf008be0";
            string commandText = @" select * from t_user where UserId=@UserId";
            User user = DbHelp.QueryOne<User>(commandText, new { UserId = UserId }, null, false, null, System.Data.CommandType.Text);
            return user;
        }

        public static IEnumerable<User> TestQuery()
        {
            int year = 2015;
            int month = 3;
            string commandText = @"SELECT 
                                        *
                                    FROM
                                        t_user
                                    where
                                        DATE_FORMAT(CreatedTime, '%Y') = @Year
                                            and DATE_FORMAT(CreatedTime, '%m') = @Month";
            IEnumerable<User> users = DbHelp.Query<User>(commandText, new { Year = year, Month = month }, null, false, null, System.Data.CommandType.Text);
            return users;
        }
        public static void TestQuery2()
        {
            string selectText = "select 1 A, 2 B union all select 3, 4";
            var rows = DbHelp.Query(selectText);

            var r1 = rows.ElementAt(0);
            var r2 = rows.ElementAt(1);
        }

        /// <summary>
        /// 使用异步
        /// </summary>
        public static void TestBasicStringUsageAsync()
        {
            var query = DbHelp.QueryAsync<string>("select 'abc' as Value union all select @txt", new { txt = "def" });
            var arr = query.Result.ToArray();
            arr.IsSequenceEqualTo(new[] { "abc", "def" });
        }

        /// <summary>
        /// 将会抛出异常 NonBuffered
        /// Invalid attempt to Read when reader is closed.
        /// </summary>
        public static void TestBasicStringUsageAsyncNonBuffered()
        {
            var query = DbHelp.QueryAsync<string>(new CommandDefinition("select 'abc' as Value union all select @txt", new { txt = "def" }, flags: CommandFlags.None));
            var arr = query.Result.ToArray();
            arr.IsSequenceEqualTo(new[] { "abc", "def" });
        }

        /// <summary>
        /// Buffered
        /// 不会抛出异常
        /// </summary>
        public static void TestBasicStringUsageAsyncBuffered()
        {
            var query = DbHelp.QueryAsync<string>(new CommandDefinition("select 'abc' as Value union all select @txt", new { txt = "def" }, flags: CommandFlags.Buffered));
            var arr = query.Result.ToArray();
            arr.IsSequenceEqualTo(new[] { "abc", "def" });
        }
        /// <summary>
        /// Pipelined
        /// Invalid attempt to Read when reader is closed.
        /// </summary>
        public static void TestBasicStringUsageAsyncPipelined()
        {
            var query = DbHelp.QueryAsync<string>(new CommandDefinition("select 'abc' as Value union all select @txt", new { txt = "def" }, flags: CommandFlags.Pipelined));
            var arr = query.Result.ToArray();
            arr.IsSequenceEqualTo(new[] { "abc", "def" });
        }

        /// <summary>
        /// 测试长操作的取消，若操作时间过长，则取消
        /// </summary>
        public static void TestLongOperationWithCancellation()
        {
            using (var connection = DbConnectionFactory.Instance.GetClosedConnection())
            {
                CancellationTokenSource cancel = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                var task = connection.QueryAsync<string>(new CommandDefinition("select 'abc' as Value", cancellationToken: cancel.Token));
                try
                {
                    if (!task.Wait(TimeSpan.FromSeconds(7)))
                    {
                        throw new TimeoutException(); // should have cancelled
                    }
                    else
                    {
                        System.Console.WriteLine(task.Result.Single());
                    }
                }
                catch (AggregateException agg)
                {
                    (agg.InnerException is SqlException).IsTrue();
                }
            }
        }

        #region 异步查询 - 指定不同的泛型类型
        /// <summary>
        /// 异步查询 - 泛型为 string
        /// </summary>
        public static void TestBasicStringUsageClosedAsync()
        {
            using (var connection = DbConnectionFactory.Instance.GetClosedConnection())
            {
                var query = connection.QueryAsync<string>("select 'abc' as Value union all select @txt", new { txt = "def" });
                var arr = query.Result.ToArray();
                arr.IsSequenceEqualTo(new[] { "abc", "def" });
            }
        }

        /// <summary>
        /// 异步查询 - 不指定泛型
        /// </summary>
        public static void TestQueryDynamicAsync()
        {
            using (var connection = DbConnectionFactory.Instance.GetClosedConnection())
            {
                var row = connection.QueryAsync("select 'abc' as Value").Result.Single();
                string value = row.Value;
                value.IsEqualTo("abc");
            }
        }

        /// <summary>
        /// 异步查询 - 泛型为自定义类
        /// </summary>
        public static void TestClassWithStringUsageAsync()
        {
            using (var connection = DbConnectionFactory.Instance.GetOpenConnection())
            {
                var query = connection.QueryAsync<BasicType>("select 'abc' as [Value] union all select @txt", new { txt = "def" });
                var arr = query.Result.ToArray();
                arr.Select(x => x.Value).IsSequenceEqualTo(new[] { "abc", "def" });
            }
        }

        #endregion

        #region 把查询结果映射为对象
        /// <summary>
        /// 把查询结果映射为对象 - 多映射
        /// </summary>
        public static void TestMultiMapWithSplitAsync()
        {
            var sql = @"select 1 as id, 'abc' as name, 2 as id, 'def' as name";
            using (var connection = DbConnectionFactory.Instance.GetOpenConnection())
            {
                // QueryAsync<Product, Category, Product> 前两个是输入参数类型，第三个是返回类型，
                // 因为 Category 是 Product 的一个属性
                var productQuery = connection.QueryAsync<Product, Category, Product>(sql, (prod, cat) =>
                {
                    prod.Category = cat;
                    return prod;
                });

                var product = productQuery.Result.First();
                // assertions
                product.Id.IsEqualTo(1);
                product.Name.IsEqualTo("abc");
                product.Category.Id.IsEqualTo(2);
                product.Category.Name.IsEqualTo("def");
            }
        }

        /// <summary>
        /// 多映射 - 任意多映射
        /// </summary>
        public static void TestMultiMapArbitraryWithSplitAsync()
        {
            var sql = @"select 1 as id, 'abc' as name, 2 as id, 'def' as name";
            using (var connection = DbConnectionFactory.Instance.GetOpenConnection())
            {
                var productQuery = connection.QueryAsync<Product>(sql, new[] { typeof(Product), typeof(Category) }, (objects) =>
                {
                    var prod = (Product)objects[0];
                    prod.Category = (Category)objects[1];
                    return prod;
                });

                var product = productQuery.Result.First();
                // assertions
                product.Id.IsEqualTo(1);
                product.Name.IsEqualTo("abc");
                product.Category.Id.IsEqualTo(2);
                product.Category.Name.IsEqualTo("def");
            }
        }

        public static void TestMultiMapWithSplitClosedConnAsync()
        {
            var sql = @"select 1 as id, 'abc' as name, 2 as id, 'def' as name";
            using (var connection = DbConnectionFactory.Instance.GetClosedConnection())
            {
                // 输入 Product 和 Category 类型，返回 Product 类型
                var productQuery = connection.QueryAsync<Product, Category, Product>(sql, (prod, cat) =>
                {
                    prod.Category = cat;
                    return prod;
                });

                var product = productQuery.Result.First();
                // assertions
                product.Id.IsEqualTo(1);
                product.Name.IsEqualTo("abc");
                product.Category.Id.IsEqualTo(2);
                product.Category.Name.IsEqualTo("def");
            }
        }
        #endregion

        #region 多个查询
        /// <summary>
        /// 多个查询
        /// </summary>
        public static void TestMultiAsync()
        {
            using (var conn = DbConnectionFactory.Instance.GetOpenConnection())
            {
                using (Dapper.SqlMapper.GridReader multi = conn.QueryMultipleAsync("select 1; select 2").Result)
                {
                    multi.ReadAsync<Int64>().Result.Single().IsEqualTo(1);
                    multi.ReadAsync<Int64>().Result.Single().IsEqualTo(2);
                }
            }
        }

        /// <summary>
        /// 多个查询
        /// </summary>
        public static void TestMultiClosedConnAsync()
        {
            using (var conn = DbConnectionFactory.Instance.GetClosedConnection())
            {
                using (Dapper.SqlMapper.GridReader multi = conn.QueryMultipleAsync("select 1; select 2").Result)
                {
                    multi.ReadAsync<int>().Result.Single().IsEqualTo(1);
                    multi.ReadAsync<int>().Result.Single().IsEqualTo(2);
                }
            }
        }
        #endregion

        /// <summary>
        /// ExecuteReaderAsync 执行结果加载到 DataTable
        /// </summary>
        public static void ExecuteReaderOpenAsync()
        {
            using (var conn = DbConnectionFactory.Instance.GetOpenConnection())
            {
                var dt = new DataTable();
                dt.Load(conn.ExecuteReaderAsync("select 3 as three, 4 as four").Result);
                dt.Columns.Count.IsEqualTo(2);
                dt.Columns[0].ColumnName.IsEqualTo("three");
                dt.Columns[1].ColumnName.IsEqualTo("four");
                dt.Rows.Count.IsEqualTo(1);
                ((Int64)dt.Rows[0][0]).IsEqualTo(3);
                ((Int64)dt.Rows[0][1]).IsEqualTo(4);
            }
        }

        #region
        /// <summary>
        /// 异步执行参数化的 SQL
        /// </summary>
        public static void RunSequentialVersusParallelAsync()
        {
            var ids = Enumerable.Range(1, 20000).Select(id => new { id }).ToArray();
            using (var connection = DbConnectionFactory.Instance.GetOpenConnection())
            {
                connection.ExecuteAsync(new CommandDefinition("select @id", ids.Take(5), flags: CommandFlags.None)).Wait();

                var watch = Stopwatch.StartNew();
                connection.ExecuteAsync(new CommandDefinition("select @id", ids, flags: CommandFlags.None)).Wait();
                watch.Stop();
                System.Console.WriteLine("No pipeline: {0}ms", watch.ElapsedMilliseconds);

                watch = Stopwatch.StartNew();
                connection.ExecuteAsync(new CommandDefinition("select @id", ids, flags: CommandFlags.Pipelined)).Wait();
                watch.Stop();
                System.Console.WriteLine("Pipeline: {0}ms", watch.ElapsedMilliseconds);
            }
        }
        /// <summary>
        /// 同步执行参数的 SQL
        /// </summary>
        public static void RunSequentialVersusParallelSync()
        {
            var ids = Enumerable.Range(1, 20000).Select(id => new { id }).ToArray();
            using (var connection = DbConnectionFactory.Instance.GetOpenConnection())
            {
                connection.Execute(new CommandDefinition("select @id", ids.Take(5), flags: CommandFlags.None));

                var watch = Stopwatch.StartNew();
                connection.Execute(new CommandDefinition("select @id", ids, flags: CommandFlags.None));
                watch.Stop();
                System.Console.WriteLine("No pipeline: {0}ms", watch.ElapsedMilliseconds);

                watch = Stopwatch.StartNew();
                connection.Execute(new CommandDefinition("select @id", ids, flags: CommandFlags.Pipelined));
                watch.Stop();
                System.Console.WriteLine("Pipeline: {0}ms", watch.ElapsedMilliseconds);
            }
        }
        #endregion

        /// <summary>
        /// 只选择一个值
        /// </summary>
        public static void ExecuteScalar()
        {
            using (var connection = DbConnectionFactory.Instance.GetOpenConnection())
            {
                int i = connection.ExecuteScalarAsync<int>("select 123").Result;
                i.IsEqualTo(123);

                //i = connection.ExecuteScalarAsync<int>("select cast(123 as bigint)").Result;
                //i.IsEqualTo(123);

                long j = connection.ExecuteScalarAsync<long>("select 123").Result;
                j.IsEqualTo(123L);

                //j = connection.ExecuteScalarAsync<long>("select cast(123 as bigint)").Result;
                //j.IsEqualTo(123L);

                int? k = connection.ExecuteScalar<int?>("select @i", new { i = default(int?) });
                k.IsNull();
            }
        }

    }
}
