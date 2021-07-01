using System;
using System.Collections.Generic;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        #region Teori och Fakta Svar
        //        1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion.

        //Stacken är en datastruktur där minne allokeras för metoder.Initialt för metoden Main.Om en ny metod kallas allokeras
        //ytterligare minne på stacken för den metoden, och så vidare för ytterligare metoder. Dessa allokerade minnesramar staplas/stackas
        //(pushas) på en ”hög” varför benämningen stack används. Samma gäller för de lokala variablerna. Om de är av värdestyp lagras de
        //direkt i den aktuella metodens minnesram i stacken.

        //För variabler av referenstyp lagras en pekare i stacken, pekaren är en adress som refererar/pekar till minne i heapen.Till skillnad
        //från stacken där minne allokeras ”stapelvis” (vilket innebär att alla allokeringar ligger angränsande mot varandra) behöver detta
        //inte nödvändigtvis vara fallet i heapen.

        //      2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

        //En ”Value Type” lagras direkt i stacken (om lokal) eller i dess objekts allokerade minne (om det är en klassmedlem eller statisk
        //variabel). En ”Reference Type” lagrar endast en referens(pekare) som pekar mot en minnesadress i heapen.Kopiering av en variabel
        //av värdetyp sker genom ”Pass by Value”, värdet i sig kopieras till en ny allokering i minnet.Kopiering av en variabel av referenstyp
        //sker genom ”Pass by Reference”, pekaren till objektet kopieras, datan i heapen kopieras inte.

        //CLR:en håller koll på alla variabler av referenstyp och dess garbage collector kommer de-allokera minnesdelen i heapen om variabler
        //som pekar mot den aktuella minnesdelen saknas.

        //      3. Följande metoder (se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?

        //I det första fallet instansieras en struct som är en värdetyp och alltså lagras i stacken.Den ges värdet 3. Den nya structen y son
        //instantieras därefter får en egen minnesallokering i stacken.Värdet på x kopieras över till y.Därefter ändras värdet i structen y.
        //Värdet på structen x förblir oförändrat.
        //I det andra fallet instansieras ett objekt i heapen med en variabel x av referenstyp i stacken som pekar mot objektet.Ett fält i
        //objektets allokerade minne får värdet 3. Ett nytt objekt instantieras med en ny variabel y av referenstyp.Denna skrivs sedan över
        //med en pekare mot det tidigare objektet.Båda referenserna pekar nu alltså mot samma objekt. 
        #endregion

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Reverse Text"
                    + "\n5. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ReverseText();
                        break;
                    case '5':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            char firstChar = ' ';
            var currentList = new List<string>();
            do
            {
                Console.WriteLine("Use the prefixes + and - to add or remove a string to the list."
                        + "\nPress 0 to go back.");

                string input = Console.ReadLine();
                try
                {
                    firstChar = input[0];
                    input = input.Substring(1, input.Length - 1);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                    firstChar = ' ';
                }

                switch (firstChar)
                {
                    case '+':
                        currentList.Add(input);
                        Console.WriteLine(currentList.Count);
                        Console.WriteLine(currentList.Capacity);
                        break;
                    case '-':
                        currentList.Remove(input);
                        Console.WriteLine(currentList.Count);
                        Console.WriteLine(currentList.Capacity);
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Please use the prefixes to enter valid input.");
                        break;
                }
            } while (firstChar != '0');
        }
        #region Övning 1: ExamineList() svar på frågor
        /*
            2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 3. Med hur mycket ökar kapaciteten?
        När listans kapacitet är nådd och ett ytterligare element läggs till fördubblas listans kapacitet.

            4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
        CLR:n måste arbeta för att utöka listan, att fördubbla det allokerade minnet då kapaciteten nås är troligen det mest effektiva 
        tillvägagångssättet, anpassat för hur en lista vanligtvis används.

            5. Minskar kapaciteten när element tas bort ur listan?
        Nej.

            6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
        Om du vet hur många element du har i din samling och om du vet att mängden inte kommer förändras är det mer fördelaktigt med en array.

        */
        #endregion


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menu.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            char firstChar = ' ';
            var currentQueue = new Queue<string>();
            do
            {
                Console.WriteLine("Use the + prefix to add someone to the queue."
                        + "\nPress - (minus) to serve the first person in line."
                        + "\nPress 0 to go back.");

                string input = Console.ReadLine();
                try
                {
                    firstChar = input[0];
                    input = input.Substring(1, input.Length - 1); // Split the input string to remove the +
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    firstChar = ' '; // Go to default if no input
                }

                if (input.Length == 0 && firstChar == '+') firstChar = ' ';

                switch (firstChar)
                {
                    case '+':
                        currentQueue.Enqueue(input);
                        if (currentQueue.Count == 1)
                            Console.WriteLine($"Next in line is {currentQueue.Peek()} and there is {currentQueue.Count} person in the queue.");
                        else
                            Console.WriteLine($"Next in line is {currentQueue.Peek()} and there are {currentQueue.Count} people in the queue.");
                        break;
                    case '-':
                        if (currentQueue.Count == 0)
                            Console.WriteLine("The line is empty!");
                        else
                        {
                            currentQueue.Dequeue();
                            if (currentQueue.Count == 0)
                                Console.WriteLine("The line is empty!");
                            else
                            {
                                if (currentQueue.Count == 1)
                                    Console.WriteLine($"Next in line is {currentQueue.Peek()} and there is {currentQueue.Count} person in the queue.");
                                else
                                    Console.WriteLine($"Next in line is {currentQueue.Peek()} and there are {currentQueue.Count} people in the queue.");
                            }
                        }
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            } while (firstChar != '0');

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*  1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack . Varför är det
             *  inte så smart att använda en stack i det här fallet?
             * 
             *  Personen som ställt sig i kön mest nyligen är den som expedierad. De som kom före kommer behöva vänta. Vi kan alltså inte
             *  simulera hur en verklig kö fungerar med en stack.
             */
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            var currentStack = new Stack<string>();
            char firstChar = ' ';
            do
            {
                Console.WriteLine("Use the + prefix to push something on the stack."
                   + "\nPress - (minus) to pop an item off the stack."
                   + "\nPress 0 to go back.");
                string input = Console.ReadLine();
                try
                {
                    firstChar = input[0];
                    input = input.Substring(1, input.Length - 1);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    firstChar = ' ';
                }

                if (input.Length == 0 && firstChar == '+') firstChar = ' ';

                switch (firstChar)
                {
                    case '+':
                        currentStack.Push(input);
                        if (currentStack.Count == 1)
                            Console.WriteLine($"{currentStack.Peek()} is at the top of the stack and there is {currentStack.Count} item in the stack.");
                        else
                            Console.WriteLine($"{currentStack.Peek()} is at the top of the stack and there are {currentStack.Count} items in the stack");
                        break;
                    case '-':
                        if (currentStack.Count == 0)
                            Console.WriteLine("The stack is empty!");
                        else
                        {
                            currentStack.Pop();
                            if (currentStack.Count == 0)
                                Console.WriteLine("The stack is empty!");
                            else
                            {
                                if (currentStack.Count == 1)
                                    Console.WriteLine($"{currentStack.Peek()} is at the top of the stack and there is {currentStack.Count} item in the stack.");
                                else
                                    Console.WriteLine($"{currentStack.Peek()} is at the top of the stack and there are {currentStack.Count} items in the stack");
                            }
                        }
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }

            } while (firstChar != '0');
        }

        static void ReverseText()
        {
            char input = ' ';
            do
            {
                Console.WriteLine("Welcome to the text reverser. Press 1 and enter to reverse some text. Press 0 to exit.");
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    input = ' ';
                }
                switch (input)
                {
                    case '1':
                        Console.WriteLine("Enter your string: ");
                        var charStr = Console.ReadLine();

                        // We pile the individual chars from the string to the stack
                        var charStack = new Stack<char>(charStr);

                        // When extracting from a stack the chars will be returned to an array according to LIFO

                        var reversedCharArr = charStack.ToArray();

                        // The array is copied to a new string
                        var reversedStr = string.Join("", reversedCharArr);

                        // The string is printed out
                        Console.WriteLine(reversedStr);
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input!");
                        break;
                }
            } while (input != '0');
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
        private static char ValidatedInput()
        {
            char input = ' ';
            try
            {
                input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            return input;
        }

        

    }
}