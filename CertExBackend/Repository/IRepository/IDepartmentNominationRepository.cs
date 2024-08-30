public interface IDepartmentNominationRepository
{
    Task<IEnumerable<DepartmentNominationDto>> GetNominationsByDepartmentAsync(int departmentId);
}
