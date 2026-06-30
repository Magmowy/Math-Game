/*
You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted.

Try to implement levels of difficulty.

Add a timer to track how long the user takes to finish the game.

Question types chosen by user, including random.
*/
const string message = "--Math game--";

static void MathGame(string welcomeMessage = "--Math game--")
{
    string[] gameTypes = ["Random", "Addition and Subtraction", "Multiplication", "Division"];
    Console.WriteLine(welcomeMessage);
    Console.WriteLine("Difficulty: 0-5");
    int difficulty = GetDifficulty(Console.ReadLine());
    Console.WriteLine("Game length: 1 minimum:");
    int gameLength = GetGameLength(Console.ReadLine());
    Console.WriteLine("Difficulty: " + difficulty);
    Console.WriteLine("Game length: " + gameLength);
    Console.WriteLine("Choose game type: (0 - random; 1 - Addition and Subtraction; 2 - Multiplication; 3 - Division)");
    Round(gameTypes, difficulty, gameLength, GetGameType(Console.ReadLine()));
}
static int Round(string[] gameTypes, int difficulty = 0, int gameLength = 5, int type = 0)
{
    Console.WriteLine(gameTypes[type]);
    switch (type)
    {
        case 0:
            return 0;  //Random
        case 1:
            return 1;  //Addition and subtraction
        case 2:
            return 2;  //Multiplication
        case 3:
            return 3;  //Division
        default:
            return -1; //Invalid
    }
}
static int GetDifficulty(string? difficultyUser = "0")
{
    int difficulty;
    bool parsed = int.TryParse(difficultyUser, out difficulty); //Move into seperate unified function alongside GetGameLength() and GetGameType() parsing
    if (parsed && difficulty > 0 && difficulty <= 5)
    {
        return difficulty;
    }
    return 0;
}
static int GetGameLength(string? gameLengthUser = "5")
{
    int gameLength;
    bool parsed = int.TryParse(gameLengthUser, out gameLength);
    if (parsed && gameLength >= 1)
    {
        return gameLength;
    }
    return 5;
}
static int GetGameType(string? typeUser)
{
    int type;
    bool parsed = int.TryParse(typeUser, out type);
    if(parsed && type>=0 && type <= 3)
    {
        return type;
    }
    return 0;
}



MathGame(message);