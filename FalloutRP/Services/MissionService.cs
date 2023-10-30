using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
            Mission newMission = new Mission
            {
                Name = missionCreateDTO.Name,
                ShortDescription = missionCreateDTO.ShortDescription,
                Description = missionCreateDTO.Description,
                Status = "en cours"
                
            };

            List<Player> concernedPlayer = new List<Player>();

            foreach (int playerId in missionCreateDTO.ConcernedPlayers)
            {
                Player player = _falloutRPContext.Players.FirstOrDefault(p => p.Id == playerId);
                if (player != null)
                {
                    concernedPlayer.Add(player);
                }
                else
                {
                    throw new Exception("Joueur non trouvé");
                }
            }

            newMission.Players = concernedPlayer;

            _falloutRPContext.Missions.Add(newMission);
            _falloutRPContext.SaveChanges();
        }

        public IEnumerable<MissionGroupByTeamDTO> MissionListAll()
        {
            List<MissionGroupByTeamDTO> teamsMissions = new List<MissionGroupByTeamDTO>();

            var missionList = _falloutRPContext.Missions
                .Include(p => p.Players)
                .ThenInclude(t => t.Team)
                .ToList()
                .GroupBy(m => m.Players.FirstOrDefault()?.Team);
            
            foreach (var teamMission in missionList)
            {
                List<MissionSimpleDTO> missionsForTeam = new List<MissionSimpleDTO>();
                foreach (var mission in teamMission)
                {
                    missionsForTeam.Add(new MissionSimpleDTO()
                    {
                        Id = mission.Id,
                        Name = mission.Name,
                        ShortDescription = mission.ShortDescription,
                        Status = mission.Status,
                    });
                }

                teamsMissions.Add(new MissionGroupByTeamDTO()
                {
                    Team = teamMission.Key.Name,
                    Missions = missionsForTeam
                });
                
            }
            return teamsMissions;
        }

        public IEnumerable<MissionDetailDTO> MissionListOnePlayer(int idPlayer)
        {
            List<MissionDetailDTO> missions = new List<MissionDetailDTO>();

            var player = _falloutRPContext.Players
                .Include(p => p.Missions) 
                .FirstOrDefault(p => p.Id == idPlayer);

            if (player != null)
            {
                foreach (var mission in player.Missions)
                {
                    missions.Add(new MissionDetailDTO()
                    {
                        Id = mission.Id,
                        Name = mission.Name,
                        ShortDescription = mission.ShortDescription,
                        Description = mission.Description,
                        Status = mission.Status,
                    });
                }
            }
            return missions;
        }

        public MissionDTO MissionDetail(int idMission)
        {
            Mission? mission = _falloutRPContext.Missions
                .Include(m => m.Players)
                .FirstOrDefault(p => p.Id == idMission);

            MissionDTO missionToSend = null;

            if (mission != null)
            {
                List<int> listIdPlayer = new List<int>();
                foreach(Player idPlayer in mission.Players)
                {
                    listIdPlayer.Add(idPlayer.Id);
                }
                missionToSend = new MissionDTO()
                {
                    Id = mission.Id,
                    Name = mission.Name,
                    ShortDescription = mission.ShortDescription,
                    Description = mission.Description,
                    Status = mission.Status,
                    concernedPlayer = listIdPlayer
                };
            }
            else
            {
                throw new Exception("Mission non trouvé");
            }
            return missionToSend;
        }

        public void MissionUpdate(MissionDTO missionDTO)
        {
            Mission? mission = _falloutRPContext.Missions.FirstOrDefault(u => u.Id == missionDTO.Id);

            if (mission == null)
            {
                throw new KeyNotFoundException("Cette mission n'existe pas");
            }

            mission.Name = missionDTO.Name;
            mission.ShortDescription = missionDTO.ShortDescription;
            mission.Description = missionDTO.Description;
            mission.Status = missionDTO.Status;

            _falloutRPContext.SaveChanges();
        }

        public void MissionDelete(int idToDelete)
        {
            Mission? mission = _falloutRPContext.Missions.FirstOrDefault(p => p.Id == idToDelete);

            if (mission is null)
            {
                throw new KeyNotFoundException("La mission n'a pas été trouvé");
            }

            _falloutRPContext.Missions.Remove(mission);
            _falloutRPContext.SaveChanges();
        }
    }
}
