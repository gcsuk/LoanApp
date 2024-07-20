namespace Loans;

public interface IApplicationService
{
    bool MakeDecision(double loanAmount, double assetValue, int creditScore);
}