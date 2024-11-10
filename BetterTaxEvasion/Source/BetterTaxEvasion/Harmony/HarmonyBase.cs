namespace BetterTaxEvasion.Harmony
{
    public class HarmonyBase
    {
        private static HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony("com.edern.bettertaxevasion.patch");

        public static void ApplyPatches()
        {
            harmonyInstance.PatchAll();
        }
    }
}