using GessiWebApp.API.Models;
namespace GessiWebApp.API.Services
{
    public interface IPickingMissionService
    {
        IEnumerable<PickingMission> GetAllPickingMissions();
        PickingMission GetPickingMissionById(int id);
        void AddPickingMission(PickingMission pickingMission);
        void UpdatePickingMission(PickingMission pickingMission);
        void DeletePickingMission(int id);
    }
}
