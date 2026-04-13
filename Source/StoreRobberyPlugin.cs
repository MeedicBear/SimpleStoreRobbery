using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleStoreRobbery
{
    public class StoreRobberyPlugin : RocketPlugin<RobberyConfig>
    {
        public static StoreRobberyPlugin Instance;

        public List<RobberyZone> Zones = new List<RobberyZone>();
        private GameObject _managerObject;

        protected override void Load()
        {
            Instance = this;

            Zones.Clear();
            foreach (var zoneData in Configuration.Instance.RobberyZones)
            {
                Zones.Add(new RobberyZone(zoneData));
            }

            _managerObject = new GameObject("StoreRobberyManager");
            _managerObject.AddComponent<RobberyManager>();
            DontDestroyOnLoad(_managerObject);

            Logger.Log("SimpleStoreRobbery loaded.");
        }

        protected override void Unload()
        {
            if (_managerObject != null)
                Destroy(_managerObject);

            Zones.Clear();
            Instance = null;

            Logger.Log("SimpleStoreRobbery unloaded.");
        }
    }
}
