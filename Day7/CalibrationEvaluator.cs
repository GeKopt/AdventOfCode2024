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
                    if (copiedOption % 2 == (int)Operators.Add)
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

        public bool IsValidCalibrationWithConcatination(Calibration calibration)
        {
            if (calibration.Values.Sum() == calibration.Total || calibration.Values.Aggregate((first, second) => first * second) == calibration.Total)
            {
                return true;
            }

            var possibleOptions = Math.Pow(3, calibration.Values.Count);
            for (int currentOption = 0; currentOption < possibleOptions; currentOption++)
            {
                var calculated = 0L;
                var copiedOption = currentOption;
                var copiedCalibration = new Calibration(calibration.Total,new List<long>(calibration.Values));
                for (int currentValue = 0; currentValue < copiedCalibration.Values.Count; currentValue++)
                {
                    var operatorToUse = copiedOption % 3;

                    if (calculated > copiedCalibration.Total)
                    {
                        break;
                    }
                    switch (operatorToUse)
                    {
                        case (int)Operators.Add:
                            calculated += copiedCalibration.Values[currentValue];
                            break;
                        case (int)Operators.Multiply:
                            calculated *= copiedCalibration.Values[currentValue];
                            break;
                        case (int)Operators.Concat:
                            calculated = long.Parse(calculated.ToString() + copiedCalibration.Values[currentValue]);
                            break;
                    }
                    copiedOption /= 3;
                }
                if (calculated == copiedCalibration.Total)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
