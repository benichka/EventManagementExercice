﻿using System;
using EventSubscription.Model;

namespace EventSubscription
{
    /// <summary>
    /// Entry point.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new VendingMachine("Machine in the hall");

            // The program subscribes to the event VendingMachineNotification. That way,
            // the program will be notified whenever the machine wants to "speak" to it.

            // TODO: step 14:
            // make HandleVendingMachineNotification subscribes to the newly instanciated machine notification.

            // Fill the machine with coffee!
            var coffee1 = new Coffee("Decaffeinato", "Arabica", "Colombia", Coffee.CoffeeStrength.Decaf);
            var coffee2 = new Coffee("Classico", "Arabica", "Ethiopia", Coffee.CoffeeStrength.Standard);
            var coffee3 = new Coffee("Forte", "Robusta", "Réunion", Coffee.CoffeeStrength.Strong);

            var slot1 = new CoffeeSlot(coffee1);
            var slot2 = new CoffeeSlot(coffee2);
            var slot3 = new CoffeeSlot(coffee3);

            machine.AddCoffeeSlot(slot1);
            machine.AddCoffeeSlot(slot2);
            machine.AddCoffeeSlot(slot3);

            // Display the content of the machine.
            Console.WriteLine(machine.ToString());

            // Make a few coffees.
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"=============== iteration {i} ===============");

                // At the 10th coffee (the limit is 5 by default), the event OutOfBeans will be raised
                // and the method machine.HandleOutOfBeans will be invoked.
                machine.MakeCoffee("Decaffeinato");

                if (i < 10)
                {
                    machine.MakeCoffee("Forte");
                }

                if (i == 5)
                {
                    // This coffee doesn't exist: a message should appear.
                    machine.MakeCoffee("Speciale");
                }
            }
        }

        // TODO: step 13:
        // create the handler for the vending machine notification. Call it HandleVendingMachineNotification.
        // Its only purpose is to write the message that the machine sent via the arguments, to the console.
    }
}
