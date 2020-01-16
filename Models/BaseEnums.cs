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
        NotRequired = 0,
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

    public enum AttributeValueType {
        NoYes = 0,
        List = 1,
        Text = 2,
        Date = 3
        
    }
}