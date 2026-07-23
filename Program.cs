using System.Diagnostics;

const string WELCOME_MESSAGE = "--Math game--";

static string[] MathGame(string welcomeMessage = "--Math game--")
{
    string[] gameTypes = ["Random", "Addition and Subtraction", "Multiplication", "Division"];
    Console.WriteLine(welcomeMessage);
    Console.WriteLine("Difficulty: 0-5");
    int difficulty = GetDifficulty(Console.ReadLine());
    Console.WriteLine("Game length: 5 minimum:");
    int gameLength = GetGameLength(Console.ReadLine());
    Console.WriteLine("Difficulty: " + difficulty);
    Console.WriteLine("Game length: " + gameLength);
    Console.WriteLine("Choose game type: (0 - random; 1 - Addition and Subtraction; 2 - Multiplication; 3 - Division)");
    int gameType = GetGameType(Console.ReadLine());
    return StartRound(gameTypes, difficulty, gameLength, gameType);
}
static int getUserAnswer(string? input)
{
    if(int.TryParse(input ?? "0", out int parsed))
    {
        return parsed;
    }
    return 0;
    
}
static bool ShowQuestion(int gameType, int difficulty)
{
    Random rnd = new();
    Console.WriteLine("--Question--");
    int num1;
    int num2;
    int answer;
    int currGameType = gameType;
    if (gameType == 0)
    {
        currGameType = rnd.Next(1, 3);
    }
    switch (currGameType) {
        case 1: //Addition / Subtraction
            num1 = rnd.Next(difficulty * 2, 20 + (difficulty * difficulty * difficulty)); // 0 - 20; 10 - 145
            num2 = rnd.Next(difficulty * 2, 20 + (difficulty * difficulty * difficulty));
            char oprtr = '+';
            answer = num1 + num2;
            if (rnd.Next(2) == 0)
            {
                answer = num1 - num2;
                oprtr = '-';
            }
            Console.Write($"{num1} {oprtr} {num2} = ");
            if(getUserAnswer(Console.ReadLine()) == answer)
            {
                Console.WriteLine("Correct!");
                return true;
            }
            Console.WriteLine($"Wrong! The answer is: {answer}");
            return false;
        case 2: //Multiplication
            num1 = rnd.Next( ( difficulty + 1 ) * 2, ( difficulty + 1 ) * 5 ); //2 - 5; 12 - 30
            num2 = rnd.Next( ( difficulty + 1 ) * 2, ( difficulty + 1 ) * 5 );
            answer = num1 * num2;
            Console.Write($"{num1} * {num2} = ");
            if(getUserAnswer(Console.ReadLine()) == answer)
            {
                Console.WriteLine("Correct!");
                return true;
            }
            Console.WriteLine($"Wrong! The answer is: {answer}");
            return false;
        case 3: //Division
            num1 = rnd.Next( difficulty * 3, ( difficulty + 1 ) * 16 + 4);// 0 - 20; 15 - 100
            Console.WriteLine("num1: " + num1);
            int maxNum2;
            if(num1 == 0)
            {
                maxNum2 = 100;
            }
            else
            {
                maxNum2 = (int)num1/2;
            }
            num2 = rnd.Next( difficulty + 1 <= num1 ? 1 : difficulty+1, maxNum2 );
            int moduloDiff = num1 % num2;
            num1 -= moduloDiff;
            answer = num1 / num2;
            Console.Write($"{num1} / {num2} = ");
            if (getUserAnswer(Console.ReadLine()) == answer)
            {
                Console.WriteLine("Correct!");
                return true;
            }
            Console.WriteLine($"Wrong! The answer is: {answer}");
            return false;
        default:
            Console.WriteLine("Error: Invalid game type");
            return false;
    }
}
static string[] StartRound(string[] gameTypes, int difficulty = 0, int gameLength = 5, int type = 0)
{
    Stopwatch timer = new();
    timer.Start();
    Console.WriteLine(gameTypes[type]);
    int score = 0;
    for(int i = 0; i < gameLength; i++)
    {
        if(ShowQuestion(type, difficulty))
        {
            score++;
        }
    }
    timer.Stop();
    TimeSpan time = timer.Elapsed;
    string timeDisplay = String.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
    Console.WriteLine(timeDisplay);
    string[] results = [gameTypes[type], gameLength.ToString(), difficulty.ToString(), score.ToString(), timeDisplay];
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
        return gameLength < 5 ? 5 : gameLength;
    }
    return 5;
}
static int GetGameType(string? typeUser)
{
    bool parsed = int.TryParse(typeUser, out int type);
    if(parsed && type >=0 && type <= 3)
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
        string toWrite = $"#{gameNum} Game type: {round[0]}; " +
            $"rounds: {round[1]}; " +
            $"difficulty: {round[2]}; " +
            $"score: {round[3]}/{round[1]} - {double.Round((double.Parse(round[3]) / double.Parse(round[1])) * 100)}%; " +
            $"time: {round[4]}.";
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