namespace CreditEvaluationApi;

public enum CreditType
{
    Direto,
    Consignado,
    PJ,
    PF,
    Imobiliario
}


public class CreditRequest
{
    public float VlLoan { get; set; }

    public CreditType Type { get; set; }

    public int QtyInstalment { get; set; }

    public DateOnly? StInstalmentDate { get; set; }

    public double InterestRate()
    {
        switch (this.Type)
        {
            case CreditType.Direto:
            return 0.02;
            
            case CreditType.Consignado:
            return 0.01;

            case CreditType.PJ:
            return 0.05;

            case CreditType.PF:
            return 0.03;

            case CreditType.Imobiliario:
            return 0.09;

            default:
            return 0;
        }
    }
}
