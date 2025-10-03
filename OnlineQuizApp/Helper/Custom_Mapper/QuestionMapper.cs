using OnlineQuizApp.Model.DBModel;
using OnlineQuizApp.Model.ViewModel;

namespace OnlineQuizApp.Helper.Custom_Mapper
{
    public class QuestionMapper
    {

        public QuestionMapper() { }

        public QuestionViewModel MapQuestionDBToViewModel(Question question)
        {
            return new QuestionViewModel
            {
                Id = question.Id,
                QuizId = question.QuizId,
                Text = question.Text,
                Options = (question?.Options) ?? new List<Option>()
            };
        }
    }
}
