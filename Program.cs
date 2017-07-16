using System;
using System.Collections.Generic;

namespace expression_members
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName() => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        
        public string PreyList() => string.Join(",", this.Prey);

        
        public string PredatorList() => string.Join(", ", this.Predators);

        // Convert this to expression method (hint: use a C# ternary)
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"The {this.Name} is still hungry.";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bug bug1 = new Bug ("Roach", "RoachSpecies", new List<string>(){"Humans", "Bug Spray"}, new List<string>(){"old food"});
            Bug bug2 = new Bug("StinkBug", "StinkBugSpecies", new List<string>(){"Rats", "Mice"}, new List<string>(){"poop", "vomit"});
            Bug bug3 = new Bug("Caterpiller", "CaterpillerSpecies", new List<string>(){"Humans", "Birds"}, new List<string>(){"grass", "weeds"});

            Console.WriteLine($"The {bug1.Name} is a gross bug");
            Console.WriteLine($"The {bug2.Name} is a stinky bug");
            Console.WriteLine($"The {bug3.Name} is a cute bug");
            Console.WriteLine($"The {bug1.Species}'s predators are: {bug1.PredatorList()}");
            Console.WriteLine($"The {bug2.Species}'s predators are: {bug2.PredatorList()}");
            Console.WriteLine($"The {bug3.Species}'s predators are: {bug3.PredatorList()}");
            Console.WriteLine($"The {bug1.Species}'s prey are: {bug1.PreyList()}");
            Console.WriteLine($"The {bug2.Species}'s prey are: {bug2.PreyList()}");
            Console.WriteLine($"The {bug3.Species}'s prey are: {bug3.PreyList()}");

            Console.WriteLine(bug1.Eat("Flies"));
        }
    }
}
