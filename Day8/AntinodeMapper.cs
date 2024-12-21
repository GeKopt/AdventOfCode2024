using System.Drawing;

namespace Day8
{
    public class AntinodeMapper
    {
        private Map _map;
        private bool _useResonation;

        public AntinodeMapper(Map map, bool useResonation)
        {
            _map = map;
            _useResonation = useResonation;
        }

        public void MapAntinodes()
        {
            for (int rowIndex = 0; rowIndex < _map.Positions.GetLength(1); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < _map.Positions.GetLength(0); columnIndex++)
                {
                    if (!_map.Positions[columnIndex, rowIndex].IsEmpty && _map.Positions[columnIndex, rowIndex].Value != Map.Antinode)
                    {
                        var current = new Point(columnIndex, rowIndex);
                        var antennas = _map.GetAntennaPositions(_map.Positions[columnIndex, rowIndex].Value);
                        antennas.Remove(current);
                        foreach (var antenna in antennas)
                        {
                            var antiNodePositions = GetAntinodePositions(current, antenna);
                            if (_useResonation && antiNodePositions.Any())
                            {
                                _map.AddAntinode(current);
                                _map.AddAntinode(antenna);
                            }
                            foreach (var antennaNodePosition in antiNodePositions)
                            {
                                _map.AddAntinode(antennaNodePosition);
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<Point> GetAntinodePositions(Point firstNode, Point secondNode)
        {
            var differenceX = firstNode.X - secondNode.X;
            var differenceY = firstNode.Y - secondNode.Y;
            var difference = new Size(differenceX, differenceY);
            bool keepSearching = true;
            bool isGoingBack = firstNode.X <= secondNode.X || firstNode.Y <= secondNode.Y;
            while (keepSearching)
            {
                if (isGoingBack)
                {
                    firstNode = Point.Add(firstNode, difference);
                    secondNode = Point.Subtract(secondNode, difference);
                }
                else
                {
                    firstNode = Point.Add(firstNode, difference);
                    secondNode = Point.Subtract(secondNode, difference);
                }

                yield return firstNode;
                yield return secondNode;
                keepSearching = _useResonation && !(_map.IsOutOfBounds(firstNode) && _map.IsOutOfBounds(secondNode));
            }
        }
    }
}
