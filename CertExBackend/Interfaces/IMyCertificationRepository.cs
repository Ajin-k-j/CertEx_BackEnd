using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface IMyCertificationRepository
    {
        IEnumerable<MyCertification> GetAllMyCertifications();
        MyCertification GetMyCertificationById(int id);
        void AddMyCertification(MyCertification certification);
        void UpdateMyCertification(MyCertification certification);
        void DeleteMyCertification(int id);
    }
}
