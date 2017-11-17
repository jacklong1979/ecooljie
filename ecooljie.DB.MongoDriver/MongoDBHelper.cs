using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace ecooljie.DB.MongoDriver
{
    public class MongoDBHelper
    {
        public static readonly string connectionString = "Servers=127.0.0.1:27017;ConnectTimeout=30000;ConnectionLifetime=300000;MinimumPoolSize=8;MaximumPoolSize=256;Pooled=true";
        public static readonly string database = "Friends";
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
            string collectionName = nameof(T);
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
            string collectionName = nameof(T);
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            collection.InsertMany(entity);
        }
        /// <summary>  
        /// 将数据插入进数据库  
        /// </summary>  
        /// <typeparam name="T">需要插入数据的类型</typeparam>  
        /// <param name="t">需要插入的具体实体</param>  
        public static bool Insert<T>(T t)
        {
            //集合名称  
            string collectionName = nameof(T);
            return Insert<T>(t, collectionName);
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
        public static void Update<T>( BsonDocument entity, UpdateDefinition<T> query) 
        {
            string collectionName = nameof(T);
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
            string collectionName = nameof(T);
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
            string collectionName = nameof(T);
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            var result = collection.DeleteOne(filter);
           return result.DeletedCount;
        }
        /// <summary>
        /// 插入多个数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="filter"></param>
        public static long DeleteMany<T>(FilterDefinition<T> filter)
        {
            string collectionName = nameof(T);
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            var result= collection.DeleteMany(filter);
            return result.DeletedCount;
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
        public static T Find<T>( FilterDefinition<T> filter, FindOptions fields) 
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
        
       
        public List<T> QueryList<T>(int PageIndex, int PageSize, Expression<Func<T, bool>> func, out long RecordCount)
        {
            string collectionName = nameof(T);
            IMongoCollection<T> collection = db.GetCollection<T>(collectionName);
            RecordCount = collection.Find(func).Count();

            //方法一：
            return collection.AsQueryable<T>().Where(func).OrderByDescending(t => "_id").Skip(PageIndex * PageSize).Take(PageSize).ToList();
            
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
            result=collection.AsQueryable<T>().ToList<T>();
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
