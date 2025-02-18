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
            .Title("What's next?")
            .AddChoices([
            "continue", "end"
            ]));
      } while (command != "end");
    }
    else if (mode == "manager")
    {
      string command;
      do
      {

        command = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("What do you want to do?")
            .AddChoices([
            "show busiest stop","add stop", "delete stop", "list stops", "end"
            ]));

        if (command == "add stop")
        {
          var newStopName = AnsiConsole.Prompt(new TextPrompt<string>("Enter new stop name:"));
          dataManager.AddStop(new Stop(newStopName));
        }
        else if (command == "delete stop")
        {
          Stop stopToDelete = AnsiConsole.Prompt(
          new SelectionPrompt<Stop>()
              .Title("Please select a stop to delete.")
              .AddChoices(dataManager.Stops
              ));
          dataManager.RemoveStop(stopToDelete);

        }
        else if (command == "list stops")
        {
          var stopsTable = new Table();
          stopsTable.AddColumn("Stop Name");
          foreach (var stop in dataManager.Stops)
          {
            stopsTable.AddRow(stop.Name);
          }
          AnsiConsole.Write(stopsTable);
        }
        else if (command == "show busiest stop")
        {
          var result = Reporter.FindBusiestStop(dataManager.PassengerData);
          Console.WriteLine("The busiest stop is: " + result.Name);
        }
      } while (command != "end");
    }
  }

}