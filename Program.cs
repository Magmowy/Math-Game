/*
You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted. ✓

Try to implement levels of difficulty. 

Add a timer to track how long the user takes to finish the game.

Question types chosen by user, including random. ✓
*/
const string WELCOME_MESSAGE = "--Math game--";

static string[] MathGame(string welcomeMessage = "--Math game--")
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
    int gameType = GetGameType(Console.ReadLine());
    return StartRound(gameTypes, difficulty, gameLength, gameType);
}
static bool ShowQuestion(int gameType, int difficulty)
{
    Console.WriteLine("--Question--");
    return true;
}
static string[] StartRound(string[] gameTypes, int difficulty = 0, int gameLength = 5, int type = 0)
{
    Console.WriteLine(gameTypes[type]);
    int score = 0;
    for(int i = 0; i < gameLength; i++)
    {
        if(ShowQuestion(type, difficulty))
        {
            score++;
        }
    }
    string[] results = [gameTypes[type], gameLength.ToString(), difficulty.ToString(), score.ToString(), "00:00"];
    return results;
}
static bool SafeParse(string? parsing)
{
    return int.TryParse(parsing, out _);
}
static int GetDifficulty(string? difficultyUser = "0")
{
    difficultyUser ??= "0";
    bool parsed = SafeParse(difficultyUser);
    if (parsed)
    {
        int difficulty = int.Parse(difficultyUser);
        if(difficulty < 0)
        {
            difficulty = 0;
        }
        if (difficulty > 5)
        {
            difficulty = 5;
        }
        return difficulty;
    }
    return 0;
}
static int GetGameLength(string? gameLengthUser = "5")
{
    gameLengthUser ??= "5";
    int gameLength = 5;
    bool parsed = SafeParse(gameLengthUser);
    if (parsed)
    {
        gameLength = int.Parse(gameLengthUser);
        if (gameLength < 1)
        {
            gameLength = 1;
        }
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
/*Round structure:
[Type, length, difficulty, score, time]
*/
static void ShowHistory(List<string[]> history)
{
    int gameNum = 1;
    foreach (string[] round in history)
    {
        string toWrite = $"#{gameNum} Game type: {round[0]}, rounds: {round[1]}, difficulty: {round[2]}, score: {round[3]}, time: {round[4]}.";
        Console.WriteLine(toWrite);
        gameNum++;
    }
    return;
}
List<string[]> gameHistory = [MathGame(WELCOME_MESSAGE)];

while (true)
{
    Console.WriteLine("Type \"start\" to start a new round, \"history\" to see previous games, or \"end\" to quit.");
    string? option = Console.ReadLine();
    option ??= "";
    option = option.ToLower();
    switch (option)
    {
        case "start":
            gameHistory.Add(MathGame(WELCOME_MESSAGE));
            break;
        case "history":
            ShowHistory(gameHistory);
            break;
        case "end":
            Environment.Exit(0);
            break;
        default:
            break;
    }
}