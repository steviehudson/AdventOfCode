using AdventOfCode.Utilities;

namespace AdventOfCode
{
    public static class ParseSubmarineCommandsUtility
    {
        public static IList<SubmarineCommand> ParseCommands(IList<string> commands)
        {
            var submarineCommands = new List<SubmarineCommand>();
            foreach (var command in commands)
            {
                submarineCommands.Add(new SubmarineCommand
                {
                    Command = ParseCommand(command),
                    Unit = ParseUnitsUtility.ParseContainsUnit(command)
                });
            }
            return submarineCommands;
        }

        private static CommandEnum ParseCommand(string line)
        {
            switch (line)
            {
                case var _ when line.Contains("forward"): return CommandEnum.Forward;
                case var _ when line.Contains("down"): return CommandEnum.Down;
                case var _ when line.Contains("up"): return CommandEnum.Up;
                default: throw new Exception("Error parsing command");
            };
        }
    }
}
