namespace Rentless.Models
{
    public enum AddressType
    {
        Billing = 0,
        Shipping =1,
        Work = 2,
        Home = 3,
        Office = 4
    }

    public enum VerificationStatus
    {
        NotStarted = 0,
        InProcess = 1,
        Approved = 2,
        NotApproved = 3
    }

    public enum AccounType 
    {
        Posting = 0,
        Heading = 1,
        Total = 2,
        BeginTotal = 3,
        EndTotal =4
    }

    public enum IncomeBalance {
        IncomeStatement = 0
        ,BalanceSheet  = 1
    }
}