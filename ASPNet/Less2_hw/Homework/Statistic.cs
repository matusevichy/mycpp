namespace Homework
{
    [Serializable]
    public class Statistic
    {
        public DateTime date { get; set; }
        public int trueAnswersCount{ get; set; }
        public int falseAnswersCount { get; set; }
        

        public Statistic()
        {
        }

        public Statistic(DateTime date, int trueAnswersCount, int falseAnswersCount)
        {
            this.date = date;
            this.trueAnswersCount = trueAnswersCount;
            this.falseAnswersCount = falseAnswersCount;
        }
    }
}
