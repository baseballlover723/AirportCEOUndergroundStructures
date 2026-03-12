using System.Collections.Generic;
using BepInEx.Configuration;

namespace AirportCEOUndergroundStructures;

internal static class AirportCEOUndergroundStructuresConfig
{
    internal static readonly HashSet<Enums.StructureType> undergroundableStructureTypes = new();

    internal static void SetUpConfig()
    {
        SetUpStructure(Enums.StructureType.AirportPoliceStation, "Airport Police Station");
        SetUpStructure(Enums.StructureType.EmergencyResponseStation, "Emergency Response Station");
        SetUpStructure(Enums.StructureType.CateringDepot, "Catering Depot");
        SetUpStructure(Enums.StructureType.WasteDepot, "Waste Depot");
    }

    private static ConfigEntry<bool> SetUpStructure(Enums.StructureType type, string name, bool defaultValue = true)
    {
        string desc = $"Allow the {name} to be built underground.";
        ConfigEntry<bool> config = AirportCEOUndergroundStructures.ConfigReference.Bind("Structures", name, true, desc);
        config.SettingChanged += (IChannelSender, args) =>
        {
            Sync(type, config);
        };
        Sync(type, config); // initialize the intitial value
        return config;
    }

    internal static void Sync(Enums.StructureType type, ConfigEntry<bool> enabled)
    {
        if (enabled.Value)
        {
            undergroundableStructureTypes.Add(type);
        }
        else
        {
            undergroundableStructureTypes.Remove(type);
        }
    }
}
