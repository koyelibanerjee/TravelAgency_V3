using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDBDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Mongo()
        {
            //建立连接
            var client = new MongoClient();
            //建立数据库
            var database = client.GetDatabase("TestDb");
            //建立collection
            var collection = database.GetCollection<BsonDocument>("foo");

            var document = new BsonDocument
            {
                {"name","MongoDB"},
                {"type","Database"},
                {"count",1},
                {"info",new BsonDocument{{"x",203},{"y",102}}}
            };
            //插入数据
            collection.InsertOne(document);

            var count = collection.Count(document);
            Console.WriteLine(count);

            //查询数据
            var document1 = collection.Find(document);
            Console.WriteLine(document1.ToString());

            //更新数据
            var filter = Builders<BsonDocument>.Filter.Eq("name", "MongoDB");
            var update = Builders<BsonDocument>.Update.Set("name", "Ghazi");

            collection.UpdateMany(filter, update);

            //删除数据
            var filter1 = Builders<BsonDocument>.Filter.Eq("count", 101);

            collection.DeleteMany(filter1);
            //collection.DeleteMany()
            BsonDocument document2 = new BsonDocument();
            document2.Add("name", "MongoDB");
            document2.Add("type", "Database");
            document2.Add("count", "1");
            collection.Find()
            collection.InsertOne(document2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mongo();
        }
    }
}
