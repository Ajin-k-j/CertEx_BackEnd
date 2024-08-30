public class DepartmentNominationService : IDepartmentNominationService
{
    private readonly IDepartmentNominationRepository _repository;

    public DepartmentNominationService(IDepartmentNominationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DepartmentNominationDto>> GetNominationsByDepartmentAsync(int departmentId)
    {
        return await _repository.GetNominationsByDepartmentAsync(departmentId);
    }
}
