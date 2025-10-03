using MongoDB.Driver;

namespace OnlineQuizApp.DBContext
{
    public class QuizDBContext
    {
        public IMongoDatabase Database { get; }

        public QuizDBContext(IMongoClient client, string databaseName)
        {
            if (string.IsNullOrEmpty(databaseName))
                throw new ArgumentNullException(nameof(databaseName));

            Database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Database.GetCollection<T>(collectionName);
        }
    }
}
