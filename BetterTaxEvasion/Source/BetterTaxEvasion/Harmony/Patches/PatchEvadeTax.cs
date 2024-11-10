using HarmonyLib;
using UnityEngine;

namespace BetterTaxEvasion.Harmony.Patches
{
    [HarmonyPatch(typeof(Faction))]
    [HarmonyPatch("EvadeTax")]
    public class PatchEvadeTax
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result, int v, bool evasion)
        {
            if (!evasion)
            {
                return true; // Run original code
            }

            int evasionLevel = 0;
            foreach (FactionBranch child in EClass.pc.faction.GetChildren())
            {
                evasionLevel += child.Evalue(2119); // 2119 is the ID of the "Tax Evasion" policy
            }

            if (evasionLevel < 1)
            {
                return true; // Run original code
            }

            double taxRate = 0.8 * 1.0 / (Mathf.Exp(Mathf.Sqrt(0.1f*(evasionLevel - 1))));
            __result = (int) (taxRate * v);
            return false;
        }
    }
}