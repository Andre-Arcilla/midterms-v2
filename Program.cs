namespace midterms_v2
{
    internal class Program
    {
        public static string name;
        public static int month;
        public static int days;
        public static int adults;
        public static int children;
        public static int totalPax;

        public static char destination;
        public static string desName = "";
        public static char roomChoice;
        public static string roomName = "";
        public static int seasonTag;
        public static double roomPrice;
        public static int roomTag;
        public static int desTag;

        //local prices
        public static double[,] roomPriceLoc = new double[5, 4]
        {//---> seasons(lean, high, peak, super peak)
         //|
         //| room type (standard, deluxe, quadruple, family, suite
         //V
            {2000,4000,6000,9000},
            {3000,5000,8000,12000},
            {4000,7000,10000,15000},
            {5000,9000,12000,18000},
            {6000,11000,14000,21000}
        };

        //international prices
        public static double[,] roomPriceInt = new double[5, 4]
        {//---> seasons(lean, high, peak, super peak)
         //|
         //| room type (standard, deluxe, quadruple, family, suite)
         //V
            {2500,4500,6500,10000},
            {5000,7000,9000,13000},
            {7500,9500,11500,16000},
            {10000,12000,14000,19000},
            {12500,14000,16500,22000}
        };

        //room availability
        public static int[,] roomAvail = new int[5, 6]
        {//---> destinations(siargao, boracay, palawan, japan, usa, germany)
         //|
         //| room type (standard, deluxe, quadruple, family, suite)
         //V
            {6,6,6,6,6,6},
            {5,5,5,5,5,5},
            {4,4,4,4,4,4},
            {3,3,3,3,3,3},
            {2,2,2,2,2,2}
        };

        public static double poolPrice;
        public static double gymPrice;
        public static double discountAmount;

        public static double totalTransaction;
        public static int transAmount;

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO HAYAHAY CLUB!");
            Console.WriteLine("");
            Console.WriteLine("press any button to continue");
            Console.ReadKey();
            Console.Clear();

            Login();
        }

        public static readonly string password = "101011";

        static void Login()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"Attempts left [{i}]");
                Console.WriteLine("Enter password: " + password);
                string input1 = Console.ReadLine().Trim();

                if (input1 == password)
                {
                    Console.WriteLine("password match");
                    Console.WriteLine("");
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey();
                    Console.Clear();
                    Message();
                    break;
                }
                else if (i == 1 && input1 != password)
                {
                    Console.Clear();
                    Console.WriteLine("too many incorrect attempts, exiting program...");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("incorrect password");
                    Console.WriteLine("");
                }
            }
        }

        static void Message()
        {
            Console.WriteLine("--- MAIN MENU ---");
            Console.WriteLine("");
            Console.WriteLine("R = Reservation");
            Console.WriteLine("");
            Console.WriteLine("C = Check Availability");
            Console.WriteLine("");
            Console.WriteLine("T = Transaction Summary");
            Console.WriteLine("");
            Console.WriteLine("Q = Quit");
            Console.WriteLine("");
            Console.Write("Enter choice: ");

            MessageInput();
        }

        static void MessageInput()
        {
            string input1 = Console.ReadLine().Trim().ToUpper();
            char input2 = input1[0];

            switch (input2)
            {
                case 'R':
                    Console.Clear();
                    Reservation();
                    break;
                case 'C':
                    availability();
                    break;
                case 'T':
                    transaction();
                    break;
                case 'Q':
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("invalid input");
                    Console.WriteLine("");
                    Message();
                    break;
            }
        }

        static void Reservation()
        {
            Console.Write("Name of Customer: ");
            name = Console.ReadLine().Trim();
            Console.WriteLine("");

            Console.WriteLine($"{"Season",-15}Months");
            Console.WriteLine($"{"Lean",-15}Feb, Jun, Jul");
            Console.WriteLine($"{"High",-15}Aug - Oct");
            Console.WriteLine($"{"Peak",-15}Mar - May");
            Console.WriteLine($"{"Super Peak",-15}Nov - Dec");
            Console.WriteLine("");
            Console.Write("Reservation month (EX. 1 = january, 10 = october): ");
            while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("invalid input...");
                Console.Write("Reservation month (EX. 1 = january, 10 = october): ");
            }
            Console.WriteLine("");

            Console.Write("Number of days staying: ");
            while (!int.TryParse(Console.ReadLine(), out days) || days < 1)
            {
                Console.WriteLine("invalid input...");
                Console.Write("Number of days staying: ");
            }
            Console.WriteLine("");

            Console.Write("Number of adults: ");
            while (!int.TryParse(Console.ReadLine(), out adults) || adults < 1)
            {
                Console.WriteLine("invalid input...");
                Console.Write("Number of adults: ");
            }
            Console.WriteLine("");

            Console.Write("Number of children: ");
            while (!int.TryParse(Console.ReadLine(), out children) || children < 0)
            {
                Console.WriteLine("invalid input...");
                Console.Write("Number of children: ");
            }
            Console.WriteLine("");

            totalPax = adults + children;
            if (totalPax <= 2)
            {
                Console.WriteLine("We would recommend getting a standard or a suite room type");
            }
            else if (totalPax <= 3)
            {
                Console.WriteLine("We would recommend getting a deluxe or a suite room type");
            }
            else if (totalPax == 4)
            {
                Console.WriteLine("We would recommend getting a quadruple or a suite room type");
            }
            else if (totalPax <= 5)
            {
                Console.WriteLine("We would recommend getting a quadruple room type");
            }
            else if (totalPax <= 7)
            {
                Console.WriteLine("We would recommend getting a family room type");
            }

            Console.WriteLine($"{"Local",-20}|{"International",5}");
            Console.WriteLine($"{"(S) Siargao",-20}|{"(J) Japan",5}");
            Console.WriteLine($"{"(B) Boracay",-20}|{"(U) USA",5}");
            Console.WriteLine($"{"(E) El Nido Palawan",-20}|{"(G) Germany",5}");
            Console.Write("Where do you want to go?: ");

            string input1 = Console.ReadLine().Trim().ToUpper();
            destination = input1[0];
            Console.WriteLine("");

            Console.WriteLine($"{"Amenities",-15}Fees");
            Console.WriteLine($"{"(S) Pool",-15}300.00/per day");
            Console.WriteLine($"{"(G) Gym",-15}500.00/per day");
            Console.WriteLine($"(B) Both");
            Console.WriteLine($"(N) None");
            Console.WriteLine("");
            Console.Write("Input: ");

            input1 = Console.ReadLine().Trim().ToUpper();
            char amenitiesChoice = input1[0];
            Console.WriteLine("");

            Console.Write("Are you a PWD or Senior? (Y/N)");

            input1 = Console.ReadLine().Trim().ToUpper();
            char discount = input1[0];
            Console.WriteLine("");

            switch (discount)
            {
                case 'Y':
                    discountAmount = 0.2;
                    break;
                case 'N':
                    discountAmount = 0;
                    break;
                default:
                    Console.WriteLine("invalid input...");
                    break;
            }

            double[,] prices = new double[5,4];
            switch (destination)
            {
                case 'S':
                    desName = "siargao";
                    desTag = 0;
                    prices = roomPriceLoc;
                    break;
                case 'B':
                    desName = "boracay";
                    desTag = 1;
                    prices = roomPriceLoc;
                    break;
                case 'E':
                    desName = "el nido palawan";
                    desTag = 2;
                    prices = roomPriceLoc;
                    break;
                case 'J':
                    desName = "japan";
                    desTag = 3;
                    prices = roomPriceInt;
                    break;
                case 'U':
                    desName = "USA";
                    desTag = 4;
                    prices = roomPriceInt;
                    break;
                case 'G':
                    desName = "germany";
                    desTag = 5;
                    prices = roomPriceInt;
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }

            //lean season
            if (month == 2 || month == 6 || month == 7)
            {
                seasonTag = 0;
            }
            //high season
            else if (month >= 8 || month <= 10)
            {
                seasonTag = 1;
            }
            //peak season
            else if (month >= 3 || month <= 5)
            {
                seasonTag = 2;
            }
            //super peak season
            else if (month == 11 || month == 12 || month == 1)
            {
                seasonTag = 3;
            }

            switch (amenitiesChoice)
            {
                case 'S':
                    poolPrice = 300;
                    break;
                case 'G':
                    gymPrice = 500;
                    break;
                case 'B':
                    poolPrice = 300;
                    gymPrice = 500;
                    break;
                case 'N':
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }

            if (totalPax <= 2)
            {
                Console.WriteLine($"{"(S) Standard",-15} {prices[0, seasonTag]:n2}");
            }
            if (totalPax <= 3)
            {
                Console.WriteLine($"{"(D) Deluxe",-15} {prices[1, seasonTag]:n2}");
            }
            if (totalPax <= 5)
            {
                Console.WriteLine($"{"(Q) Quadruple",-15} {prices[2, seasonTag]:n2}");
            }
            if (totalPax <= 7)
            {
                Console.WriteLine($"{"(F) Family",-15} {prices[3, seasonTag]:n2}");
            }
            if (totalPax <= 4)
            {
                Console.WriteLine($"{"(T) Suite",-15} {prices[4, seasonTag]:n2}");
            }

            Console.WriteLine("Room type:");
            string input2 = Console.ReadLine().Trim().ToUpper();
            roomChoice = input2[0];
            switch(roomChoice)
            {
                case 'S':
                    roomPrice = prices[0, seasonTag];
                    roomName = "standard";
                    roomTag = 0;
                    break;
                case 'D':
                    roomPrice = prices[1, seasonTag];
                    roomName = "deluxe";
                    roomTag = 1;
                    break;
                case 'Q':
                    roomPrice = prices[2, seasonTag];
                    roomName = "quadruple";
                    roomTag = 2;
                    break;
                case 'F':
                    roomPrice = prices[3, seasonTag];
                    roomName = "family";
                    roomTag = 3;
                    break;
                case 'T':
                    roomPrice = prices[4, seasonTag];
                    roomName = "suite";
                    roomTag = 4;
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }

            billing();
        }

        public static void billing()
        {
            double poolTotal = poolPrice * days;
            double gymTotal = gymPrice * days;
            double totalDisc = ((gymTotal + poolTotal) * discountAmount);
            double amenitiesTotal = poolTotal + gymTotal - totalDisc;
            double roomTotal = roomPrice * days;
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"total pax: {totalPax}");
            Console.WriteLine($"accomodation: {desName}");
            Console.WriteLine($"    {roomName} -> {roomPrice:n2} * {days}\n" +
                              $"    = {roomTotal:n2}");
            Console.WriteLine($"    Pool -> {poolPrice:n2} * {days}\n" +
                              $"    = {poolTotal:n2}");
            Console.WriteLine($"    Gym -> {gymPrice:n2} * {days}\n" +
                              $"    = {gymTotal:n2}");

            if (discountAmount == 0.2)
            {
                Console.WriteLine($"    discount -> {(gymTotal + poolTotal):n2} - 20%\n" +
                                  $"    = {totalDisc:n2}");
            }


            double total = roomTotal + amenitiesTotal;
            totalTransaction += total;
            Console.WriteLine($"Total: {total:n2}");

            roomAvail[roomTag, desTag]--;
            transAmount++;
            
            Console.WriteLine("");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Message();
        }

        public static void transaction()
        {
            Console.WriteLine($"Total sales: {totalTransaction:n2}");
            Console.WriteLine($"number of sales: {transAmount}");
            Console.WriteLine("");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Message();
        }

        public static void availability()
        {
            Console.WriteLine($"Siargao:");
            Console.WriteLine($"   standard = {roomAvail[0,0]}\n" +
                              $"   deluxe = {roomAvail[1, 0]}\n" +
                              $"   quadruple = {roomAvail[2, 0]}\n" +
                              $"   family = {roomAvail[3, 0]}\n" +
                              $"   suite = {roomAvail[4, 0]}");
            Console.WriteLine($"");
            Console.WriteLine($"Boracay:");
            Console.WriteLine($"   standard = {roomAvail[0, 1]}\n" +
                              $"   deluxe = {roomAvail[1, 1]}\n" +
                              $"   quadruple = {roomAvail[2, 1]}\n" +
                              $"   family = {roomAvail[3, 1]}\n" +
                              $"   suite = {roomAvail[4, 1]}");
            Console.WriteLine($"");
            Console.WriteLine($"El Nido Palawan:");
            Console.WriteLine($"   standard = {roomAvail[0, 2]}\n" +
                              $"   deluxe = {roomAvail[1, 2]}\n" +
                              $"   quadruple = {roomAvail[2, 2]}\n" +
                              $"   family = {roomAvail[3, 2]}\n" +
                              $"   suite = {roomAvail[4, 2]}");
            Console.WriteLine($"");
            Console.WriteLine($"Japan:");
            Console.WriteLine($"   standard = {roomAvail[0, 3]}\n" +
                              $"   deluxe = {roomAvail[1, 3]}\n" +
                              $"   quadruple = {roomAvail[2, 3]}\n" +
                              $"   family = {roomAvail[3, 3]}\n" +
                              $"   suite = {roomAvail[4, 3]}");
            Console.WriteLine($"");
            Console.WriteLine($"USA:");
            Console.WriteLine($"   standard = {roomAvail[0, 4]}\n" +
                              $"   deluxe = {roomAvail[1, 4]}\n" +
                              $"   quadruple = {roomAvail[2, 4]}\n" +
                              $"   family = {roomAvail[3, 4]}\n" +
                              $"   suite = {roomAvail[4, 4]}");
            Console.WriteLine($"");
            Console.WriteLine($"Germany:");
            Console.WriteLine($"   standard = {roomAvail[0, 5]}\n" +
                              $"   deluxe = {roomAvail[1, 5]}\n" +
                              $"   quadruple = {roomAvail[2, 5]}\n" +
                              $"   family = {roomAvail[3, 5]}\n" +
                              $"   suite = {roomAvail[4, 5]}");

            Console.WriteLine("");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Message();
        }
    }
}

