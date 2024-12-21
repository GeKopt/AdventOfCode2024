namespace Day7
{
    public class Calibration
    {
        public long Total { get; }
        public List<long> Values { get; }

        public Calibration(long total, List<long> values)
        {
            Total = total;
            Values = values;
        }
    }
}
