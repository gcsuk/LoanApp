namespace Loans;

internal interface IApplicationRepository
{
    List<ApplicationEntity> GetList();

    ApplicationEntity? GetSingle(Guid id);

    void Insert(ApplicationEntity model);

    void Delete(ApplicationEntity model);
}