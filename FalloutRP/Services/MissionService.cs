using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;
using Microsoft.EntityFrameworkCore;

namespace FalloutRP.Services
{
    public class MissionService
    {
        private readonly FalloutRPContext _falloutRPContext;
        public MissionService(FalloutRPContext falloutRPContext)
        {
            _falloutRPContext = falloutRPContext;
        }

        public void MissionCreate(MissionCreateDTO missionCreateDTO)
        {
            
        }

        public IEnumerable<MissionDTO> MissionListAll()
        {
            List<MissionDTO> missions = new List<MissionDTO>();

            var missionList = _falloutRPContext.Missions
                .Include(p => p.Players)
                .ThenInclude(t => t.Team)
                .ToList()
                .GroupBy(m => m.Players.FirstOrDefault()?.Team);
            
            foreach (var teamMission in missionList)
            {
                foreach (var mission in teamMission)
                {
                    missions.Add(new MissionDTO()
                    {
                        Name = mission.Name,
                        ShortDescription = mission.ShortDescription,
                        Description = mission.Description,
                    });
                }
            }
            return missions;
        }
    }
}
