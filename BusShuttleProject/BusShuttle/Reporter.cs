namespace BusShuttle
{
  public class Reporter
  {
    public static Dictionary<string, int> GetStopTotals(List<PassengerData> data)
    {
      Dictionary<string, int> stopPassengercount = [];

      foreach (var item in data)
      {
        if (!stopPassengercount.ContainsKey(item.Stop.Name))
        {
          stopPassengercount.Add(item.Stop.Name, item.Boarded);
        }
        else
        {
          stopPassengercount[item.Stop.Name] += item.Boarded;
        }
      }
      return stopPassengercount;
    }

    public static Stop FindBusiestStop(List<PassengerData> data)
    {
      Dictionary<string, int> totals = GetStopTotals(data);
      string busiestStop = "";

      int busiest = -1;

      foreach (var stopCountPair in totals)
      {
        if (stopCountPair.Value > busiest)
        {
          busiestStop = stopCountPair.Key;
          busiest = stopCountPair.Value;
        }
      }
      return new Stop(busiestStop);
    }
  }



}