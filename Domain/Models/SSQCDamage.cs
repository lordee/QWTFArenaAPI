namespace qwtfarena.Domain.Models
{
    public class SSQCDamage
    {
        public int DamageLineID;
        public int GameID;
        public float GameTime;
        public SSQCPlayer Attacker;
        public SSQCPlayer Target;
        public string WeaponType;
        public float Damage;
        public int Shot_ID;
        public float VHeight;
        public int Killed;
        public string DeathType;
        public int HadFlag;
    }
}