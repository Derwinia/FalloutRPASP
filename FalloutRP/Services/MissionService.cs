using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public IEnumerable<MissionGroupByTeamDTO> MissionListAll()
        {
            List<MissionGroupByTeamDTO> missions = new List<MissionGroupByTeamDTO>();

            var missionList = _falloutRPContext.Missions
                .Include(p => p.Players)
                .ThenInclude(t => t.Team)
                .ToList()
                .GroupBy(m => m.Players.FirstOrDefault()?.Team);
            
            foreach (var teamMission in missionList)
            {
                List<MissionDTO> missionsForTeam = new List<MissionDTO>();
                foreach (var mission in teamMission)
                {
                    missionsForTeam.Add(new MissionDTO()
                    {
                        Name = mission.Name,
                        ShortDescription = mission.ShortDescription,
                        Description = mission.Description,
                    });
                }

                missions.Add(new MissionGroupByTeamDTO()
                {
                    Team = teamMission.Key.Name,
                    Missions = missionsForTeam
                });
                
            }
            return missions;
        }
    }
}
