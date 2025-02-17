namespace BusShuttle;

public class DataManager
{
  FileSaver fileSaver;
  public List<Loop> Loops { get; }
  public List<Stop> Stops { get; }
  public List<Driver> Drivers { get; }
  public List<PassengerData> PassengerData { get; }

  public DataManager()
  {
    fileSaver = new FileSaver("passenger-data.txt");

    Loops = [new Loop("Red"), new Loop("Green"), new Loop("Blue")];

    Stops = [];
    var stopsFileContent = File.ReadAllLines("stops.txt");
    foreach (var stopName in stopsFileContent)
    {
      Stops.Add(new Stop(stopName));
    }

    foreach (var stop in Stops)
    {
      Loops[0].Stops.Add(stop);
    }

    Drivers = [new Driver("Dean Rossano"), new Driver("Jane Doe")];

    PassengerData = [];
  }

  public void AddNewPassengerData(PassengerData data)
  {
    this.PassengerData.Add(data);
    this.fileSaver.AppendData(data);

  }

  public void SyncStops()
  {
    File.Delete("stops.txt");
    foreach (var stop in Stops)
    {
      File.AppendAllText("stops.txt", stop.Name + Environment.NewLine);
    }
  }

  public void AddStop(Stop stop)
  {
    Stops.Add(stop);
    SyncStops();
  }

  public void RemoveStop(Stop stop)
  {
    Stops.Remove(stop);
    SyncStops();
  }
}