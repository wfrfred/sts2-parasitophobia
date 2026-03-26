using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Nodes.Vfx;

namespace Parasitophobia.Patch;

[HarmonyPatch(typeof(NWormyImpactVfx))]
public static class NWormyImpactVfx_Create_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(NWormyImpactVfx.Create), [typeof(Creature)])]
    static bool Prefix0(NWormyImpactVfx __instance, ref NWormyImpactVfx? __result)
    {
        __result = null;
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(NWormyImpactVfx.Create), [typeof(Vector2), typeof(Vector2)])]
    static bool Prefix1(NWormyImpactVfx __instance, ref NWormyImpactVfx? __result)
    {
        __result = null;
        return false;
    }
}