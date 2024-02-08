﻿using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance:"
            Console.WriteLine("Enter the Item Number of an appliance:");

            // Create long variable to hold item number
            long ItemNumber;

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            string userInputINumber = Console.ReadLine();
            ItemNumber = long.Parse(userInputINumber);
            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance foundAppliance = null;

            // Loop through Appliances1

            foreach (Appliance appObject in Appliances)
            // Test appliance item number equals entered item number
            {
                if (appObject.ItemNumber == ItemNumber)
                {
                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = appObject;
                    // Break out of loop (since we found what need to)
                    break;
                }

            }
            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (foundAppliance == null)
            {
                Console.WriteLine("No Appliances Found with that item number.\n");
                return;

            }
            // Otherwise (appliance was found)
            // Test found appliance is available
            if (foundAppliance.IsAvailable)
            {
                // Checkout found appliance
                foundAppliance.Checkout();
                // Write "Appliance has been checked out."
                Console.WriteLine($"The Appliance {ItemNumber} has been Checked out.\n");
                return;
            }

            if (!foundAppliance.IsAvailable)
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
            {
                Console.WriteLine("The Appliance is not available to be checked out.");
            }


        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("This is for testing");
            // Write "Enter brand to search for:"

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.

            // Create list to hold found Appliance objects

            // Iterate through loaded appliances
            // Test current appliance brand matches what user entered
            // Add current appliance in list to found list


            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            //Display options and ask for users input assigns it to numOfDoors Int Variable
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");
            Console.WriteLine("Enter number of doors: ");
            int numOfDoors = Convert.ToInt16(Console.ReadLine());

            //Creates Appliance list, iterates through txt file and if the line begins with 1 adds Refrigerator object to the list.
            string fileName = @"appliances.txt";
            List<Appliance> fridge = new List<Appliance>();
            string[] fileLines = File.ReadAllLines(fileName);
            foreach (string line in fileLines)
            {
                if (line != "")
                {
                    string[] fields = line.Split(';');
                    string id = fields[0];
                    char id_firstChar = id[0];

                    if (id_firstChar == '1')
                    {
                        fridge.Add(new Refrigerator(long.Parse(fields[0]), fields[1], Int16.Parse(fields[2]), decimal.Parse(fields[3]), fields[4], decimal.Parse(fields[5]), short.Parse(fields[6]), Int16.Parse(fields[7]), Int16.Parse(fields[8])));

                    }
                }
            }

            // Creates Refrigerator list and Down cast Appliance list to Refrigerator
            List<Refrigerator> found = new List<Refrigerator>();
            for (int i = 0; i < fridge.Count; i++)
            {
                found.Add((Refrigerator)fridge[i]);
            }

            //Checks user input against Doors field in Refrigerator object, if they match add to the newly created list.
            List<Refrigerator> final = new List<Refrigerator>();
            for (int i = 0; i < found.Count; i++)
            {

                if (numOfDoors == 0)
                {
                    Console.WriteLine(found[i]);
                }
                else if (numOfDoors == 2)
                {

                    if (found[i].Doors == 2)
                    {

                        final.Add(found[i]);
                    }
                }
                else if (numOfDoors == 3)
                {

                    if (found[i].Doors == 3)
                    {

                        final.Add(found[i]);
                    }
                }
                else if (numOfDoors == 4)
                {

                    if (found[i].Doors == 4)
                    {

                        final.Add(found[i]);
                    }
                }
                else
                {

                    Console.WriteLine("Invalid entry!!!");
                    break;
                }
            }
            //Prints out list of Refrigerators that match the user's spec declaration.
            Console.WriteLine("MATCHING REFRIGERATORS: ");
            for (int i = 0; i < final.Count; i++)
            {

                Console.WriteLine(final[i]);
            }
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {

            //Displays options and asks for user input.
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");
            Console.WriteLine("Enter Grade: ");
            int grade = Convert.ToInt16(Console.ReadLine());

            //Creates new List of Appliance objects
            string fileName = @"appliances.txt";
            List<Appliance> vacuum = new List<Appliance>();
            string[] fileLines = File.ReadAllLines(fileName);

            //Iterate through txt file and divides the data into fields based on where the semicolon is.
            foreach (string line in fileLines)
            {
                if (line != "")
                {
                    string[] fields = line.Split(';');
                    string id = fields[0];
                    char id_firstChar = id[0];

                    //Checks the first character of the line and if it is a 2, adds a Vacuum obj to the list.
                    if (id_firstChar == '2')
                    {
                        vacuum.Add(new Vacuum(long.Parse(fields[0]), fields[1], Int16.Parse(fields[2]), decimal.Parse(fields[3]), fields[4], decimal.Parse(fields[5]), (fields[6]), short.Parse(fields[7])));
                    }
                }
            }

            //Downgrades the Appliance list to a Vacuum list
            List<Vacuum> downgraded = new List<Vacuum>();
            for (int x = 0; x < vacuum.Count; x++)
            {

                downgraded.Add((Vacuum)vacuum[x]);
            }

            //Creates second vacuum list and checks the grade that the user is looking for and adds to the list if it matches. Displays invalid option if outside of scope.
            List<Vacuum> gradedVacuum = new List<Vacuum>();
            for (int i = 0; i < vacuum.Count; i++)
            {

                if (grade == 0)
                {

                    gradedVacuum.Add((downgraded[i]));
                }
                else if (grade == 1)
                {

                    if (downgraded[i].Grade == "Residential")
                    {

                        gradedVacuum.Add(downgraded[i]);
                    }
                }
                else if (grade == 2)
                {

                    if (downgraded[i].Grade == "Commercial")
                    {

                        gradedVacuum.Add(downgraded[i]);
                    }
                }
                else
                {

                    Console.WriteLine("Invalid Input");
                    break;
                }

            }

            //Displays options for voltage and asks for user input
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");
            Console.WriteLine("Enter Voltage");
            int volt = Convert.ToInt16(Console.ReadLine());

            //Creates third list of Vacuums and checks to see if the BatteryVoltage matches the voltage the user is looking for.
            List<Vacuum> voltageVacuum = new List<Vacuum>();
            for (int i = 0; i < gradedVacuum.Count; i++)
            {
                if (volt == 0)
                {
                    voltageVacuum.Add((gradedVacuum[i]));
                }
                else if (volt == 1)
                {
                    if (gradedVacuum[i].BatteryVoltage == 18)
                    {

                        voltageVacuum.Add((gradedVacuum[i]));
                    }
                }
                else if (volt == 2)
                {
                    if (gradedVacuum[i].BatteryVoltage == 24)
                    {

                        voltageVacuum.Add((gradedVacuum[i]));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    break;
                }
            }
            //Prints out a List of Vacuums that match the users spec's declared.
            Console.WriteLine("MATCHING VACUUMS: ");
            for (int c = 0; c < voltageVacuum.Count; c++)
            {
                Console.WriteLine(voltageVacuum[c]);
            }
        }
        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("This is for testing");
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"

            // Get user input as string and assign to variable

            // Create character variable that holds room type

            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;

            // Create variable that holds list of 'found' appliances

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("This is for testing");
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"

            // Get user input as string and assign to variable

            // Create variable that holds sound rating

            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method

            // Create variable that holds list of found appliances

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("This is for testing");
            // Write "Appliance Types"

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"

            // Get user input as string and assign to appliance type variable

            // Write "Enter number of appliances: "

            // Get user input as string and assign to variable

            // Convert user input from string to int

            // Create variable to hold list of found appliances

            // Loop through appliances
            // Test inputted appliance type is "0"
            // Add current appliance in list to found list
            // Test inputted appliance type is "1"
            // Test current appliance type is Refrigerator
            // Add current appliance in list to found list
            // Test inputted appliance type is "2"
            // Test current appliance type is Vacuum
            // Add current appliance in list to found list
            // Test inputted appliance type is "3"
            // Test current appliance type is Microwave
            // Add current appliance in list to found list
            // Test inputted appliance type is "4"
            // Test current appliance type is Dishwasher
            // Add current appliance in list to found list

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
        }
    }
}
