using System.Runtime.CompilerServices;
using System.Text;

public static class Utilities
{
    public static void PrintList<T>(this List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

public class Traffic
{
    public Traffic()
    {
        Cars = new List<Car>();
    }
    public Traffic(List<Car> carsInTraffic)
    {
        Cars = carsInTraffic;
    }

    public List<Car> Cars { get; } = new();
    public bool AnyCarsInTraffic => Cars.Any();

    public Car MoveCarFromFront()
    {
        if (Cars.Any())
        {
            var carAtFront = Cars.First();
            Cars.Remove(carAtFront);
            return carAtFront;
        }
        else
        {
            throw new InvalidOperationException("No cars currently in traffic.");
        }
    }

    // This is required as junctions are always on the left
    public Car MoveCarFromBack()
    {
        if (Cars.Any())
        {
            var carAtBack = Cars.Last();
            Cars.Remove(carAtBack);
            return carAtBack;
        }
        else
        {
            throw new InvalidOperationException("No cars currently in traffic.");
        }
    }

    public void JoinTraffic(Car car)
    {
        Cars.Add(car);
    }


    public void JoinTrafficFromSidestreet(Junction junction, Car carGivingWay)
    {
        carGivingWay.GiveWay(junction);
        Cars.Insert(junction.SideStreet.RoadPosition, junction.SideStreet.Traffic.MoveCarFromBack());
    }
}

public class Car
{
    public Car(char id)
    {
        Id = id;
    }
    public char Id { get; private set; }
    public HashSet<int> JunctionPositionsGivenWayAt { get; } = new HashSet<int>();

    public void GiveWay(Junction junction)
    {
        JunctionPositionsGivenWayAt.Add(junction.RoadPosition);
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}

public class SideStreet
{
    public SideStreet(int roadPosition)
    {
        RoadPosition = roadPosition;
    }

    public Traffic Traffic { get; set; } = new Traffic();
    public int RoadPosition { get; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var car in Traffic.Cars)
        {
            builder.AppendLine(car.ToString());
        }
        return builder.ToString();
    }
}

public class Junction
{
    public Junction(Road mainRoad, SideStreet sideStreet)
    {
        MainRoad = mainRoad;
        SideStreet = sideStreet;
        RoadPosition = sideStreet.RoadPosition;
    }

    public Road MainRoad { get; }
    public SideStreet SideStreet { get; }
    public int RoadPosition { get; }


    public bool CarsWaiting => SideStreet.Traffic.AnyCarsInTraffic;

    public bool IsCarAtJunction(int position)
    {
        return SideStreet.RoadPosition == position;
    }

}

public class Road
{
    public Road(string mainRoadTraffic, string[] sideStreetTraffic)
    {
        RoadSize = mainRoadTraffic.Length;
        foreach (var carId in mainRoadTraffic)
        {
            Traffic.JoinTraffic(new Car(carId));
        }

        for (int i = 0; i < sideStreetTraffic.Length; i++)
        {
            var currentStreet = sideStreetTraffic[i];
            if (string.IsNullOrEmpty(currentStreet))
                continue;
            var sideStreet = new SideStreet(i);
            foreach (var carId in currentStreet)
            {
                sideStreet.Traffic.JoinTraffic(new Car(carId));
            }
            SideStreets.Add(sideStreet);
        }

        Junctions = SideStreets.Select(sideStreet => new Junction(this, sideStreet)).ToList();
    }
    private const char MainCar = 'X';
    public Traffic Traffic { get; } = new Traffic();
    public List<SideStreet> SideStreets { get; } = new List<SideStreet>();
    public List<Junction> Junctions { get; } = new List<Junction>();
    public int RoadSize { get; }
    public int TrafficLevel => Traffic.Cars.Count;
    /// <summary>
    /// Returns a string listing the cars in the order they exit the road.
    /// </summary>
    public string SimulateTraffic()
    {
        StringBuilder carsExitingRoad = new StringBuilder();

        while (Traffic.AnyCarsInTraffic)
        {
            var carMoved = true;

            while (carMoved)
            {
                if (Traffic.Cars.Count > 0)
                {
                    var carExitingRoad = Traffic.MoveCarFromFront().Id;
                    carsExitingRoad.Append(carExitingRoad);
                    if (carExitingRoad == MainCar)
                        return carsExitingRoad.ToString();
                }

                carMoved = HandleJunctionTraffic();
            }
        }

        return carsExitingRoad.ToString();
    }

    private bool HandleJunctionTraffic()
    {
        for (int i = 0; i < Traffic.Cars.Count; i++)
        {
            var car = Traffic.Cars[i];
            var junction = GetJunctionAtPosition(i);

            if (junction != null &&
                junction.CarsWaiting &&
                TrafficLevel < RoadSize &&
                !car.JunctionPositionsGivenWayAt.Contains(junction.RoadPosition))
            {
                car.GiveWay(junction);
                Traffic.JoinTrafficFromSidestreet(junction, car);
                return true;
            }
        }
        return false;
    }

    private Junction GetJunctionAtPosition(int position) => Junctions.FirstOrDefault(junction => junction.IsCarAtJunction(position));
}
