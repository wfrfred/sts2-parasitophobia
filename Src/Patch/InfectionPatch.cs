using HarmonyLib;
using Godot;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace Parasitophobia.Patch;

[HarmonyPatch(typeof(CardModel), nameof(CardModel.PortraitPath), MethodType.Getter)]
public static class InfectionPatch
{
    private static readonly Dictionary<string, string> CustumPortraits = new(StringComparer.OrdinalIgnoreCase)
    {
        [nameof(Infection)] = "res://Parasitophobia/Images/Infection.png"
    };

    static void Postfix(CardModel __instance, ref string __result)
    {
        var className = __instance?.GetType().Name;
        if (string.IsNullOrEmpty(className)) return;
        if (!CustumPortraits.TryGetValue(className, out var path)) return;
        if (!ResourceLoader.Exists(path)) return;
        __result = path;
    }
}

[HarmonyPatch(typeof(Infection), nameof(Infection.HasBuiltInOverlay), MethodType.Getter)]
static class OverlayPatch
{
    static void Postfix(ref bool __result)
    {
        __result = false;
    }
}