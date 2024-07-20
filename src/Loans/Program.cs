var exitCode = ConsoleKey.Enter;
var service = new Loans.ApplicationService();

Console.WriteLine("Welcome to the loan application system!");
Console.WriteLine("***************************************");
Console.WriteLine();

while (exitCode is not ConsoleKey.Q)
{
    Console.Write("Please enter the loan amount: ");
    var loanAmountInput = Console.ReadLine();

    int.TryParse(loanAmountInput, out var loanAmount);

    // This needs validating but in the interest of time I omitted it. Same for other inputs

    Console.Write("Please enter the asset value: ");
    var assetValueInput = Console.ReadLine();

    double.TryParse(assetValueInput, out var assetValue);

    Console.Write("Please enter the credit score: ");
    var creditScoreInput = Console.ReadLine();

    int.TryParse(creditScoreInput, out var creditScore);

    var status = service.MakeDecision(loanAmount, assetValue, creditScore);

    var application = new Loans.ApplicationEntity
    {
        Id = Guid.NewGuid(),
        LoanAmount = loanAmount,
        AssetValue = assetValue,
        CreditScore = creditScore,
        ApprovalStatus = status
    };

    service.SaveApplication(application);

    var report = service.GetReport();

    var statusText = status ? "Approved" : "Declined";

    Console.WriteLine($"Your Application Was {statusText}");
    Console.WriteLine();
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"Number of applications approved: {report.ApprovedTotal}");
    Console.WriteLine($"Number of applications declined: {report.DeclinedTotal}");
    Console.WriteLine($"Total loan amount: {report.TotalLoanValue:0.00}");
    Console.WriteLine($"Average LTV: {report.AverageLoanToValue:0.00}%");
    Console.WriteLine("--------------------------------");
    Console.WriteLine();
    Console.WriteLine("Press Q to Quit, or any other key to apply again");

    exitCode = Console.ReadKey().Key;

    Console.Clear();
}