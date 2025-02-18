namespace BusShuttle.Tests;

using BusShuttle;

public class ReporterTests
{
  List<PassengerData> sampleDataList;

  public ReporterTests()
  {
    sampleDataList = [];
  }

  [Fact]
  public void Test_FindBusiestStop_2Stops()
  {
    // Given
    Stop sampleStop = new("MyStop");
    Loop sampleLoop = new("MyLoop");
    Driver sampleDriver = new("MyDriver");
    PassengerData sampleData = new(5, sampleStop, sampleLoop, sampleDriver);
    sampleDataList.Add(sampleData);
    Stop sampleStop2 = new("MyStop2");
    PassengerData sampleData2 = new(6, sampleStop2, sampleLoop, sampleDriver);
    sampleDataList.Add(sampleData2);
    // When

    // Then
    var result = Reporter.FindBusiestStop(sampleDataList);
    Assert.Equal("MyStop2", result.Name);

  }

  [Fact]
  public void FindBusiestStop_2Stops_MoreData()
  {
    // Given
    sampleDataList.Add(new PassengerData(4, new Stop("MyStop"), new Loop("MyLoop"), new Driver("MyDriver")));
    sampleDataList.Add(new PassengerData(5, new Stop("MyStop2"), new Loop("MyLoop2"), new Driver("MyDriver2")));
    sampleDataList.Add(new PassengerData(2, new Stop("MyStop"), new Loop("MyLoop"), new Driver("MyDriver")));
    // When

    // Then
    var result = Reporter.FindBusiestStop(sampleDataList);
    Assert.Equal("MyStop", result.Name);
  }

}