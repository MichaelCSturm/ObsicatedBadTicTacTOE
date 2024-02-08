// See https://aka.ms/new-console-template for more information
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

Console.WriteLine("C# console app GAMING");
//string[] game = { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
string input;
Console.WriteLine("Controls are \n" + " 1 | 2 | 3 " + "\n---+---+---" + "\n4 | 5 | 6" + "\n---+---+---" + "\n7 | 8 | 9");
Board spot0 =new Board(0, 0, "");
Board spot1 = new Board(1,1," ");
Board spot2 = new Board(2, 1, " ");
Board spot3 = new Board(3, 1, " ");
Board spot4 = new Board(1, 2, " ");
Board spot5 = new Board(2, 2, " ");
Board spot6 = new Board(3, 2, " ");
Board spot7 = new Board(1, 3, " ");
Board spot8 = new Board(2, 3, " ");
Board spot9 = new Board(3, 3, " ");
Board[] game = { spot0, spot1, spot2, spot3, spot4, spot5, spot6, spot7, spot8, spot9};
while (true) 
{
    while (true) {
        Console.WriteLine("                  X's turn");
        input = Console.ReadLine();
        try { int.Parse(input); }
        catch { Console.WriteLine("BRUH THE CONTROLS ARE RIGHT THERE YOU KNOW HOW TO PLAY TIK TAC TOE"); continue; }
        int checker = Check(Int32.Parse(input), game);
        if (checker == 0)
        {
            continue;
        }
        if (checker == 1) 
        { break; }        
    }
   

    game[Int32.Parse(input) ].player = "X";
    Update(game);

    GameCheckState(game);
    if (spot1.player == "O" && spot5.player == "O" && spot9.player == "O")
    {
        drawWinner(1);
    }
    if (spot3.player == "O" && spot5.player == "O" && spot7.player == "O")
    {
        drawWinner(1);
    }
    //CHECK DIAGONAL

    while (true)
    {
        Console.WriteLine("                  O's turn");
        input = Console.ReadLine();
        try { int.Parse(input); }
        catch { Console.WriteLine("BRUH THE CONTROLS ARE RIGHT THERE YOU KNOW HOW TO PLAY TIK TAC TOE"); continue; }
        int checker = Check(Int32.Parse(input), game);
        if (checker == 0)
        {
            continue;
        }
        if (checker == 1)
        { break; }
    }
    if (spot1.player == "X" && spot5.player == "X" && spot9.player == "X")
    {
        drawWinner(0);
    }
    if (spot3.player == "X" && spot5.player == "X" && spot7.player == "X")
    {
        drawWinner(0);
    }
    game[Int32.Parse(input)].player = "O";
    Update(game);

    GameCheckState(game);
    //CHECK DIAGONAL

}

static void drawWinner(int winner) { 
    int counter = 0;
    string yourMOM = "#";

    while (true) 
    { Console.WriteLine(yourMOM);
        yourMOM = yourMOM + "#" + (Possibleplayers)winner + " WON";
        counter++;
        if (counter == 20)
        {
            break;
        }
    }
    Environment.Exit(0);
    return;
}
static void GameCheckState(Board[] game)
{
    if (game[1].player == "O"&& game[5].player=="O" && game[9].player == "O")
    {
        drawWinner(1);
    }
    if (game[3].player == "O" && game[5].player == "O" && game[7].player == "O")
    {
        drawWinner(1);
    }
    if (game[1].player == "X" && game[5].player == "X" && game[9].player == "X")
    {
        drawWinner(0);
    }
    if (game[3].player == "X" && game[5].player == "X" && game[7].player == "X")
    {
        drawWinner(0);
    }
    //int[] temp = { };
    var ColWinnerO = from row in game
                    where row.player == "O"
                    select row;
    var ColWinnerX = from row in game
                    where row.player == "X"
                    select row;
    ColWinnerO = ColWinnerO.ToArray();
    //foreach (var row in ColWinner) { Console.WriteLine(row.col); }

    List<Board> asList = ColWinnerO.ToList();
    int row1 = 0; int row2 = 0; int row3 = 0; int col1 = 0;int col2 = 0;int col3 = 0; int digL = 0; int digR = 0;
    foreach (var row in ColWinnerO)
    {
        if (row.row == 1) { row1++; }
        if (row.row == 2) { row2++; }
        if (row.row == 3) { row3++; }
        if (row.col == 1) { col1++; }
        if (row.col == 2) { col2++; }
        if (row.col == 3) { col3++; }
        
        
    }
    if (row1 == 3 | row2 == 3 | row3 == 3 | col1 == 3 | col2== 3 |col3==3 | digL==1| digR==1)
    {
        drawWinner(1);
    }
    int row1x = 0; int row2x = 0; int row3x = 0; int col1x = 0; int col2x = 0; int col3x = 0;
    foreach (var row in ColWinnerX)
    {
        if (row.row == 1) { row1x++; }
        if (row.row == 2) { row2x++; }
        if (row.row == 3) { row3x++; }
        if (row.col == 1) { col1x++; }
        if (row.col == 2) { col2x++; }
        if (row.col == 3) { col3x++; }
    }
    if (row1x == 3 | row2x == 3 | row3x == 3 | col1x == 3 | col2x == 3 | col3x == 3)
    {
        drawWinner(0);
    }
    int rowcheck = 0;
    var SpaceCheck = from row in game
                     where row.player == " "
                     select row;
    foreach (var row in SpaceCheck) { rowcheck++; }
    if(rowcheck == 0) { drawWinner(2); }
    return;
}
 
static void Update(Board [] game)
{

    Console.WriteLine(game[1].player +"  |  "+ game[2].player + "  |  "+ game[3].player);
    Console.WriteLine("---+---+---");
    Console.WriteLine(game[4].player + "  |  "+ game[5].player + "  |  "+ game[6].player);
    Console.WriteLine("---+---+---");
    Console.WriteLine(game[7].player + "  |  "+ game[8].player + "  |  "+ game[9].player);
}
static int Check(int input, Board[] game)
{
    if (input <= 0 | input >= 10 | game[input].player =="X" | game[input].player == "O")
    {
        Console.WriteLine("Out of bounds! Please put a correct possible option! ");
        return 0;
    }
    else { return 1; }
}
public class Board
{
    public int row;
    public int col;
    public string player;
    public Board(int row, int col, string player)
    {
        this.row = row;
        this.col = col;
        this.player = player;
    }
    public int getRow()
    {
        return this.row;
    }
    public int getCol()
    {
        return this.col;
    }
    public string getPlayer()
    {
        return this.player;
    }
    public void setPlayer(string player) { this.player = player; }
    public void setRow(int row) { this.row = row;}
    public void setCol(int col) {  this.col = col;}

}
public enum Possibleplayers
{
    player1,
    player2,
    NOBODYWON
}