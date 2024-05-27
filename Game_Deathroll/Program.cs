namespace Game_Deathroll
{
    internal class Program
    {
        Controller controller = new Controller();
        int gameState = 2;
        static void Main(string[] args)
        {
            Program ThisIsTheGame = new Program();
            do
            {
                if (ThisIsTheGame.gameState == 2)
                {
                    ThisIsTheGame.controller.InitializeGame();
                    ThisIsTheGame.gameState--;
                }
                else
                {
                    ThisIsTheGame.controller.RunGame();
                    ThisIsTheGame.gameState = ThisIsTheGame.controller.EndGame();
                }
            } while (ThisIsTheGame.gameState != 3);
        }
    }
}
