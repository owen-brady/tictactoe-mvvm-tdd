namespace BetterTicTacToe.Services
{
    public interface IConsoleWrapper
    {
        void WriteLine(string output);
        void Write(string output);
        string GetInput();
    }
}