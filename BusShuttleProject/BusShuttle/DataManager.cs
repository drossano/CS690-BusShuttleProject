using System.Windows.Markup;

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

    if (File.Exists("passenger-data.txt"))
    {
      var passengerFileContent = File.ReadAllLines("passenger-data.txt");
      foreach (var line in passengerFileContent)
      {
        var splitted = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
        var driverName = splitted[0];
        var driver = new Driver(driverName);

        var loopName = splitted[1];
        var loop = new Loop(loopName);

        var stopName = splitted[2];
        var stop = new Stop(stopName);

        var boarded = int.Parse(splitted[3]);

        PassengerData.Add(new PassengerData(boarded, stop, loop, driver));
      }
    }

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