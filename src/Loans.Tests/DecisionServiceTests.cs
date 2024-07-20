namespace Loans.Tests;

public class DecisionServiceTests
{
    [Fact]
    public void When_loan_amount_less_than_minimum_then_decline_application()
    {
        var service = new ApplicationService();

        var status = service.MakeDecision(50000, 100000, 500);

        Assert.False(status);
    }

    [Fact]
    public void When_loan_amount_more_than_maximum_then_decline_application()
    {
        var service = new ApplicationService();

        var status = service.MakeDecision(2000000, 100000, 500);

        Assert.False(status);
    }

    [Theory]
    [InlineData(1400000, 950, false)]
    [InlineData(2000000, 949, false)]
    [InlineData(2000000, 950, true)]
    public void When_loan_amount_more_than_threshold_then_verify_credit_score_and_ltv(double assetValue, int creditScore, bool expectedStatus)
    {
        var service = new ApplicationService();

        var actualStatus = service.MakeDecision(1000000, assetValue, creditScore);

        Assert.Equal(expectedStatus, actualStatus);
    }

    [Theory]
    [InlineData(599999, 1000000, 749, false)]
    [InlineData(799999, 1000000, 799, false)]
    [InlineData(899999, 1000000, 899, false)]
    [InlineData(599999, 1000000, 750, true)]
    [InlineData(799999, 1000000, 800, true)]
    [InlineData(899999, 1000000, 900, true)]
    public void When_loan_amount_less_than_threshold_then_verify_credit_score_and_ltv(double loanAmount, double assetValue, int creditScore, bool expectedStatus)
    {
        var service = new ApplicationService();

        var actualStatus = service.MakeDecision(loanAmount, assetValue, creditScore);

        Assert.Equal(expectedStatus, actualStatus);
    }

    [Fact]
    public void When_loan_amount_more_than_ninety_percent_ltv_then_decline_application()
    {
        var service = new ApplicationService();

        var status = service.MakeDecision(910000, 1000000, 500);

        Assert.False(status);
    }
}