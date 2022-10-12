namespace Homework
{
    public interface IStatisticService
    {
        void Add(Statistic item);
        List<Statistic> GetStatistic();
    }
}
