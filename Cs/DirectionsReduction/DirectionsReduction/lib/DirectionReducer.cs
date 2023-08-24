public class DirectionReducer
{
    public string[] ReduceDirections(string[] directionsString)
    {
        List<Direction> directions = ConvertToDirections(directionsString);
        List<Direction> reducedDirections = ReduceDirections(directions);
        return ConvertToStrings(reducedDirections).ToArray();
    }
    public List<Direction> ReduceDirections(List<Direction> directions)
    {
        var previousDirection = Direction.Undefined;
        for (int i = 0; i < directions.Count; i++)
        {
            Direction direction = directions[i];
            if (DirectionsOpposite(direction, previousDirection))
            {
                directions.RemoveRange(i - 1, 2);
                return ReduceDirections(directions);
            }
            previousDirection = direction;
        }
        return directions;
    }
    public enum Direction
    {
        Undefined,
        North,
        East,
        South,
        West
    }
    private static bool DirectionsOpposite(Direction direction1, Direction direction2)
    {
        return direction1 switch
        {
            Direction.North => direction2 == Direction.South,
            Direction.East => direction2 == Direction.West,
            Direction.South => direction2 == Direction.North,
            Direction.West => direction2 == Direction.East,
            _ => false,
        };
    }
    private static List<Direction> ConvertToDirections(string[] directionsStr)
    {
        return directionsStr.Select(dir => Enum.TryParse(dir, true, out Direction parsedDirection) ? parsedDirection : Direction.Undefined).ToList();
    }

    private static IEnumerable<string> ConvertToStrings(List<Direction> directions)
    {
        return directions.Select(dir => dir.ToString().ToUpper());
    }
}
