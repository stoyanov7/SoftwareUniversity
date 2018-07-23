namespace Banicharnica.Core.Contracts
{
    using ModelsDto;

    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int employeeId);
    }
}