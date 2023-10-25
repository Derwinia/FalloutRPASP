﻿using FalloutRP.DTO;
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
                        Id = mission.Id,
                        Name = mission.Name,
                        ShortDescription = mission.ShortDescription,
                        Description = mission.Description,
                        Status = mission.Status,
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

        public IEnumerable<MissionDTO> MissionListOnePlayer(int idPlayer)
        {
            List<MissionDTO> missions = new List<MissionDTO>();

            var player = _falloutRPContext.Players
                .Include(p => p.Missions) 
                .FirstOrDefault(p => p.Id == idPlayer);

            if (player != null)
            {
                foreach (var mission in player.Missions)
                {
                    missions.Add(new MissionDTO()
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