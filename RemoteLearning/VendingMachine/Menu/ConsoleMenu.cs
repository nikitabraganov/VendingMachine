namespace VendingMachine.Menu
{
    using System;

    using VendingMachine.ContainableItem;
    using VendingMachine.Dispenser;
    using VendingMachine.Payment;
    using VendingMachine.Statistics;
    using VendingMachine.View;

    public class ConsoleMenu : IView
    {
        private const string DefaultStateMenuText = "Remote Learning - Vending Machine \n" + 
                                                "Make your selection from below:\n" + 
                                                "1. Select Product\n" +
                                                "2. View Statistics\n" +
                                                "Your selection: ";

        private const string SelectingStateMenuText = "Input the row letter and column digit: ";
        private const string DatabaseFilePath = "items.json";
        private string currentItemPosition;
        private int paymentMethodSelection;
        private MenuState currentState;
        private ContainableItemsCollection itemsCollection;
        private PaymentTerminal paymentTerminal;
        private Dispenser dispenser;
        private StatisticsComponent statisticsComponent;

        public ConsoleMenu()
        {
            this.currentState = MenuState.Default;

            this.InitDependencies();
        }

        public void DisplayMenu()
        {
            switch (this.currentState)
            {
                case MenuState.Default:
                    ClearConsole();
                    this.Print(DefaultStateMenuText);
                    this.DefaultStateAction(GetInputFromConsole());
                    break;
                case MenuState.Selecting:
                    ClearConsole();
                    this.PrintItemsToConsole();
                    this.PrintMatrixToConsole();
                    this.Print(SelectingStateMenuText);
                    this.SelectingStateAction(GetInputFromConsole());
                    break;
                case MenuState.Payment:
                    ClearConsole();
                    Position position = new Position(this.currentItemPosition);
                    ContainableItem item = this.itemsCollection.GetItem(position);
                    this.paymentTerminal.StartPaymentCycle(item);
                    do
                    {
                        do
                        {
                            ClearConsole();
                            this.PrintOneLine($"You selected product {item.Name}. You have to pay: {item.Price} RON");
                            this.PrintOneLine($"Paid: {this.paymentTerminal.GetPaidAmount()} RON. Remaining: {this.paymentTerminal.GetLeftAmount()} RON to pay");
                            this.PrintOneLine("Available payment methods: ");
                            this.PrintOneLine("1 - Insert 0.1 RON");
                            this.PrintOneLine("2 - Insert 0.5 RON");
                            this.PrintOneLine("3 - Insert 1 RON");
                            this.PrintOneLine("4 - Insert 5 RON");
                            this.PrintOneLine("5 - Insert 10 RON");
                            this.PrintOneLine("6 - Insert 50 RON");
                            this.PrintOneLine("7 - Abort operation");
                            this.Print("Select payment method: ");
                        }
                        while (!this.IsValidPaymentMethodSelected(GetInputFromConsole()));
                        Payment paymentOption;
                        switch (this.paymentMethodSelection)
                        {
                            case 1:
                                paymentOption = new Coin(0.1m);
                                this.paymentTerminal.AddToCurrentAmount(paymentOption);
                                break;
                            case 2:
                                paymentOption = new Coin(0.5m);
                                this.paymentTerminal.AddToCurrentAmount(paymentOption);
                                break;
                            case 3:
                                paymentOption = new Banknote(1);
                                this.paymentTerminal.AddToCurrentAmount(paymentOption);
                                break;
                            case 4:
                                paymentOption = new Banknote(5);
                                this.paymentTerminal.AddToCurrentAmount(paymentOption);
                                break;
                            case 5:
                                paymentOption = new Banknote(10);
                                this.paymentTerminal.AddToCurrentAmount(paymentOption);
                                break;
                            case 6:
                                paymentOption = new Banknote(50);
                                this.paymentTerminal.AddToCurrentAmount(paymentOption);
                                break;
                        }
                    }
                    while (this.paymentTerminal.IsPaymentInProgress());

                    if (this.paymentTerminal.WasAborted)
                    {
                        this.PrintOneLine($"You aborted the payment operation. Please recover your inserted currency: {this.paymentTerminal.GetPaidAmount()} RON");
                        this.PrintOneLine("Press ENTER to continue");
                        Console.ReadLine();
                        this.currentState = MenuState.Default;
                        this.DisplayMenu();
                    }
                    else
                    {
                        this.PrintOneLine($"Your change: {this.paymentTerminal.GetChangeAmount()} RON");
                        this.paymentTerminal.Notify();
                        this.PrintOneLine("Press ENTER to continue");
                        Console.ReadLine();
                        this.currentState = MenuState.Default;
                        this.DisplayMenu();
                    }

                    break;
                case MenuState.Statistics:
                    this.statisticsComponent.PrintStatistics();
                    this.PrintOneLine("Press ENTER to continue");
                    Console.ReadLine();
                    this.currentState = MenuState.Default;
                    this.DisplayMenu();
                    break;
            }
        }

        public void PrintOneLine(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintOneLine()
        {
            Console.WriteLine();
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static string GetInputFromConsole()
        {
            return Console.ReadLine();
        }

        private void DefaultStateAction(string input)
        {
            if (!MenuValidator.ValidateInput(input, new[] { 1, 2 }, out int validatedInput))
            {
                this.DisplayMenu();
            }
            else
            {
                this.ChangeStateBasedOnInput(validatedInput);
                this.DisplayMenu();
            }
        }

        private void SelectingStateAction(string input)
        {
            if (!MenuValidator.ValidateSelectedCell(input))
            {
                this.DisplayMenu();
            }
            else
            {
                this.currentState = MenuState.Payment;
                this.currentItemPosition = input;
                this.DisplayMenu();
            }
        }

        private bool IsValidPaymentMethodSelected(string input)
        {
            if (MenuValidator.ValidateInput(input, new[] { 1, 2, 3, 4, 5, 6, 7 }, out int validatedInput))
            {
                if (validatedInput == 7)
                {
                    // Abort payment operation
                    this.paymentTerminal.AbortPayment();
                }

                this.paymentMethodSelection = validatedInput;
                return true;
            }

            this.PrintOneLine($"Invalid value entered {input}!");
            return false;
        }

        private void PrintItemsToConsole()
        {
            foreach (ContainableItem containableItem in this.itemsCollection.GetProducts())
            {
                Console.WriteLine(containableItem.GetDisplayInfo());
            }
        }

        private void PrintMatrixToConsole()
        {
            this.itemsCollection.PrintMatrix();
        }

        private void ChangeStateBasedOnInput(int input)
        {
            switch (this.currentState)
            {
                case MenuState.Default:
                    if (input == 1)
                    {
                        this.currentState = MenuState.Selecting;
                    }
                    if (input == 2)
                    {
                        this.currentState = MenuState.Statistics;
                    }
        
                    break;
            }
        }

        private void InitDependencies()
        {
            this.itemsCollection = new ContainableItemsCollection(this);
            this.itemsCollection.LoadFromFile(DatabaseFilePath);
            this.statisticsComponent = new StatisticsComponent(this);
            this.dispenser = new Dispenser(this);
            this.dispenser.AddObserver(this.statisticsComponent);
            this.dispenser.AddObserver(this.itemsCollection);
            this.paymentTerminal = new PaymentTerminal();
            this.paymentTerminal.AddObserver(this.dispenser);
        }
    }
}
