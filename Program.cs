int dice1 = 0, dice2 = 0, dice3 = 0, dice4 = 0, dice5 = 0;
bool fixed1 = false, fixed2 = false, fixed3 = false, fixed4 = false, fixed5 = false;

Console.Clear(); 

PlayPoker();

void PlayPoker()
{
    for (int i = 1; i <= 3 && !(fixed1 && fixed2 && fixed3 && fixed4 && fixed5); i++)
    {
        RollDice();
        PrintDice(i);
        if (i < 3)
        {
            FixDice();
        }
    }
    SortDice();
}


int[] RollDice()
{
    if (!fixed1) { dice1 = Random.Shared.Next(1, 7); }
    if (!fixed2) { dice2 = Random.Shared.Next(1, 7); }
    if (!fixed3) { dice3 = Random.Shared.Next(1, 7); }
    if (!fixed4) { dice4 = Random.Shared.Next(1, 7); }
    if (!fixed5) { dice5 = Random.Shared.Next(1, 7); }
    int[] dices = { dice1, dice2, dice3, dice4, dice5 };
    return dices;
}

void PrintDice(int round)
{
    Console.WriteLine($"Dice roll #{round} (out of 3): {dice1}, {dice2}, {dice3}, {dice4}, {dice5}");
}

void FixDice()
{
    fixed1 = false;
    fixed2 = false;
    fixed3 = false;
    fixed4 = false;
    fixed5 = false;
    Console.WriteLine("Which dice do you want to fix/unfix? (1-5, or 'r' to roll)");

    string input;

    do
    {
        input = Console.ReadLine()!;
        switch (input)
        {
            case "1":
                fixed1 = !fixed1;
                break;
            case "2":
                fixed2 = !fixed2;
                break;
            case "3":
                fixed3 = !fixed3;
                break;
            case "4":
                fixed4 = !fixed4;
                break;
            case "5":
                fixed5 = !fixed5;
                break;
            default:
                System.Console.WriteLine("---");
                break;
        }

        System.Console.Write("Fixed: ");

        if (fixed1) { System.Console.Write("1 "); }
        if (fixed2) { System.Console.Write("2 "); }
        if (fixed3) { System.Console.Write("3 "); }
        if (fixed4) { System.Console.Write("4 "); }
        if (fixed5) { System.Console.Write("5 "); }

        System.Console.WriteLine();
    } while (input != "r");
}

void SortDice()
{
    int[] dices = RollDice();
    int tmp = 0;

    for (int i = 0; i < dices.Length - 1; i++)
    {
        for (int j = i + 1; j < dices.Length; j++)
        {
            if (dices[i] > dices[j])
            {
                tmp = dices[i];
                dices[i] = dices[j];
                dices[j] = tmp;
            }
        }
        System.Console.Write($"{dices[i]}, ");
    }
}