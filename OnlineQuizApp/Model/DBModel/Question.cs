using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineQuizApp.Model.DBModel
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string QuizId { get; set; }

         public string Text { get; set; }

         public List<Option> Options { get; set; }

        // Internal use only, never sent to frontend
        [BsonRepresentation(BsonType.ObjectId)]
        public string CorrectOptionId { get; set; }
    }

    public class Option
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

         public string Text { get; set; }
    }
}
