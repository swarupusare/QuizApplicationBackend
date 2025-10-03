using OnlineQuizApp.Helper.Custom_Mapper;
using OnlineQuizApp.Model.DBModel;
using OnlineQuizApp.Model.ViewModel;
using OnlineQuizApp.Repository.Interfaces;
using OnlineQuizApp.Services.Interfaces;

namespace OnlineQuizApp.Services.Implementation
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly QuestionMapper _questionMapper;
        public QuizService(IQuizRepository quizRepository,QuestionMapper questionMapper) { 
            _quizRepository = quizRepository;
            _questionMapper = questionMapper;
        }

        public async Task AddQuestionAsync(Question question)
        {
              await _quizRepository.AddQuestionAsync(question);
        }

        public async Task<List<QuestionViewModel>> GetAllQuestionsAsync(string quizId)
        {
            var questionsInDB=await _quizRepository.GetAllQuestionsAsync(quizId);
             List<QuestionViewModel> result = new List<QuestionViewModel>();
            foreach (var question in questionsInDB)
            {
                var  questionViewModel= _questionMapper.MapQuestionDBToViewModel(question);
                result.Add(questionViewModel);
            }

            return result;
        }

        public async Task<ResultViewModel> GetResultAsync(string quizId, List<Answer> answers)
        {
            var questions = await _quizRepository.GetAllQuestionsAsync(quizId);

            Dictionary<string,string> questionAnsAns = new Dictionary<string,string>();
            foreach (var question in questions)
            {
                questionAnsAns.Add(question.Id, question.CorrectOptionId);   
            }
            List<AnswerViewModel> result = new List<AnswerViewModel>();
            var TotalCorrectAns = 0;
            foreach (var ans in answers)
            {
                var corretOptionId= questionAnsAns[ans.QuestionId!];
                var isCorrect = false;
                if(corretOptionId == ans.AnswerId)
                {
                    isCorrect = true;
                    ++TotalCorrectAns;
                }
                result.Add(new AnswerViewModel
                {
                    QuestionId=ans.QuestionId,
                    AnswerId=ans.AnswerId,
                    IsCorrect=isCorrect
                });
            }
            var totalQuestions = questions.Count;
            decimal percentage = totalQuestions > 0
                                ? Math.Round((TotalCorrectAns * 100m) / totalQuestions, 2)
                                : 0;
            return new ResultViewModel
            {
                CorrectAnswers = TotalCorrectAns,
                Percentage=percentage,
                Answers = result
            };

        }

    }
}
