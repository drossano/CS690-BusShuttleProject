namespace BusShuttle.Tests;

using BusShuttle;
public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;
    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);
    }


    [Fact]
    public void Test_FileSaver_Append()
    {
        fileSaver.AppendLine("Hello, World!");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, World!" + Environment.NewLine, contentFromFile);
    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {
        // Given
        Stop sampleStop = new("MyStop");
        Loop sampleLoop = new("MyLoop");
        Driver sampleDriver = new("MyDriver");
        PassengerData sampleData = new(5, sampleStop, sampleLoop, sampleDriver);
        // When
        fileSaver.AppendData(sampleData);
        // Then
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("MyDriver:MyLoop:MyStop:5" + Environment.NewLine, contentFromFile);
    }
}