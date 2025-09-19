// READ ME / DOKUMENTATION //
// Dette program er en simpel bruger access, der validerer brugernavn og adgangskode baseret på regler.
// Programmet skelner også mellem administratorer og normale brugere baseret på bruger id.
// Programmet bruger boolean variabler til at afgøre om adgang skal gives eller ikke
// Ai brugt til sparring med pensum og kommandoer samt debugging

using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Enter username: "); // Input fra brugeren
        string username = Console.ReadLine();

        Console.Write("Enter password: "); // password fra brugeren
        string password = Console.ReadLine();

        Console.Write("Enter userId (number): "); // userid fra bruger
        uint userId = Convert.ToUInt32(Console.ReadLine()); // bruger uint for ikke negative tal

        // Boolean regler som nævnt i activity 13
        bool userIsAdmin = userId > 65536; // admin hvis userId er større end 65536
        bool usernameValid = username.Length >= 3; // username skal have mindst 3 tegn

        bool containsRequiredChar =
            password.Contains('$') || password.Contains('|') || password.Contains('@'); // password skal indeholde specialtegn

        int minLength = userIsAdmin ? 20 : 16; // admin password skal være mindst 20 tegn, normale brugere mindst 16 tegn
        bool passwordValid = containsRequiredChar && password.Length >= minLength; // password skal opfylde begge krav

        // Output som angivet i Activity 14 med en if else
        if (usernameValid && passwordValid) // begge skal være sande
        {
            Console.WriteLine("Access granted."); 
            if (userIsAdmin)
                Console.WriteLine("You are an administrator.");
            else
                Console.WriteLine("You are a normal user.");
        }
        else
        {
            Console.WriteLine("Access denied.");
        }
    }
}


// Eksempler scenarier //
// Test case 1:
// Enter username: Marius
// Enter password: MyPassword$123456
// Enter userId (number): 1234
// Access granted.
// You are a normal user.
// Process finished with exit code 0.

// Test case 2:
// Enter username: ab
// Enter password: password123
// Enter userId (number): 1234
// Access denied.
// Process finished with exit code 0.

// Test case 3: (med admin rettigheder)
// Enter username: AdminUser
// Enter password: superstrongPassword$withsymbols12345 
// Enter userId (number): 70000
// Access granted.
// You are an administrator.
// 
// Process finished with exit code 0.
// 