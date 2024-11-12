using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace AllRandomAltars.Harmony.Patches
{
    [HarmonyPatch(typeof(Zone))]
    [HarmonyPatch("<SpawnAltar>b__262_1")]
    public class Patch_SpawnAltar
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Callvirt && codes[i].operand is MethodInfo method &&
                    method.Name == "GetRandomReligion" && method.GetParameters().Length == 2)
                {
                    // Replace "false" by "true" 
                    codes[i - 1] = new CodeInstruction(OpCodes.Ldc_I4_1);

                    codes[i].operand = AccessTools.Method(typeof(ReligionManager), "GetRandomReligion", new[] { typeof(bool), typeof(bool) });
                    break;
                }
            }

            return codes.AsEnumerable();

        }
    }
}