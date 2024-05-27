namespace Game_Deathroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.InitializeGame();
            controller.RunGame();
        }



        // Add options at end: "Repeat game or new game?"
    }
}
