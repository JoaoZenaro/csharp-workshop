﻿Console.Write("Please type a username. It must be at least 6 characters: ");
string username = Console.ReadLine();

if (username.Length < 6) {
    Console.WriteLine($"The username {username} is not valid.");
} else {
    Console.Write("Now type a password. It must have a length of at least 6 characters and also contain a number: ");
    string password = Console.ReadLine();

    if (password.Length < 6) {
        Console.WriteLine("The password must have at least 6 characters.");
    } else if (!password.Any(c => char.IsDigit(c))) {
        Console.WriteLine("The password must contain at least one number.");
    } else {
        Console.WriteLine("User successfully registered.");
    }
}