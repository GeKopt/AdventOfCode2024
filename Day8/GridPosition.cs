using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class GridPosition
    {
        public bool IsAntiNode { get; set; }
        private char _antennaId;

        public bool IsEmpty => Value == '.';

        public char Value
        {
            get
            {
                if (_antennaId != '.')
                {
                    return _antennaId;
                }
                if (IsAntiNode)
                {
                    return '#';
                }
                return '.';
            }
        }

        public GridPosition(char value)
        {
            _antennaId = value;
            if (value == '#')
            {
                IsAntiNode = true;
            }
        }
    }
}
