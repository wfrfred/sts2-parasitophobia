using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Assets;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Combat;

namespace Parasitophobia.Patch;

[HarmonyPatch(typeof(MonsterModel), nameof(MonsterModel.CreateVisuals))]
public static class MonsterModel_CreateVisuals_Patch
{
    static void Postfix(MonsterModel __instance, ref NCreatureVisuals __result)
    {
        if (__instance.GetType().Name != "PhrogParasite")
            return;

        var scene = PreloadManager.Cache.GetScene("res://Parasitophobia/Scenes/Seal.tscn")
                                       .Instantiate<NCreatureVisuals>(PackedScene.GenEditState.Disabled);

        if (scene != null)
            __result = scene;
    }
}