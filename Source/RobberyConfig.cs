using Rocket.API;
using System.Collections.Generic;

namespace SimpleStoreRobbery
{
    public class RobberyConfig : IRocketPluginConfiguration
    {
        public string PolicePermission;
        public bool RewardXP;
        public bool RewardMoney;
        public uint MoneyAmount;

        public List<RobberyZoneData> RobberyZones;

        public void LoadDefaults()
        {
            PolicePermission = "police.alert";
            RewardXP = true;
            RewardMoney = false;
            MoneyAmount = 50;

            RobberyZones = new List<RobberyZoneData>()
            {
                new RobberyZoneData()
                {
                    X = 100,
                    Y = 20,
                    Z = 100,
                    Radius = 6,
                    Duration = 20,
                    RewardXP = 50,
                    ZoneCooldown = 300
                }
            };
        }

        public class RobberyZoneData
        {
            public float X;
            public float Y;
            public float Z;
            public float Radius;
            public float Duration;
            public int RewardXP;
            public int ZoneCooldown;
        }
    }
}
