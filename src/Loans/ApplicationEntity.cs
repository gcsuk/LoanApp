namespace Loans;

public record ApplicationEntity
{
    public required Guid Id { get; set; }
    public required double LoanAmount { get; set; }
    public required double AssetValue { get; set; }
    public required int CreditScore { get; set; }
    public bool ApprovalStatus { get; set; }
}