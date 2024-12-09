using System.Collections.ObjectModel;

namespace Day7
{
    public class Calibration
    {
        public long Total { get; }
        public ReadOnlyCollection<long> Values { get; }

        public Calibration(long total, List<long> values)
        {
            Total = total;
            Values = new ReadOnlyCollection<long>(values);
        }
    }
}
