namespace Day7
{
    public class CalibrationEvaluator
    {
        public bool IsValidCalibration(Calibration calibration)
        {
            if (calibration.Values.Sum() == calibration.Total || calibration.Values.Aggregate((first, second) => first * second) == calibration.Total)
            {
                return true;
            }

            var possibleOptions = Math.Pow(2, calibration.Values.Count);
            for (int currentOption = 0; currentOption < possibleOptions; currentOption++)
            {
                var calculated = 0L;
                var copiedOption = currentOption;
                for (int currentValue = 0; currentValue < calibration.Values.Count; currentValue++)
                {
                    if (copiedOption % 2 == 1)
                    {
                        calculated += calibration.Values[currentValue];
                    }
                    else
                    {
                        calculated *= calibration.Values[currentValue];
                    }
                    copiedOption /= 2;
                }
                if (calculated == calibration.Total)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
