using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc 
{
    class REcalc{

        public static double getInput(string x){
            string input;
            Console.WriteLine("Please enter the "+ x);
            input = Console.ReadLine();
            double userIN = double.Parse(input);
            return userIN;
        }

        public static void display(string x){
            Console.WriteLine(x);

        }

        public static void Main(){
            double PPrice = getInput("Purchase price");
            double CCost = getInput("Closing cost");
            double HCost = getInput("Holding cost");
            double RBudget = getInput("Rehab budget");
            double PRehabPeriod = getInput("Estimated project rehab period (Months).");
            double PCostFinanced = getInput("percent of the total cost of which will be financed");
            double ODPoints = getInput(" origination/discount points associated with the loan");
            double OCCTLender = getInput("Other closing cost paid to lender");
            double Irate = getInput("interest rate of the loan");
            double ARV = getInput("After Repair Value (ARV)");
            double MTCsale = getInput("Months to complete sale (Listing to close)");
            double PRPrice = getInput("projected resale price");
            double PCOSale = getInput("projected cost of sale");
            
            REcalc_1 chris = new REcalc_1(PPrice,CCost,HCost,RBudget,PRehabPeriod,PCostFinanced,ODPoints, OCCTLender, Irate, ARV, MTCsale, PRPrice, PCOSale);
           
            double TCNeeded = chris.getTotCapNeeded();
            double MTCBFinanced = chris.getMaxFinancable(TCNeeded);
            double Interest = chris.getInterest(MTCBFinanced);
            double CHCAInterest = chris.getClosingHoldingInterest(Interest);
            double TLAmount = chris.getTotalLoanAmount(Interest,MTCBFinanced);
            double CRquired = chris.getCashRequired(TCNeeded, MTCBFinanced);
            double TAICost = chris.getTotalAllInCost(TCNeeded, Interest);
            double ACost = chris.getAgentCost();
            double PProfit = chris.getProjectedProfit(ACost,TAICost);
            double ROI = chris.getROI(PProfit,CRquired);

            if (PProfit > 0){
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tThe Profit is at $"+PProfit+". Which means you will not lose money on this deal.");
            }

            double [] summary = new double[10];
            summary[0] = TCNeeded;
            summary[1] = MTCBFinanced;
            summary[2] = Interest;
            summary[3] = CHCAInterest;
            summary[4] = TLAmount;
            summary[5] = CRquired;
            summary[6] = TAICost;
            summary[7] = ACost;
            summary[8] = PProfit;
            summary[9] = ROI;

            string [] names = new string[10];
            names[0] = "Total capital needed";
            names[1] = "Max amount that can be financed";
            names[2] = "Interest ($)";
            names[3] = "Closing/holding cost/interest added to loan";
            names[4] = "Total loan amount";
            names[5] = "upfront Cash required";
            names[6] = "Total all-in cost";
            names[7] = "Agent cost ($)";
            names[8] = "Projected profit";
            names[9] = "ROI (Return on income)";

            display("\tDeal summary:");
    
            for(int i = 0; i < summary.Length; i++){
                display("\t" + names[i] + ": " + summary[i]);
            } 

            Console.ReadKey();
            
        }
    }
}
