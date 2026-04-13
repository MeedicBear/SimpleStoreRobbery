using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections;
using UnityEngine;

namespace SimpleStoreRobbery
{
    public class RobberyZone
    {
        public Vector3 Position;
        public float Radius;
        public float Duration;

        public int RewardXP;
        public int ZoneCooldown;

        public float NextAvailableTime = 0f;

        public bool IsRobbing = false;
        public UnturnedPlayer CurrentRobber;

        public RobberyZone(RobberyConfig.RobberyZoneData data)
        {
            Position = new Vector3(data.X, data.Y, data.Z);
            Radius = data.Radius;
            Duration = data.Duration;
            RewardXP = data.RewardXP;
            ZoneCooldown = data.ZoneCooldown;
        }

        public bool PlayerInside(UnturnedPlayer player)
        {
            return Vector3.Distance(player.Position, Position) <= Radius;
        }

        public IEnumerator RobberyRoutine(UnturnedPlayer player)
        {
            IsRobbing = true;
            CurrentRobber = player;

            AlertPolice(player);

            UnturnedChat.Say(player, $"Robbery started! Stay in the zone for {Duration} seconds.");

            float timer = Duration;

            while (timer > 0f)
            {
                if (!PlayerInside(player))
                {
                    UnturnedChat.Say(player, "You left the robbery zone. Robbery cancelled.");
                    IsRobbing = false;
                    yield break;
                }

                timer -= 1f;
                yield return new WaitForSeconds(1f);
            }

            GiveRewards(player);

            NextAvailableTime = Time.realtimeSinceStartup + ZoneCooldown;

            UnturnedChat.Say(player, $"Robbery successful! Zone is now on cooldown for {ZoneCooldown} seconds.");

            IsRobbing = false;
        }

        private void AlertPolice(UnturnedPlayer robber)
        {
            string perm = StoreRobberyPlugin.Instance.Configuration.Instance.PolicePermission;

            foreach (var client in Provider.clients)
            {
                UnturnedPlayer p = UnturnedPlayer.FromSteamPlayer(client);

                if (p.HasPermission(perm))
                {
                    UnturnedChat.Say(p, $"⚠ Police Alert: {robber.CharacterName} is robbing a store at {Position}!");
                }
            }
        }

        private void GiveRewards(UnturnedPlayer player)
        {
            var cfg = StoreRobberyPlugin.Instance.Configuration.Instance;

            if (cfg.RewardXP)
                player.Experience += RewardXP;

#if UCONOMY
            if (cfg.RewardMoney)
            {
                Uconomy.Instance.Database.IncreaseBalance(player.CSteamID.m_SteamID, cfg.MoneyAmount);
            }
#endif
        }
    }
}
