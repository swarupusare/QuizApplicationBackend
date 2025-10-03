using OnlineQuizApp.Model.DBModel;
using OnlineQuizApp.Model.ViewModel;

namespace OnlineQuizApp.Services.Interfaces
{
    public interface IQuizService
    {
        Task AddQuestionAsync(Question question);
        Task<List<QuestionViewModel>> GetAllQuestionsAsync(string quizId);
        Task<ResultViewModel> GetResultAsync(string quizId, List<Answer> answers);
    }
}
