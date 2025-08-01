using System;
using System.Runtime.CompilerServices;

namespace Day11
{
    public class Blinker
    {
        private Dictionary<long, long> _stones = new Dictionary<long, long>();

        public Blinker(List<long> stones)
        {
            foreach(var stone in stones)
            {
                UpdateStone(stone, 1);
            }
        }

        public long Blink(int amount)
        {
            var total = 0L;
            for (int index = 0; index < amount; index++)
            {
                total = Blink();
                Console.WriteLine("CURRENT " + total + " INDEX " + index);
            }
            return total;
        }

        public long Blink()
        {
            var currentStones = new Dictionary<long, long>(_stones);
            foreach(var currentStone in currentStones)
            {

                (long first, long second) stones = GetStones(currentStone);
                var amount = currentStone.Value;
                _stones[currentStone.Key]-= amount;
                UpdateStone(stones.first, amount);
                if (stones.second != -1)
                {
                    UpdateStone(stones.second, amount);
                        
                }
            }
            return _stones.Values.Sum();
        }

        private (long first, long second) GetStones(KeyValuePair<long, long> currentStone)
        {
            var stone = currentStone.Key;
            if (stone == 0)
            {
                return (1, -1);
            }
            var length = (stone > 0) ? (int)Math.Floor(Math.Log10(stone)) + 1 : 1;
            (long first, long second) stones;
            if ((length & 1) != 0)
            {
                stones = (stone * 2024, -1);
            }
            else
            {
                stones = SplitStone(stone, length);
            }

            return stones;
        }

        private (long first, long second) SplitStone(long stone, int length)
        {
            var half = length / 2;
            var divisor = 1;
            for (int i = 0; i < half; i++)
            {
                divisor *= 10;
            }
            var firstNumber = stone / divisor;
            var secondNumber = stone % divisor;
            return (firstNumber, secondNumber);
        }

        private void UpdateStone(long stone, long amount)
        {
            if (_stones.ContainsKey(stone))
            {
                _stones[stone]+= amount;
            }
            else
            {
                _stones.Add(stone, amount);
            }
        }

        //public int Blink()
        //{           
        //    var newStones = new List<long>();
        //    var numberOfStones = 0;
        //    foreach(long stone in _stones)
        //    {
        //        if (_seenStones.ContainsKey(stone))
        //        {
        //            var foundStone = _seenStones[stone];

        //            if (foundStone.second == -1)
        //            {
        //                newStones.Add(foundStone.first);
        //                numberOfStones++;
        //                continue;
        //            }
        //            newStones.AddRange([foundStone.first, foundStone.second]);
        //            numberOfStones += 2;
        //            continue;
        //        }
        //        var textualNumber = stone.ToString();
        //        var length = textualNumber.Length;
        //        if (length % 2 == 0)
        //        {
        //            var firstNumber = long.Parse(textualNumber.Substring(0, length / 2));
        //            var secondNumber = long.Parse(textualNumber.Substring(length / 2));
        //            var stones = new List<long> { firstNumber, secondNumber };
        //            _seenStones.Add(stone, (firstNumber, secondNumber));
        //            newStones.AddRange([firstNumber, secondNumber]);
        //            numberOfStones += 2;
        //            continue;
        //        }
        //        var newStone = stone * 2024;
        //        _seenStones.Add(stone, (newStone, -1));
        //        newStones.Add(newStone);
        //        numberOfStones++;
        //    }
        //    _stones = newStones;
        //    return numberOfStones;
        //}

        public string GetPrintedOrder()
        {
            return string.Join(" ", _stones.Select(stone => stone.ToString()));
        }
    }
}
