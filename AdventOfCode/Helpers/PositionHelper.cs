using AdventOfCode;

public static class PositionHelper
{
    private static int totalFowardUnits;
    private static int totalUpUnits;
    private static int totalDownUnits;
    private static int aimUnits;

    private static int OverallPositionWithoutAim => (totalDownUnits - totalUpUnits) * totalFowardUnits;
    private static int OverallPositionWithAim => totalDownUnits * totalFowardUnits;

    private static void Initialise()
    {
        totalFowardUnits = 0;
        totalUpUnits = 0;
        totalDownUnits = 0;
        aimUnits = 0;
    }

    public static int GetOverallPositionWithoutAim(IList<SubmarineCommand> parsedCommands)
    {
        Initialise();

        totalFowardUnits = CalculateTotalUnitsForPosition(parsedCommands, CommandEnum.Forward);
        totalUpUnits = CalculateTotalUnitsForPosition(parsedCommands, CommandEnum.Up);
        totalDownUnits = CalculateTotalUnitsForPosition(parsedCommands, CommandEnum.Down);

        return OverallPositionWithoutAim;
    }

    public static int GetOverallPositionWithAim(IList<SubmarineCommand> parsedCommands)
    {
        Initialise();

        totalFowardUnits = CalculateTotalUnitsForPosition(parsedCommands, CommandEnum.Forward);

        ProcessAim(parsedCommands);

        return OverallPositionWithAim;
    }

    private static int CalculateTotalUnitsForPosition(IList<SubmarineCommand> parsedCommands, CommandEnum direction)
    {
        return parsedCommands.Where(x => x.Command == direction).Select(y => y.Unit).Sum();
    }

    private static void ProcessAim(IList<SubmarineCommand> parsedCommands)
    {
        foreach (var command in parsedCommands)
        {
            _ = command.Command switch
            {
                CommandEnum.Down => aimUnits += command.Unit,
                CommandEnum.Up => aimUnits -= command.Unit,
                CommandEnum.Forward => totalDownUnits += (aimUnits * command.Unit),
                _ => throw new Exception("Error processing aim")
            };
        }
    }
}