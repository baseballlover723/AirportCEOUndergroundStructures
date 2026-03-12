using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace AirportCEOUndergroundStructures;

[BepInPlugin("org.airportceoundergroundstructures.baseballlover723", MODNAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("org.airportceomodloader.humoresque")]
public class AirportCEOUndergroundStructures : BaseUnityPlugin
{
    public static AirportCEOUndergroundStructures Instance { get; private set; }
    internal static Harmony Harmony { get; private set; }
    internal static ManualLogSource EELogger { get; private set; }
    internal static ConfigFile ConfigReference { get; private set; }

    internal const string MODNAME = "AirportCEO Underground Structures";

    private void Awake()
    {
        // Plugin startup logic
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        Harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        Harmony.PatchAll();

        Instance = this;
        EELogger = Logger;
        ConfigReference = Config;

        // Config
        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} is setting up config.");
        AirportCEOUndergroundStructuresConfig.SetUpConfig();
        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} finished setting up config.");
    }

    private void Start()
    {
        AirportCEOModLoader.WatermarkUtils.WatermarkUtils.Register(
            new AirportCEOModLoader.WatermarkUtils.WatermarkInfo("US", "0.1.0", true)
        );
    }
}
