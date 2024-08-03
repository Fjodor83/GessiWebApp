using GessiWebApp.API.Models;
namespace GessiWebApp.API.Services
{
    public interface IMovementService
    {
        IEnumerable<Movement> GetAllMovements();
        Movement GetMovementById(int id);
        void AddMovement(Movement movement);
        void UpdateMovement(Movement movement);
        void DeleteMovement(int id);
    }
}
