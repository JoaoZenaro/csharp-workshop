int numberToBeGuessed = new Random().Next(0,10);
int remainingChances = 5;
bool numberFound = false;

while (!numberFound)
{
    if (remainingChances == 0)
    {
        Console.WriteLine($"You lost. The number was {numberToBeGuessed}");
        break;
    }


    Console.WriteLine($"Guess a number (You have {remainingChances} guess(es) remaining):");
    
    if (Console.ReadLine() == numberToBeGuessed.ToString())
    {
        numberFound = true;
        Console.WriteLine($"Congrats! You have guessed the number with {remainingChances} chances left!");
    }
    else
    {
        remainingChances--;
    }
}