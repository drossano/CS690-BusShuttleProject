namespace BusShuttle;

using Spectre.Console;
public class ConsoleUI
{
  DataManager dataManager;


  public ConsoleUI()
  {
    dataManager = new DataManager();
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
          .AddChoices(dataManager.Drivers
          ));
      Console.WriteLine("Current Driver: " + selectedDriver);

      Loop selectedLoop = AnsiConsole.Prompt(
      new SelectionPrompt<Loop>()
          .Title("Please select a loop.")
          .AddChoices(dataManager.Loops
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

        int boarded = AnsiConsole.Prompt(
          new TextPrompt<int>("How many boarded?")
        );

        PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);


        dataManager.AddNewPassengerData(data);

        command = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Please select mode")
            .AddChoices([
            "end", "continue"
            ]));
      } while (command != "end");
    }
  }

}
