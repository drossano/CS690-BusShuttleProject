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

    Stops = [new Stop("Music"), new Stop("Tower"), new Stop("Oakwood"), new Stop("Anthony"), new Stop("Letterman")];

    Loops[0].Stops.Add(Stops[0]);
    Loops[0].Stops.Add(Stops[1]);
    Loops[0].Stops.Add(Stops[2]);
    Loops[0].Stops.Add(Stops[3]);
    Loops[0].Stops.Add(Stops[4]);

    Drivers = [new Driver("Dean Rossano"), new Driver("Jane Doe")];

    PassengerData = [];
  }

  public void AddNewPassengerData(PassengerData data)
  {
    this.PassengerData.Add(data);
    this.fileSaver.AppendData(data);

  }
}