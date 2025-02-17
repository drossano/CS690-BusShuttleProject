namespace BusShuttle;

public class Stop(string name)
{
  public string Name { get; } = name;

  public override string ToString()
  {
    return this.Name;
  }
}

public class Driver(string name)
{
  public string Name { get; } = name;

  public override string ToString()
  {
    return this.Name;
  }
}

public class Loop(string name)
{
  public string Name { get; } = name;

  public List<Stop> Stops { get; } = [];

  public override string ToString()
  {
    return this.Name;
  }
}

public class PassengerData
{
  public int Boarded { get; }
  public Stop Stop { get; }
  public Loop Loop { get; }
  public Driver Driver { get; }

  public PassengerData(int boarded, Stop stop, Loop loop, Driver driver)
  {
    this.Boarded = boarded;
    this.Stop = stop;
    this.Loop = loop;
    this.Driver = driver;
  }
}