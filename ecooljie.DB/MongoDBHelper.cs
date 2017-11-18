using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

using System.Reflection;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ecooljie.DB.MongoDB
{
    /*
    mongodb条件操作符，"$lt", "$lte", "$gt", "$gte", "$ne"就是全部的比较操作符，对应于"<", "<=", ">", ">=","!="。
    原子操作符："$and“, "$or“, "$nor“。
    or查询有两种方式：一种是用$in来查询一个键的多个值，另一种是用$or来完成多个键值的任意给定值。$in相当于SQL语句的in操作。
    $nin不属于。
    $not与正则表达式联合使用时候极其有用，用来查询哪些与特定模式不匹配的文档。
    $slice相当于数组函数的切片，检索一个数组文档并获取数组的一部分。限制集合中大量元素节省带宽。理论上可以通过 limit() 和 skip() 函数来实现，但是，对于数组就无能为力了。 $slice可以指定两个参数。第一个参数表示要返回的元素总数。第二个参数是可选的。如果使用的话，第一个参数定义的是偏移量，而第二个参数是限定的个数。第二个参数还可以指定一个负数。
    $mod取摸操作。
    $size操作符允许对结果进行筛选，匹配指定的元素数的数组。
    $exists操作符允许返回一个特定的对象。注意：当前版本$exists是无法使用索引的，因此，使用它需要全表扫描。
    $type操作符允许基于BSON类型来匹配结果。 
    */
    public class MongoDBHelper
    {
        public static readonly string connectionString = "mongodb://localhost:27017";
        public static readonly string database = "ecooljie";
        private static MongoClient conn
        {
            get
            {
                return new MongoClient(connectionString);
            }
        }
        /// <summary>  
        /// 数据库的实例  
        /// </summary>  
        private static IMongoDatabase db
        {
            get
            {
                return conn.GetDatabase(database);
            }
        }

        #region 新增
        /// <summary>
        /// 插入新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="entiry"></param>
        public static void InsertOne<T>(T entity)
        {        
            string collectionName = entity.GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            collection.InsertOne(entity);

        }
        /// <summary>
        /// 插入多个数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="entiry"></param>
        public static void InsertAll<T>(IEnumerable<T> entity)
        {
            string collectionName = entity.GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            collection.InsertMany(entity);
        }
        /// <summary>  
        /// 将数据插入进数据库  
        /// </summary>  
        /// <typeparam name="T">需要插入数据的类型</typeparam>  
        /// <param name="t">需要插入的具体实体</param>  
        public static bool Insert<T>(T entity)
        {
            //集合名称  
            string collectionName = entity.GetType().Name;
            return Insert<T>(entity, collectionName);
        }
        /// <summary>  
        /// 将数据插入进数据库  
        /// </summary>  
        /// <typeparam name="T">需要插入数据库的实体类型</typeparam>  
        /// <param name="t">需要插入数据库的具体实体</param>  
        /// <param name="collectionName">指定插入的集合</param>  
        public static bool Insert<T>(T t, string collectionName)
        {
            try
            {
                IMongoCollection<T> mc = db.GetCollection<T>(collectionName);
                //将实体转换为bson文档  
                //T bd = t.ToBsonDocument();
                //进行插入操作  
                mc.InsertOne(t);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>  
        /// 批量插入数据  
        /// </summary>  
        /// <typeparam name="T">需要插入数据库的实体类型</typeparam>  
        /// <param name="list">需要插入数据的列表</param>  
        /// <param name="collectionName">指定要插入的集合</param>  
        public bool Insert<T>(List<T> list)
        {
            try
            {
                string collectionName = nameof(T);
                IMongoCollection<BsonDocument> mc = db.GetCollection<BsonDocument>(collectionName);
                //创建一个空间bson集合  
                List<BsonDocument> bsonList = new List<BsonDocument>();
                //批量将数据转为bson格式 并且放进bson文档  
                list.ForEach(t => bsonList.Add(t.ToBsonDocument()));
                //批量插入数据  
                mc.InsertMany(bsonList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region 更新
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="entry">新实体</param>
        /// <param name="query">条件</param>
        public static void Update<T>(BsonDocument entity, UpdateDefinition<T> query)
        {
            string collectionName = entity.GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            collection.UpdateOne(entity, query);
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="entry">新实体</param>
        /// <param name="query">条件</param>
        public static void UpdateAll<T>(BsonDocument entity, BsonDocument query)
        {
            string collectionName = entity.GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            collection.UpdateOne(entity, query);
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName">表名</param>
        /// <param name="filter"></param>
        public static long DeleteOne<T>(FilterDefinition<T> filter)
        {
            string collectionName = typeof(T).Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            var result = collection.DeleteOne(filter);
            return result.DeletedCount;
        }
        /// <summary>
        /// 删除多个数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        public static long DeleteMany<T>(Expression<Func<T, bool>> func)
        {
            string collectionName = typeof(T).Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            var result = collection.DeleteMany(func);
            return result.DeletedCount;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <param name="primaryKeyName">主键字段名</param>
        /// <returns></returns>
        public static long DeleteMany<T>(List<string> ids,string primaryKeyName= null)
        {
            string collectionName = typeof(T).Name;
            List<WriteModel<T>> requests = new List<WriteModel<T>>();
            foreach (var id in ids)
            {
                var primaryKey = primaryKeyName ?? "_id";
                BsonDocument document = new BsonDocument(primaryKey, id);
               // DeleteOneModel<BsonDocument> dom = new DeleteOneModel<BsonDocument>(document);
                requests.Add(new DeleteOneModel<T>(document));
                
            }           
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            BulkWriteResult bulkWriteResult = collection.BulkWrite(requests);
           return bulkWriteResult.DeletedCount;

        }
        #endregion
        #region 查询

        public static T Find<T>(string collectionName, FilterDefinition<T> filter)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            return collection.Find(filter).FirstOrDefaultAsync().Result;
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Find<T>(FilterDefinition<T> filter, FindOptions fields)
        {
            string collectionName = nameof(T);
            T result = default(T);
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            result = collection.Find(filter, fields).Skip(0).Limit(1).First();
            return result;
        }
        public static List<T> QueryList<T>(FilterDefinition<T> filter)
        {
            string collectionName = nameof(T);
            //var s = collection.Find(filter).ForEachAsync(x => Console.WriteLine(""));
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            return collection.Find(filter).ToListAsync().Result;
        }

        /// <summary>
        /// 排序分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="func">  Expression<Func<Student,bool>> la =( n=>n.id > 1 && n.id <100 &&n.name !="张三" && n.matn >=60 && n.id != 50 && n.createTime != null);</param>
        /// <param name="RecordCount"></param>
        /// <param name="orderByString">排序如："id asc,name desc"</param>
        /// <returns></returns>
        public static List<T> QueryList<T>(int PageIndex, int PageSize, Expression<Func<T, bool>> func, out long RecordCount, string orderByString = null) where T:new()
        {
            //  Expression<Func<Student,bool>> la =( n=>n.id > 1 && n.id <100 &&n.name !="张三" && n.matn >=60 && n.id != 50 && n.createTime != null);
            string collectionName = new T().GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            if (func == null)
            {
                RecordCount = collection.Find(new BsonDocument()).Count();
            }
            else
            {
                RecordCount = collection.Find(func).Count();
            }

            //FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);
            //方法一：
            //return collection.AsQueryable<T>().Where(func).OrderByDescending(t => "_id").Skip(PageIndex * PageSize).Take(PageSize).ToList();

            // var s= db.GetCollection<T>(collectionName).Find(func).Skip(PageSize * (PageIndex - 1)).Limit(PageSize).ToList();
            //var sort2 = new BsonDocument{
            //                            {"$sort", new BsonDocument{ { "Code", 1 }}}
            //                            };
            List<SortDefinition<T>> sortDefList = new List<SortDefinition<T>>();
           
            if (orderByString != null)
            {// id asc,createtime desc
                var sortList = orderByString.Split(',');
                for (var i = 0; i < sortList.Length; i++)
                {
                    var sl = sortList[i].Trim().Split(' ');// System.Text.RegularExpressions.Regex.Replace(sortList[i].Trim(), @"\s+", " ").Split(' ');
                    if (sl.Length == 1 || (sl.Length >= 2 && sl[1].ToLower() == "asc"))
                    {
                        sortDefList.Add(Builders<T>.Sort.Ascending(sl[0]));
                    }
                    else if (sl.Length >= 2 && sl[1].ToLower() == "desc")
                    {
                        sortDefList.Add(Builders<T>.Sort.Descending(sl[0]));
                    }
                }
            }
            var sortBy = Builders<T>.Sort.Combine(sortDefList);
           
            //var sort = Builders<T>.Sort.Ascending("Code").Ascending("Name");
            if (func == null)
            {
                return collection.Find(new BsonDocument()).Sort(sortBy).Skip(PageSize * (PageIndex - 1)).Limit(PageSize).ToList();
            }
            else
            {
                return collection.Find(func).Sort(sortBy).Skip(PageSize * (PageIndex - 1)).Limit(PageSize).ToList();
            }
           
        }
        public static List<T> GetList<T>(int PageIndex, int PageSize, FilterDefinition<T> filter, out long RecordCount) where T : new()
        {
            //  Expression<Func<Student,bool>> la =( n=>n.id > 1 && n.id <100 &&n.name !="张三" && n.matn >=60 && n.id != 50 && n.createTime != null);
            string collectionName = new T().GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            RecordCount = collection.Find(filter).Count();

            // FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);

            return collection.Find(filter).Skip(PageSize * (PageIndex - 1)).Limit(PageSize).ToList();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private static List<T>GetByPaging<T>(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize) 
        {
           

            string collectionName = typeof(T).GetType().Name;
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            var data = collection.Find(predicate);
            var builder = Builders<T>.Filter;
            var filter = builder.Eq("cuisine", "Italian") & builder.Eq("address.zipcode", "10075");
            var result = collection.Find(filter).ToList();


            var sort = Builders<T>.Sort.Ascending("borough").Ascending("address.zipcode");
            var result2 = collection.Find(filter).Sort(sort).ToList();
            
            return result;
        }

        /// <summary>
        /// 查询一个集合中的所有数据 其集合的名称为T的名称  
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static List<T> FindAll<T>()
        {
            string collectionName = nameof(T);
            List<T> result = new List<T>();
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            result = collection.AsQueryable<T>().ToList<T>();
            return result;
        }
        public static async Task<List<T>> GetByFilter<T>(FilterDefinition<T> filter)
        {
            filter = filter ?? new BsonDocument();
            IMongoCollection<T> collection = db.GetCollection<T>(nameof(T));
            return await collection.Find(filter).ToListAsync();
        }


        public static async Task<List<T>> GetAll<T>()
        {
            IMongoCollection<T> collection = db.GetCollection<T>(nameof(T));
            return await collection.Find(new BsonDocument()).ToListAsync();
        }
        #endregion

    }
}
