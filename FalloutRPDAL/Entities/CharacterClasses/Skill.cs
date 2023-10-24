using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Skill
    {
        public int Id { get; set; }
        public bool RightHanded { get; set; }
        public bool LeftHanded { get; set; }
        public bool Athletics { get; set; }
        public int Athleticslvl { get; set; }
        public bool Lockpicking { get; set; }
        public int Lockpickinglvl { get; set; }
        public bool Speech { get; set; }
        public int Speechlvl { get; set; }
        public bool Stealth { get; set; }
        public int Stealthlvl { get; set; }
        public bool Medecine { get; set; }
        public int Medecinelvl { get; set; }
        public bool Driving { get; set; }
        public int Drivinglvl { get; set; }
        public bool Repair { get; set; }
        public int Repairlvl { get; set; }
        public bool Science { get; set; }
        public int Sciencelvl { get; set; }
        public bool Survival { get; set; }
        public int Survivallvl { get; set; }
        public bool Bartering { get; set; }
        public int Barteringlvl { get; set; }
        public bool BareHands { get; set; }
        public int BareHandslvl { get; set; }
        public bool MeleeWeapon { get; set; }
        public int MeleeWeaponlvl { get; set; }
        public bool LightWeapon { get; set; }
        public int LightWeaponlvl { get; set; }
        public bool HeavyWeapon { get; set; }
        public int HeavyWeaponlvl { get; set; }
        public bool EnergieWeapon { get; set; }
        public int EnergieWeaponlvl { get; set; }
        public bool ThrowingWeapon { get; set; }
        public int ThrowingWeaponlvl { get; set; }
        public bool Explosive { get; set; }
        public int Explosivelvl { get; set; }
        public bool Game { get; set; }
        public int Gamelvl { get; set; }

        // Foreign Keys
        public int CharacterId { get; set; }
    }
}
