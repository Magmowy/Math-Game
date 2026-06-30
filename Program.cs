/*
You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.

A game needs to have at least 5 questions.

The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.

Users should be presented with a menu to choose an operation

You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

You don't need to record results on a database. Once the program is closed the results will be deleted.

Try to implement levels of difficulty.

Add a timer to track how long the user takes to finish the game.


*/

static void MathGame(string welcomeMessage="--Math game--", int difficulty = 0, int gameLength = 5){
    Console.WriteLine(welcomeMessage);
    Console.WriteLine("Difficulty: " + difficulty);
    Console.WriteLine("Game length: " + gameLength);
}
string message = "--Math game--";
Console.WriteLine("Difficulty: 0-5");
int difficulty = int.Parse(Console.ReadLine());
if (difficulty > 5){
    difficulty = 5;
}
if (difficulty < 0){
    difficulty = 0;
}
Console.WriteLine("Game length: 1 minimum:");
int gameLength = int.Parse(Console.ReadLine());
if (gameLength < 1){
    gameLength = 1;
}
MathGame(message, difficulty, gameLength);