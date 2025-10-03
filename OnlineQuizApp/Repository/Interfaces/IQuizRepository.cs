using OnlineQuizApp.Model.DBModel;

namespace OnlineQuizApp.Repository.Interfaces
{
    public interface IQuizRepository
    {
        Task AddQuestionAsync(Question question);
        Task<List<Question>> GetAllQuestionsAsync(string quizId);
    }
}
