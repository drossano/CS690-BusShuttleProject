namespace BusShuttle;

using Spectre.Console;
public class ConsoleUI
{
  FileSaver fileSaver;

  List<Loop> loops;

  List<Stop> stops;

  List<Driver> drivers;


  public ConsoleUI()
  {
    fileSaver = new FileSaver("passenger-data.txt");

    loops = [new Loop("Red"), new Loop("Green"), new Loop("Blue")];

    stops = [new Stop("Music"), new Stop("Tower"), new Stop("Oakwood"), new Stop("Anthony"), new Stop("Letterman")];

    loops[0].Stops.Add(stops[0]);
    loops[0].Stops.Add(stops[1]);
    loops[0].Stops.Add(stops[2]);
    loops[0].Stops.Add(stops[3]);
    loops[0].Stops.Add(stops[4]);

    drivers = [new Driver("Dean Rossano"), new Driver("Jane Doe")];
  }
  public void Show()
  {

    var mode = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Please select mode")
        .AddChoices(new[] {
            "driver", "manager"
        }));

    if (mode == "driver")
    {

      Driver selectedDriver = AnsiConsole.Prompt(
      new SelectionPrompt<Driver>()
          .Title("Please select a driver.")
          .AddChoices(drivers
          ));
      Console.WriteLine("Current Driver: " + selectedDriver);

      Loop selectedLoop = AnsiConsole.Prompt(
      new SelectionPrompt<Loop>()
          .Title("Please select a loop.")
          .AddChoices(loops
          ));

      Console.WriteLine("You selected " + selectedLoop);


      string command;

      do
      {
        Stop selectedStop = AnsiConsole.Prompt(
        new SelectionPrompt<Stop>()
            .Title("Please select a loop.")
            .AddChoices(selectedLoop.Stops
            ));
        Console.WriteLine("You selected " + selectedStop);

        int boarded = int.Parse(AskForInput("Enter the number of boarded passengers: "));

        PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);


        fileSaver.AppendData(data);

        command = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Please select mode")
            .AddChoices(new[] {
            "end", "continue"
            }));
      } while (command != "end");
    }
  }


  public static string AskForInput(string message)
  {
    Console.Write(message);
    return Console.ReadLine();
  }
}
