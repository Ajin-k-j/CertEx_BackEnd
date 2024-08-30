public interface IDepartmentNominationService
{
    Task<IEnumerable<DepartmentNominationDto>> GetNominationsByDepartmentAsync(int departmentId);
}
