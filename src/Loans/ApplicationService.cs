namespace Loans;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService()
    {
        // This would be injected in a proper app
        _applicationRepository = new ApplicationRepository();
    }

    public bool MakeDecision(double loanAmount, double assetValue, int creditScore)
    {
        if (loanAmount < 100000)
            return false;

        if (loanAmount > 1500000)
            return false;

        var ltv = loanAmount / assetValue * 100;

        if (loanAmount >= 1000000)
            return ltv <= 60 && creditScore >= 950;
        else
            return (ltv < 60 && creditScore >= 750)
                    || (ltv < 80 && creditScore >= 800)
                    || (ltv < 90 && creditScore >= 900);
    }

    public void SaveApplication(ApplicationEntity application)
    {
        try
        {
            // Insert would be async if the repo were real
            _applicationRepository.Insert(application);
        }
        catch (Exception ex)
        {
            // I dont actually like catching exceptions like this as middleware or some sort of "final call"
            // should sort it, but I wanted to show I know what a try/catch is :)

            // Log the exception here
            throw;
        }
    }

    public ReportModel GetReport()
    {
        var applications = _applicationRepository.GetList();

        var approvedTotal = applications.Count(a => a.ApprovalStatus);
        var declinedTotal = applications.Count(a => !a.ApprovalStatus);
        var totalLoanValue = applications.Sum(a => a.LoanAmount);
        var totalAssetValue = applications.Sum(a => a.AssetValue);

        var averageLoanToValue = totalLoanValue / totalAssetValue * 100;

         return new ReportModel(approvedTotal, declinedTotal, totalLoanValue, averageLoanToValue);
    }
}