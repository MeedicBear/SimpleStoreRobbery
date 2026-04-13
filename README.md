# Simple Store Robbery Plugin  
### For Unturned — SDG Built Rocket

![License](https://img.shields.io/badge/License-MIT-blue.svg)
![Build](https://img.shields.io/badge/Build-Passing-brightgreen.svg)
![Platform](https://img.shields.io/badge/Platform-Unturned-1abc9c.svg)
![Rocket](https://img.shields.io/badge/Rocket-SDG%20Built--in-orange.svg)
![Status](https://img.shields.io/badge/Status-Active-success.svg)

A lightweight, configurable robbery system for Unturned servers.  
Players can rob stores, trigger police alerts, earn rewards, and face cooldowns per zone.  
Perfect for RP, PvE, and PvP servers wanting simple criminal gameplay without heavy systems.

---

## ✨ Features
- **Robbable Store Zones**  
  Define any number of robbery locations using XYZ coordinates and radius.

- **Police Alerts**  
  Notifies players with a specific permission when a robbery begins.

- **Configurable Rewards**  
  - XP  
  - Optional Uconomy money  
  - Adjustable per zone

- **Zone Cooldowns**  
  Each robbery zone has its own cooldown after a successful robbery.

- **Fail Conditions**  
  Robbery cancels if the player leaves the zone.

- **Optimized & Lightweight**  
  Uses a single manager component and efficient checks.

---

## 📦 Installation
1. Build the plugin using the included Visual Studio project.  
2. Place the compiled DLL into: 
Servers/<YourServer>/Rocket/Plugins/
3. Start the server once to generate the config file: 
Servers/<YourServer>/Rocket/Plugins/SimpleStoreRobbery/StoreRobbery.xml
4. Edit the config to match your robbery locations and reward settings.

---

## 🔐 Permissions

- **Police Alert Permission**
Players with this permission receive robbery notifications:
police.alert


---

## 🛠 Configuration (StoreRobbery.xml)

```xml
<RobberyConfig>
<PolicePermission>police.alert</PolicePermission>

<RewardXP>true</RewardXP>
<RewardMoney>false</RewardMoney>
<MoneyAmount>50</MoneyAmount>

<RobberyZones>
 <RobberyZoneData>
   <X>100</X>
   <Y>20</Y>
   <Z>100</Z>
   <Radius>6</Radius>
   <Duration>20</Duration>
   <RewardXP>50</RewardXP>
   <ZoneCooldown>300</ZoneCooldown>
 </RobberyZoneData>
</RobberyZones>
</RobberyConfig>
```
