namespace CreditEvaluationApi;

public class CreditEvaluation
{
    public string? Status { get; set; }

    public double? VlFinal { get; set; }
    
    public double? VlInterest { get; set; }

    public CreditEvaluation(CreditRequest request)
    {        
        this.Status = "Aprovado";
        double loanPeriod = request.QtyInstalment/12.0;

        this.checkLoanValue(request);
        this.checkQtyInstalment(request);
        this.checkStInstalDate(request);
        this.setValues(request.InterestRate(), loanPeriod, request.VlLoan);
    }

    private void checkLoanValue(CreditRequest request)
    {
        double maxLoanValue = Math.Pow(10,6);
        double minLoanValue = request.Type == CreditType.PJ ? 15000 : 0;
        if (!(minLoanValue <= request.VlLoan && request.VlLoan <= maxLoanValue))
            this.Status = "Recusado";
        
    }

    private void checkQtyInstalment(CreditRequest request)
    {
        int minQtyInstalment = 5;
        int maxQtyInstalment = 72;

        if (!(minQtyInstalment <= request.QtyInstalment && request.QtyInstalment <= maxQtyInstalment))
            this.Status = "Recusado";

    }

    private void checkStInstalDate(CreditRequest request)
    {
        DateOnly minStInstalmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(15));
        DateOnly maxStInstalmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(40));

        if (!(minStInstalmentDate <= request.StInstalmentDate && request.StInstalmentDate <= maxStInstalmentDate))
            this.Status = "Recusado";
    }

    private void setValues(double rate, double period, double vlPrincipal)
    {
        this.VlFinal = vlPrincipal * Math.Pow((1+rate), period);
        this.VlInterest = this.VlFinal - vlPrincipal;
    }

}
