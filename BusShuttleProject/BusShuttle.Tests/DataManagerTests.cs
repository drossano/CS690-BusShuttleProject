namespace BusShuttle.Tests;

using BusShuttle;

public class DataManagerTests
{
  DataManager dataManager;

  public DataManagerTests()
  {
    File.WriteAllText("stops.txt", "One" + Environment.NewLine + "Two" + Environment.NewLine + "Three" + Environment.NewLine + "Four" + Environment.NewLine + "Five");
    dataManager = new DataManager();
  }

  [Fact]
  public void Test_AddStop()
  {
    // Given
    Assert.Equal(5, dataManager.Stops.Count);
    // When
    dataManager.AddStop(new Stop("Six"));
    // Then
    Assert.Equal(6, dataManager.Stops.Count);
  }
}