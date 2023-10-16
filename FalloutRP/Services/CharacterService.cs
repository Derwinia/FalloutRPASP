using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Entities.CharacterClasses;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FalloutRP.Services
{
    public class CharacterService
    {
        private readonly FalloutRPContext _falloutRPContext;
        public CharacterService(FalloutRPContext falloutRPContext)
        {
            _falloutRPContext = falloutRPContext;
        }
        public CharacterDTO? CharacterGetById(int id)
        {

            //.Include(r => r.Reputations)
            //.Include(p => p.Perks)
            //.Include(w => w.Weapons)
            //.Include(i => i.Inventory)
            //.ThenInclude(f => f.Foods)
            //.Include(i => i.Inventory)
            //.ThenInclude(a => a.Ammos)
            //.Include(i => i.Inventory)
            //.ThenInclude(d => d.Drinks)
            //.Include(i => i.Inventory)s
            //.ThenInclude(e => e.Equipements)
            //.Include(i => i.Inventory)
            //.ThenInclude(m => m.Materials)
            //.Include(i => i.Inventory)
            //.ThenInclude(c => c.Chemicals)
            Character character = _falloutRPContext.Characters
                .Include(s => s.Skill)
                .Include(b => b.BodyParts)
                .FirstOrDefault(c => c.Id == id);

            if (character == null)
            {
                throw new KeyNotFoundException("Cet utilisateur n'existe pas");
            }

            List<BodyPartDTO> bodyParts = new List<BodyPartDTO>();
            
                foreach (BodyPart bodypart in character.BodyParts)
                {
                BodyPartDTO bp = new BodyPartDTO
                {
                        Part = bodypart.Part,
                        PhysicalResilience = bodypart.PhysicalResilience,
                        RadiationResilience = bodypart.RadiationResilience,
                        EnergyResilience = bodypart.EnergyResilience,
                        HealthResilience = bodypart.HealthResilience,
                    };
                    bodyParts.Add(bp);
                }


            CharacterDTO characterDTO = new CharacterDTO()
            {
                Name = character.Name,
                Xp = character.Xp,
                XpToNext = character.XpToNext,
                Origin = character.Origin,
                Level = character.Level,
                MeleeBonus = character.MeleeBonus,
                Defence = character.Defence,
                Initiative = character.Initiative,
                HealthPoint = character.HealthPoint,
                HealthPointMax = character.HealthPointMax,
                PoisonResilience = character.PoisonResilience,
                Background = character.Background,
                Caps = character.Caps,
                MaxWeight = character.MaxWeight,
                Skills = new SkillDTO {
                    RightHanded = character.Skill.RightHanded,
                    LeftHanded = character.Skill.LeftHanded,
                    Athletics = character.Skill.Athletics,
                    Lockpicking = character.Skill.Lockpicking,
                    Speech = character.Skill.Speech,
                    Stealth = character.Skill.Stealth,
                    Medecine = character.Skill.Medecine,
                    Driving = character.Skill.Driving,
                    Repair = character.Skill.Repair,
                    Science = character.Skill.Science,
                    Survival = character.Skill.Survival,
                    Bartering = character.Skill.Bartering,
                    BareHands = character.Skill.BareHands,
                    MeleeWeapon = character.Skill.MeleeWeapon,
                    LightWeapon = character.Skill.LightWeapon,
                    HeavyWeapon = character.Skill.HeavyWeapon,
                    EnergieWeapon = character.Skill.EnergieWeapon,
                    ThrowingWeapon = character.Skill.ThrowingWeapon,
                    Explosive = character.Skill.Explosive,
                },
                BodyParts = bodyParts
            };
            return characterDTO;
        }
    }
}
