using HarmonyLib;

namespace AirportCEOUndergroundStructures.UndergroundStructures.Patches;

[HarmonyPatch]
internal class FloorPatches
{
    [HarmonyPatch(typeof(PlaceableStructure), nameof(PlaceableStructure.CanBuildOnFloor))]
    [HarmonyPostfix]
    internal static void StructureFloorValidityPatch(PlaceableStructure __instance, int floor, ref bool __result)
    {
        if (
            floor < 0
            && AirportCEOUndergroundStructuresConfig.undergroundableStructureTypes.Contains(__instance.structureType)
        )
        {
            __result = true;
            return;
        }
    }
}
