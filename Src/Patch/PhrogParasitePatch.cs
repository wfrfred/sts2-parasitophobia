using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;

namespace Parasitophobia.Patch;

[HarmonyPatch(typeof(MonsterModel), "VisualsPath", MethodType.Getter)]
public static class PhrogParasite_VisualsPath_Patch
{
    static void Postfix(MonsterModel __instance, ref string? __result)
    {
        if (__instance is PhrogParasite)
        {
            __result = "res://Parasitophobia/Scenes/Seal.tscn";
        }
    }
}