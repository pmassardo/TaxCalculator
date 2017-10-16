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
            const double levelSixthIncome = 50000.00;   // Constant that holds the sixth income threshold

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

            const string messageOwe = "owe";            // Constant that holds the owe message
            const string messageAreOwed = "are owed";   // Constant that holds the are owed message

            ///////////////
            // Variables
            ///////////////

            double totalYearlyIncome = 0.00;            // Variable to hold the total yearly income, input by user
            double totalTaxDeductions = 0.00;           // Variable to hold the total tax dedcutions, input by user
            double taxesPaidToDate = 0.00;              // Variable to hold the total taxes paid to date, input by user
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

            // Keep asking the user until they input the correct height
            while ((!(Double.TryParse(Console.ReadLine(), out totalYearlyIncome)))    // check that the input is a double
                    || ((totalYearlyIncome < incomeMinimum)                           // compare the input against the minimum constant
                    || (totalYearlyIncome > incomeMaximum)))                          // compare the input against the maximum constant
            {
                // Prompt the user for the person's height in inches.
                Console.Write("\n Error \nPlease enter the person's total yearly income \n\t(between {0:c} and {1:c}): ", incomeMinimum, incomeMaximum); // prompt the total yearly income

            }



            // Ask the user to press any key to end the program
            // \n - use the newlijne escape character to move the output to the next line.
            Console.Write("\nPress any key to end this application...");

            // Use the Console ReadKey to pause the program until the user presses any key
            // to end the application.
            Console.ReadKey();

        }
    }
}
