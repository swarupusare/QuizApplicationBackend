using MongoDB.Driver;
using OnlineQuizApp.DBContext;
using OnlineQuizApp.Model.DBModel;
using OnlineQuizApp.Repository.Interfaces;

namespace OnlineQuizApp.Repository.Implementation
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IMongoCollection<Question> _collection;
        public QuizRepository(QuizDBContext dbContext)
        {
            _collection = dbContext.GetCollection<Question>("Questions");
        }


        public async Task AddQuestionAsync(Question question)
        {
            await _collection.InsertOneAsync(question);
        }

        public async Task<List<Question>> GetAllQuestionsAsync(string quizId)
        {
             var questions=await _collection.Find(question=>question.QuizId == quizId).ToListAsync();

            return questions ?? new List<Question>();

        }
    }
}
