using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using OnlineQuizApp.Model.DBModel;

namespace OnlineQuizApp.Model.ViewModel
{
    public class QuestionViewModel
    {
       
        public string Id { get; set; }

        
        public string QuizId { get; set; }

        public string Text { get; set; }

        public List<Option> Options { get; set; }

     }

     
}
