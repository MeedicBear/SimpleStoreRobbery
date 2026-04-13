using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace SimpleStoreRobbery
{
    public class RobberyManager : MonoBehaviour
    {
        private void Update()
        {
            if (StoreRobberyPlugin.Instance == null || StoreRobberyPlugin.Instance.Zones == null)
                return;

            foreach (var zone in StoreRobberyPlugin.Instance.Zones)
            {
                if (zone.IsRobbing)
                    continue;

                if (Time.realtimeSinceStartup < zone.NextAvailableTime)
                    continue;

                foreach (var client in Provider.clients)
                {
                    UnturnedPlayer uPlayer = UnturnedPlayer.FromSteamPlayer(client);

                    if (zone.PlayerInside(uPlayer))
                    {
                        StartCoroutine(zone.RobberyRoutine(uPlayer));
                        return;
                    }
                }
            }
        }
    }
}
