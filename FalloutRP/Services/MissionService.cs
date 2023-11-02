using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
            if (missionCreateDTO != null) {
                Mission newMission = new Mission
                {
                    Name = missionCreateDTO.Name,
                    ShortDescription = missionCreateDTO.ShortDescription,
                    Description = missionCreateDTO.Description,
                    Status = "en cours"

                };
                if (missionCreateDTO.ConcernedPlayers.Count() > 0)
                {
                    List<Player> concernedPlayer = new List<Player>();

                    foreach (CharacterName character in missionCreateDTO.ConcernedPlayers)
                    {
                        Player player = _falloutRPContext.Players.FirstOrDefault(p => p.Character.Id == character.Id);
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
                else throw new Exception("Aucun joueur a été attribué a cette mission");
            }
        }

        public IEnumerable<MissionGroupByTeamDTO> MissionListAll()
        {
            List<MissionGroupByTeamDTO> teams = new List<MissionGroupByTeamDTO>();

            var missionsGroupByTeams = _falloutRPContext.Missions
                .Include(p => p.Players)
                .ThenInclude(t => t.Team)
                .Include(p => p.Players)
                .ThenInclude(t => t.Character)
                .ToList()
                .GroupBy(m => m.Players.FirstOrDefault()?.Team);
            
            foreach (var team in missionsGroupByTeams)
            {
                List<MissionDTO> missionsForTeam = new List<MissionDTO>();
                foreach (var mission in team)
                {
                    
                    List<CharacterName> concernedPlayer = new List<CharacterName>();
                    foreach (var player in mission.Players)
                    {
                        if(player.Character != null)
                        {
                            concernedPlayer.Add(new CharacterName()
                            {
                                Id = player.Character.Id,
                                Name = player.Character.Name,
                            });
                        }
                    }
                    missionsForTeam.Add(new MissionDTO()
                    {
                        Id = mission.Id,
                        Name = mission.Name,
                        ShortDescription = mission.ShortDescription,
                        Description = mission.Description,
                        Status = mission.Status,
                        ConcernedPlayer = concernedPlayer,
                    });
                }

                teams.Add(new MissionGroupByTeamDTO()
                {
                    Team = team.Key.Name,
                    Missions = missionsForTeam
                });
                
            }
            return teams;
        }

        public IEnumerable<MissionForPlayerDTO> MissionListOnePlayer(int idPlayer)
        {
            List<MissionForPlayerDTO> missions = new List<MissionForPlayerDTO>();

            var player = _falloutRPContext.Players
                .Include(p => p.Missions) 
                .FirstOrDefault(p => p.Id == idPlayer);

            if (player != null)
            {
                foreach (var mission in player.Missions)
                {
                    missions.Add(new MissionForPlayerDTO()
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
