namespace Loans;

internal sealed class ApplicationRepository : IApplicationRepository
{
    private readonly List<ApplicationEntity> _applications = [];

    public List<ApplicationEntity> GetList() => _applications;

    public ApplicationEntity? GetSingle(Guid id) => _applications.SingleOrDefault(a => a.Id == id);

    public void Insert(ApplicationEntity model) => _applications.Add(model);

    public void Delete(ApplicationEntity model) => _applications.Remove(model);
}