using System.Collections.Generic;
using System.Text;
using EventSubscription.CustomExceptions;

namespace EventSubscription.Model
{
    /// <summary>
    /// Represents a vending machine containing multiple coffee slots.
    /// </summary>
    public class VendingMachine
    {
        #region event and delegate
        // TODO: step 06:
        // Create the custom handler that will be used when the vending machine needs to notify the user.
        // Name it VendingMachineNotificationHandler. Use the VendingMachineNotificationEventArgs as argument.


        // TODO: step 07:
        // Create the event based on the handler. Name it VendingMachineNotification.
        #endregion event and delegate

        #region properties
        /// <summary>Name of the machine.</summary>
        public string Name { get; set; }

        /// <summary>Number of slots in use in the machine.</summary>
        private int slotCounter;

        private List<CoffeeSlot> _CoffeeSlots;
        /// <summary>List of coffees that the machine contains.</summary>
        public List<CoffeeSlot> CoffeeSlots
        {
            get => this._CoffeeSlots;
            private set
            {
                // Setting the slots with the coffees.
                this._CoffeeSlots = value;

                // For each coffee slot, the vending machine subscribes to the
                // event OutOfBeans. That way, the vending machine will be notified
                // whenever a slot reaches its minimum capacity.

                // TODO: step 09:
                // Subscribe to all coffees OutOfBeans event with the appropriate handler.
            }
        }
        #endregion properties

        /// <summary>
        /// Constructor.
        /// </summary>
        public VendingMachine(string name)
        {
            this.slotCounter = 0;
            this.Name = name;
            CoffeeSlots = new List<CoffeeSlot>();
        }

        /// <summary>
        /// Add a coffee slot.
        /// </summary>
        /// <param name="coffeeSlot">The coffeeSlot to add</param>
        public void AddCoffeeSlot(CoffeeSlot coffeeSlot)
        {
            // Add a slot number and give it to the new slot.
            this.slotCounter++;

            coffeeSlot.Number = this.slotCounter;

            // The coffee slot is added to the machine.
            CoffeeSlots.Add(coffeeSlot);

            // The vending machine then subscribes to the new coffee slot.

            // TODO: step 10:
            // Subscribe to the OutOfBeans event of the coffee with the appropriate handler.
        }

        /// <summary>
        /// Coffee making.
        /// </summary>
        /// <param name="coffeeName">The name of the coffee to make.</param>
        public void MakeCoffee(string coffeeName)
        {
            var selectedCoffee = CoffeeSlots.Find(coffeeSlots => coffeeSlots.CoffeeName.Equals(coffeeName));
            if (selectedCoffee != null)
            {
                try
                {
                    selectedCoffee.UseBeans();

                    // TODO: step 12a:
                    // Create a notification with the correct arguments to inform the user that their coffee is made.
                }
                catch (OutOfBeansException oobEx)
                {
                    // TODO: step 12b:
                    // Create a notification with the correct arguments relaying the error message contained in the exception.
                }
            }
            else
            {
                // TODO: step 11:
                // Create a notification with the correct arguments to inform the user that the coffee they selected is not available in that machine.
            }
        }

        // TODO: step 08:
        // Create the method to handle the event OutOfBeans raised by a coffee slot.
        // In this method, invoke the event VendingMachineNotification to inform of
        // a coffee shortage in the slot.

        /// <summary>
        /// Display the vending machine's information.
        /// </summary>
        /// <returns>The vending machine's information.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Vending machine {Name}:");
            sb.Append("\r\n");
            foreach (var coffeeSlot in CoffeeSlots)
            {
                sb.Append(coffeeSlot.ToString());
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
    }
}
