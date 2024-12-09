using System;
using System.Collections.Generic;
using System.Linq;

// Implementerade designmönster:
// 1. Factory Method
// 2. Singleton
// 3. Strategy

namespace IdeologyFactory
{
    // Strategy-mmetoden används för att definiera en familj av algoritmer, kapsla in varje algoritm och göra dem utbytbara genom att använda ett gemensamt interface.
    // IIdeology-gränssnittet definierar en metod Describe för att beskriva ideologier, medan ärvande klasser implementerar IIdeology och tillhandahåller egna specifika beskrivningar.
    // The Strategy method is used to define a family of algorithms, encapsulate each algorithm, and make them interchangeable by using a common interface.
    // The IIdeology interface defines a Describe method to describe ideologies, while inheriting classes implement IIdeology and provide their own specific descriptions.
    public interface IIdeology
    {
        void Describe(); // Metod för att beskriva ideologin // Method to describe the ideology
        void PerformAction(); // Metod för att utföra en specifik handling baserat på ideologin // Method to perform a specific action based on the ideology
    }

    // Implementerar specifika ideologier enligt Strategy-metoden. Varje ärvande ideologi har en egen metod för att beskriva sig själv och utföra en specifik handling. //Implements specific ideologies according to the Strategy method. Each inheriting ideology has its own method to describe itself and perform a specific action.
    internal class Liberalism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Liberalism emphasizes individual freedom and limited government intervention.");
        }

        public void PerformAction()
        {
            Console.WriteLine("You can now declare that everyone has the right to do anything, anywhere, at any time, even if it means turning your living room into a rock concert venue!");
        }
    }

    internal class Capitalism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Capitalism emphasizes private ownership and free market economy.");
        }
        public void PerformAction()
        {
            Console.WriteLine("You can now start selling everything around you,\nincluding your neighbor's lawn and the air you breathe, for a most 'modest' profit!\nAlso there are subscription plans are now available for talking to this program\n—starting at $9.99 per minute!");
        }
    }

    internal class Conservatism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Conservatism emphasizes tradition, authority, and the preservation of established institutions.");
        }
        public void PerformAction()
        {
            Console.WriteLine("You can now insist on replacing all modern technology with candlelight, horse-drawn carriages, and carrier pigeons.\n-'If it was good enough for grandpa, it’s good enough for us!'");
        }
    }

    internal class Fascism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Fascism emphasizes authoritarianism, nationalism, and the supremacy of the state.");
        }
        public void PerformAction()
        {
            Console.WriteLine("You can now enforce strict loyalty to The Rule (of your choosing) and\n1. Mandate national anthem karaoke every hour (Wooohoo!)\n2. Replace all street names with your own name (yours is prettier anyyway)");
        }
    }

    internal class Socialism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Socialism emphasizes common ownership and democratic control of the means of production.");
        }

        public void PerformAction()
        {
            Console.WriteLine("You can now redistribute everything equally.\nYour neighbor’s jacuzzi is now a community soup pot, your car has become the public bus,\nand everyone gets exactly 3 potatoes a week, no exceptions!!!");
        }
    }

    internal class Communism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Communism emphasizes common ownership and the absence of social classes.");
        }
        public void PerformAction()
        {
            Console.WriteLine("You can now create a classless, stateless society. Where everyone works tirelessly on the beautiful collective farm,\nbut nobody is quite sure who’s in charge of deciding what to plant.");
        }
    }
    internal class Anarchism : IIdeology
    {
        public void Describe()
        {
            Console.WriteLine("Anarchism advocates for a stateless society and the abolition of hierarchical structures.");
        }

        public void PerformAction()
        {
            Console.WriteLine("With that you have abolished all authority. Traffic lights are now art installations, taxes are nothing but a memory,\nand your neighbor is now their own independent nation-state with their own lawbook and everything!\nI also heard that they have weapons at home :)");
        }
    }

    // Factory-metoden används för att skapa objekt utan att specificera den exakta klassen för objektet som ska skapas; //The Factory method is used to create objects without specifying the exact class of the object to be created;
    public interface IIdeologyFactory
    {
        IIdeology Create(); // Metod för att skapa en ideologi //Method to create an ideology
    }

    // Implementerar specifika fabriker som skapar ideologier enligt Factory-metoden; //Implements specific factories that create ideologies according to the Factory method;
    internal class LiberalismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Liberalism();
        }
    }

    internal class CapitalismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Capitalism();
        }
    }

    internal class FascismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Fascism();
        }
    }

    internal class SocialismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Socialism();
        }
    }

    internal class AnarchismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Anarchism();
        }
    }

    internal class CommunismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Communism();
        }
    }
    internal class ConservatismFactory : IIdeologyFactory
    {
        public IIdeology Create()
        {
            return new Conservatism();
        }
    }

    // Singleton-mönstret används för att säkerställa att en klass har endast en instans och tillhandahåller en global åtkomstpunkt till denna instans. //The Singleton pattern is used to ensure that a class has only one instance and provides a global access point to this instance.
    // En klass som hanterar skapandet av ideologier; //A class that handles the creation of ideologies;
    public class IdeologyMachine
    {
        private static readonly Lazy<IdeologyMachine> _instance = new Lazy<IdeologyMachine>(() => new IdeologyMachine()); // Singleton-instans med Lazy Initialization
        private readonly List<Tuple<string, IIdeologyFactory>> namedFactories; // Lista över fabriker med deras namn // List of factories with their names

        // Privat konstruktor för att förhindra direkt instansiering//Private constructor to prevent direct instantiation
        private IdeologyMachine()
        {
            namedFactories = new List<Tuple<string, IIdeologyFactory>>();

            // Registrerar fabriker explicit
            RegisterFactory<LiberalismFactory>("Liberalism");
            RegisterFactory<CapitalismFactory>("Capitalism");
            RegisterFactory<ConservatismFactory>("Conservatism");
            RegisterFactory<CommunismFactory>("Communism");
            RegisterFactory<FascismFactory>("Fascism");
            RegisterFactory<SocialismFactory>("Socialism");
            RegisterFactory<AnarchismFactory>("Anarchism");
        }

        // Metod för att få den enda instansen av IdeologyMachine //Method to get the single instance of IdeologyMachine
        public static IdeologyMachine Instance => _instance.Value;

        // Metod för att registrera en fabrik //Method to register a factory
        private void RegisterFactory<T>(string ideologyName) where T : IIdeologyFactory, new()
        {
            namedFactories.Add(Tuple.Create(ideologyName, (IIdeologyFactory)Activator.CreateInstance(typeof(T))));
        }

        // Metod för att skapa en ideologi //Method to create an ideology
        public IIdeology CreateIdeology()
        {
            Console.WriteLine("The time has come for you to commit to an ideology. Choose wisely:");
            for (var index = 0; index < namedFactories.Count; index++)
            {
                var tuple = namedFactories[index];
                Console.WriteLine($"{index}: {tuple.Item1}"); // Skriver ut tillgängliga ideologier //Prints out available ideologies
            }
            Console.WriteLine($"Please enter a number between 0 and {namedFactories.Count - 1} to continue:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int i) && i >= 0 && i < namedFactories.Count) // Läser och validerar användarens val // Reads and validates user input
                {
                    return namedFactories[i].Item2.Create(); // Skapar och returnerar ideologin //Creates and returns the ideology
                }
                Console.WriteLine("Something went wrong with your input, try again."); // Meddelande vid felaktig inmatning //Message for incorrect input
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = IdeologyMachine.Instance; // Skapar en instans av IdeologyMachine enligt Singleton-mönstret med Lazy Initialization //Creates an instance of IdeologyMachine according to the Singleton pattern with Lazy Initialization
            while (true)
            {
                IIdeology ideology = machine.CreateIdeology(); // Skapar en ideologi //Creates an ideology
                ideology.Describe(); // Beskriver ideologin

                Console.WriteLine("Do you accept this ideology? (yes/no)");
                string acceptResponse = Console.ReadLine().Trim().ToLower();
                if (acceptResponse == "yes")
                {
                    Console.WriteLine("You have accepted the ideology.");
                    ideology.PerformAction(); // Utför en specifik handling baserat på ideologin //Performs a specific action based on the ideology
                    Console.WriteLine("The citizens rejoice... or start panicking. It's hard to tell.");
                }

                Console.WriteLine("Would you like to choose another ideology? (yes/no)");
                string response = Console.ReadLine().Trim().ToLower();
                if (response != "yes")
                {
                    Console.WriteLine("You walk away firmly committed to your newfound beliefs... until tomorrow.");
                    break;
                }
            }
        }
    }
}
