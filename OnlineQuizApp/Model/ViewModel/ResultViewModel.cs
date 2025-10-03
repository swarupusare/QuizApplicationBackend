namespace OnlineQuizApp.Model.ViewModel
{
    public class ResultViewModel
    {
        public int CorrectAnswers { get; set; }

        public decimal Percentage { get; set; }
        public List<AnswerViewModel> Answers { get; set; } = new List<AnswerViewModel>();
    }
}
