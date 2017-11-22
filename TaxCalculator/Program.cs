/* 
 * Program Name:    TaxCalculator
 * Author:          Alfred Massardo
 * Date:            October 15, 2017
 * 
 * Description:     A console application which will prompt the user for...
 *                      -Total yearly income in dollars -- "Please enter the person's total yearly income in dollars: "
 *                      -It will then validate the income based on the follow...
 *                          **it is a real number
 *                          **minimum income 1.00 dollar(s) (inclusive) This number is arbitrary and does not represent a real world scenario.
 *                          **maximum income 1,000,000.00 dollar(s) (inclusive) This number is arbitrary and does not represent a real world scenario.                     
 * 
 *                      -Total tax paid to date -- "Please enter the person's total tax paid in dollars: "
 *                      -It will then validate the total tax paid based on the follow ranges...
 *                          **it is a real number
 *                          **minimum income 0.00 dollar(s) (inclusive) This number is arbitrary and does not represent a real world scenario.
 *                          **maximum weight 300,000.00 dollar(s) (inclusive) This number is arbitrary and does not represent a real world scenario. 
 * 
 *                      -Total income tax deductions -- "Please enter the person's total yearly income tax deductions in dollars: "
 *                      -It will then validae the deductions based on the follow ranges...
 *                          **it is a real number
 *                          **minimum income 0.00 dollar(s) (inclusive) This number is arbitrary and does not represent a real world scenario.
 *                          **maximum weight 250,000.00 dollar(s) (inclusive) This number is arbitrary and does not represent a real world scenario. 
 *                          
 *                  The application will not allow processing to take place until both entries are
 *                  valid. It will also prevent the user from ending the program unles they type the
 *                  key for end.
 *                                                                      
 *                  Once the user enters the above data and validated , the data will used to
 *                  calculate the total taxable income and the total tax payable, once the rate
 *                  is determine the tax rate after the tax  
 *                  already paid.... 
 *                   
 *                  totalTaxableIncome = totalYearlyIncome - totalTaxDeductions
 *                  
 *                  Next, the application will determine the income tax rate to use,
 *                  based on the following thresholds...
 *                      -less than (<) 10,000.00 assign 15.0%
 *                      -less than (<) 15,000.00 assign 17.5%
 *                      -less than (<) 25,000.00 assign 20.0%
 *                      -less than (<) 30,000.00 assign 25.0%
 *                      -less than (<) 40,000.00 assign 30.0%        
 *                      -less than (<) 50,000.00 assign 35.0%  
 *                      -otherwise assign 37.5%    
 *                                        
 *                   = (totalTaxableIncome * applicableTaxRate) 
 *                  
 *                  totalTaxCurrentlyDue = totalTaxPayable - taxesPaidToDate
 *                  
 *                  check to see if the amount owed is negative or positive... 
 *                  if it is negative set...
 *                      message = "owe"
 *                  otherwise,
 *                      message = "are owed"
 *                  
 *                  After calculating the totalTaxableIncome and totalTaxPayable the result will be 
 *                  displayed to the user...
 *                  "With a total yearly income of (totalYearlyIncome) and deductions of (totalTaxDeductions)\n,
 *                  your taxable income is (totalTaxableIncome), which means your applicable tax rate is (applicableTaxRate).\n 
 *                  Since you already paid (taxesPaidToDate) and your total tax payable is (totalTaxPayable); you (message)\n
 *                  (totalTaxCurrentlyDue).    
 *                  
 *                  The the program will pause until the user press a key on the keyboard.
 *                  "Press any key to end this application..."
 *                                
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            ///////////////
            // Constants
            ///////////////

            // Income threshold levels
            const double levelFirstIncome = 10000.00;   // Constant that holds the first income threshold
            const double levelSecondIncome = 15000.00;  // Constant that holds the second income threshold
            const double levelThirdIncome = 25000.00;   // Constant that holds the third income threshold
            const double levelFourthIncome = 30000.00;  // Constant that holds the fourth income threshold
            const double levelFifthIncome = 40000.00;   // Constant that holds the fifth income threshold
            //const double levelSixthIncome = 50000.00;   // Constant that holds the sixth income threshold

            const double incomeMinimum = 1.00;          // Constant that holds the income minimum
            const double incomeMaximum = 1000000.00;    // Constant that holds the income maximum

            const double taxesPaidToDateMinimum = 0.00;             // Constant that holds the taxes paid to date minimum
            const double taxesPaidToDateMaximum = 300000.00;        // Constant that holds the taxes paid to date maximum

            const double taxesDeductionsMinimum = 0.00;             // Constant that holds the tax deductions minimum
            const double taxesDeductionsMaximum = 250000.00;        // Constant that holds the tax deductions maximum

            // Tax rates
            const double rateFirstTax = 0.15;           // Constant that holds the first tax rate
            const double rateSecondTax = 0.175;         // Constant that holds the second tax rate
            const double rateThirdTax = 0.2;            // Constant that holds the third tax rate
            const double rateFourthTax = 0.25;          // Constant that holds the fourth tax rate
            const double rateFifthTax = 0.3;            // Constant that holds the fifth tax rate
            const double rateSixthTax = 0.35;           // Constant that holds the sixth tax rate

            const string messageOwe = "owe";                // Constant that holds the owe message
            const string messageAreOwed = "are owed";       // Constant that holds the are owed message
            const string messageOweNothing = "owe nothing"; // Constant that holds the owe nothing message

            ///////////////
            // Variables
            ///////////////

            double totalYearlyIncome = 0.00;            // Variable to hold the total yearly income, input by user
            double taxesPaidToDate = 0.00;              // Variable to hold the total taxes paid to date, input by user
            double totalTaxDeductions = 0.00;           // Variable to hold the total tax dedcutions, input by user
            double totalTaxableIncome = 0.00;           // Variable to hold the total taxable income, calculated in process
            double totalTaxPayable = 0.00;              // Variable to hold the total tax payable, calculated in process
            double applicableTaxRate = 0.00;            // Variable to hold the applicable tax rate, determined in process
            double totalTaxCurrentlyDue = 0.00;         // Variable to hold the total taxes due, determined in process

            string message = string.Empty;              // Variable to hold the message fragment to be displayed, determined in process

            ///////////////
            // Input
            ///////////////

            // Prompt and store the person's total yearly income in the totalYearlyIncome variable 
            // after the user input is converted to a double and 
            // it is validated agianst the income minimum and maximum range
            // and we also know it is a number.
            Console.Write("Please enter the person's total yearly income \n\t(between {0:c} and {1:c}): ", incomeMinimum, incomeMaximum ); // prompt the total yearly income
            // Keep asking the user until they input the correct total yearly income
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/while
            while ((!(Double.TryParse(Console.ReadLine(), out totalYearlyIncome)))    // check that the input is a double
                    || ((totalYearlyIncome < incomeMinimum)                           // compare the input against the minimum constant
                    || (totalYearlyIncome > incomeMaximum)))                          // compare the input against the maximum constant
            {
                // Prompt the user for the person's total yearly income.
                Console.Write("\n Error \nPlease enter the person's total yearly income \n\t(between {0:c} and {1:c}): ", incomeMinimum, incomeMaximum); // prompt the total yearly income

            }

            // Prompt and store the person's total taxes paid to date in the taxesPaidToDate variable 
            // after the user input is converted to a double and 
            // it is validated agianst the taxes paid to date minimum and maximum range
            // and we also know it is a number.
            Console.Write("Please enter the person's total taxes paid to date \n\t(between {0:c} and {1:c}): ", taxesPaidToDateMinimum, taxesPaidToDateMaximum); // prompt for the total taxes paid to date

            // Keep asking the user until they input the correct taxes paid to date
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/while
            while ((!(Double.TryParse(Console.ReadLine(), out taxesPaidToDate)))        // check that the input is a double
                    || ((taxesPaidToDate < taxesPaidToDateMinimum)                      // compare the input against the minimum constant
                    || (taxesPaidToDate > taxesPaidToDateMaximum)))                     // compare the input against the maximum constant
            {
                // Prompt the user for the person's taxes paid to date.
                Console.Write("\n Error \nPlease enter the person's total taxes paid to date \n\t(between {0:c} and {1:c}): ", taxesPaidToDateMinimum, taxesPaidToDateMaximum); // prompt for the total taxes paid to date

            }

            // Prompt and store the person's income tax deductions for the year in the totalTaxDeductions variable 
            // after the user input is converted to a double and 
            // it is validated agianst the taxes paid to date minimum and maximum range
            // and we also know it is a number.
            Console.Write("Please enter the person's total tax deductions for the year \n\t(between {0:c} and {1:c}): ", taxesDeductionsMinimum, taxesDeductionsMaximum); // prompt for the income tax deductions for the year

            // Keep asking the user until they input the correct taxes paid to date
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/while
            while ((!(Double.TryParse(Console.ReadLine(), out totalTaxDeductions)))        // check that the input is a double
                    || ((totalTaxDeductions < taxesDeductionsMinimum)                      // compare the input against the minimum constant
                    || (totalTaxDeductions > taxesDeductionsMaximum)))                     // compare the input against the maximum constant
            {
                // Prompt the user for the person's taxes paid to date.
                Console.Write("\n Error \nPlease enter the person's total tax deductions for the year \n\t(between {0:c} and {1:c}): ", taxesDeductionsMinimum, taxesDeductionsMaximum); // prompt for the income tax deductions for the year

            }

            ///////////////
            // Processing
            ///////////////

            // Calculate the total taxable income, which is calculated by subtracting the 
            // total yearly deductions from the total yearly income.
            totalTaxableIncome = totalYearlyIncome - totalTaxDeductions;

            // Determine the tax rate based on the taxable income
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else
            if (totalTaxableIncome < levelFirstIncome)           // If the totalTaxableIncome is less than levelFirstIncome
            {
                applicableTaxRate = rateFirstTax;               // Assign the rateFirstTax value to the applicableTaxRate
            }
            else if (totalTaxableIncome < levelSecondIncome)    // Otherwise, If the totalTaxableIncome is less than levelSecondIncome
            {
                applicableTaxRate = rateSecondTax;              // Assign the rateSecondTax value to the applicableTaxRate
            }
            else if (totalTaxableIncome < levelThirdIncome)     // Otherwise, If the totalTaxableIncome is less than levelThirdIncome
            {
                applicableTaxRate = rateThirdTax;               // Assign the rateThirdTax value to the applicableTaxRate
            }
            else if (totalTaxableIncome < levelFourthIncome)    // Otherwise, If the totalTaxableIncome is less than levelFourthIncome
            {
                applicableTaxRate = rateFourthTax;              // Assign the rateFourthTax value to the applicableTaxRate
            }
            else if (totalTaxableIncome < levelFifthIncome)     // Otherwise, If the totalTaxableIncome is less than levelFifthIncome
            {
                applicableTaxRate = rateFifthTax;               // Assign the rateFifthTax value to the applicableTaxRate
            }
            else                                                // Otherwise
            {
                applicableTaxRate = rateSixthTax;               // Assign the rateSixthTax value to the applicableTaxRate
            }
            
            // Calculate the total tax payable by multiplying the total 
            // taxable income by the applicable tax rate.
            totalTaxPayable = totalTaxableIncome * applicableTaxRate;

            // Calculate the total taxes currently due by subtracting the 
            // taxes paid to date from the total tax payable.
            totalTaxCurrentlyDue = totalTaxPayable - taxesPaidToDate;

            // Determine the message fragment that will be displayed
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else
            if (totalTaxCurrentlyDue > 0)       // If the amount currenty owed is greater than zero
            {
                message = messageOwe;           // Assign the messageOwe value to the message
            }
            else if(totalTaxCurrentlyDue < 0)   // Otherwise, If the amount currenty owed is less than zero
            {
                message = messageAreOwed;       // Assign the messageAreOwed value to the message
            }
            else                                // Otherwise,
            {
                message = messageOweNothing;    // Assign the messageOweNothing value to the message
            }

            ///////////////
            // Output
            ///////////////

            // Show the user the results of the calculation.
            Console.Write("\nWith a total yearly income of {0:c} and deductions of {1:c},\n" +
                    "your taxable income is {2:c}.\nThis means your applicable tax rate is {3:p}.\n" +
                    "Since you already paid {4:c} and your total tax payable is {5:c};\nyou... {6}, {7:c}.", 
                        totalYearlyIncome, 
                        totalTaxDeductions, 
                        totalTaxableIncome, 
                        applicableTaxRate, 
                        taxesPaidToDate, 
                        totalTaxPayable,
                        message,
                        totalTaxCurrentlyDue);

            // Ask the user to press any key to end the program
            // \n - use the newlijne escape character to move the output to the next line.
            Console.Write("\nPress any key to end this application...");

            // Use the Console ReadKey to pause the program until the user presses any key
            // to end the application.
            Console.ReadKey();

        }
    }
}
