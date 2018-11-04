using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class REcalc_1 {
        public double PurchasePrice;
        public double ClosingCost;
        public double HoldingCost;

        public double RehabBudget;
        public double ProjectRehabPeriod;
        public double PercentOfCostFinanced;
        public double Origination_DiscountPoints;
        public double OtherClosingCostToLender;

        public double ARV;
        public double MonthsToCompleteSale;
        public double ProjectedResalePrice;
        public double ProjectedCostOfSale;
        public double InterestRate;

        public REcalc_1() // Zero parameters
        {
            PurchasePrice = 1;
            ClosingCost = 1;
            HoldingCost = 1;
            RehabBudget = 1;
            ProjectRehabPeriod = 1;
            PercentOfCostFinanced = 1/100;
            Origination_DiscountPoints = 1/100;
            OtherClosingCostToLender = 1;
            InterestRate = 1/100;
            ARV = 1;
            MonthsToCompleteSale = 1;
            ProjectedResalePrice = 1;
            ProjectedCostOfSale = 1/100;
        }

       public REcalc_1(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m )
        {
            PurchasePrice = a;
            ClosingCost =b;
            HoldingCost=c;
            RehabBudget=d;
            ProjectRehabPeriod=e;
            PercentOfCostFinanced=f/100;
            Origination_DiscountPoints=g/100;
            OtherClosingCostToLender=h;
            InterestRate = i/100;
            ARV=j;
            MonthsToCompleteSale=k;
            ProjectedResalePrice=l;
            ProjectedCostOfSale=m/100;
            
        }

        public double getTotCapNeeded(){
            return PurchasePrice + ClosingCost + HoldingCost + RehabBudget;
        }
        public double getMaxFinancable(double TotCapNeeded){
            return (TotCapNeeded - ClosingCost - HoldingCost) * PercentOfCostFinanced;
        }
        public double getInterest(double MaxFinancable){
            return InterestRate*MaxFinancable;
        }
        public double getClosingHoldingInterest(double Interest) {
            return ClosingCost + HoldingCost + Interest;
        }
        public double getTotalLoanAmount(double Interest,double MaxFinancable){
            return  ClosingCost + HoldingCost+ Interest+ MaxFinancable;
        }
        public double getCashRequired(double TotCapNeeded, double MaxFinancable){
            return TotCapNeeded - (ClosingCost+HoldingCost+MaxFinancable);
        }
        public double getTotalAllInCost(double TotCapNeeded, double Interest) {
            return TotCapNeeded+Interest;
        }
        public double getAgentCost() {
            return ProjectedCostOfSale*ProjectedResalePrice;
        }
        public double getProjectedProfit(double AgentCost, double TotalAllInCost) {
            return ProjectedResalePrice-AgentCost-TotalAllInCost;
        }
        public double getROI(double ProjectedProfit, double CashRequired){
            return ProjectedProfit/CashRequired *100;
        }
        public double getARVP(double TotalAllInCost){
            return (TotalAllInCost/ARV)*100;
        }
    }
}