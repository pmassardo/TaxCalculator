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

            



        }
    }
}
