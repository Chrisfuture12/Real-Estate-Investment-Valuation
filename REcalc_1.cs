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
            PurchasePrice = 0;
            ClosingCost = 0;
            HoldingCost = 0;
            RehabBudget = 0;
            ProjectRehabPeriod = 0;
            PercentOfCostFinanced = 0;
            Origination_DiscountPoints = 0;
            OtherClosingCostToLender = 0;
            InterestRate = 0;
            ARV = 0;
            MonthsToCompleteSale = 0;
            ProjectedResalePrice = 0;
            ProjectedCostOfSale = 0;
        }

       public REcalc_1(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l, double m )
        {
            PurchasePrice = a;
            ClosingCost =b;
            HoldingCost=c;
            RehabBudget=d;
            ProjectRehabPeriod=e;

            PercentOfCostFinanced=f;
            if (PercentOfCostFinanced < 1){
                PercentOfCostFinanced = f;
            } else {
                PercentOfCostFinanced = f/100;
            }
            
            Origination_DiscountPoints=g;
            if (Origination_DiscountPoints < 1){
                Origination_DiscountPoints = g;
            } else {
                Origination_DiscountPoints = g/100;
            }

            OtherClosingCostToLender=h;

            InterestRate = i;
            if (InterestRate < 1){
                InterestRate = i;
            } else {
                InterestRate = i/100;
            } 
                
            ARV=j;
            MonthsToCompleteSale=k;
            ProjectedResalePrice=l;

            ProjectedCostOfSale=m;
            if (ProjectedCostOfSale < 1){
                ProjectedCostOfSale =m;
            } else {
                ProjectedCostOfSale=m/100;
            }
            
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