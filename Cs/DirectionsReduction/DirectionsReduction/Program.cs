var directionReducer = new DirectionReducer();
var result = directionReducer.ReduceDirections(new string[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"});
Array.ForEach(result, Console.WriteLine);
