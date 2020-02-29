namespace Solution1.Interfaces
{
    public interface ICalculation
    {
        void CalculatePayment(double hourValue, double monthlyHoursWorked);

        void PrintDetailsOnScreen();
    }
}
