namespace AllRandomAltars.Harmony
{
    public class HarmonyBase
    {
        private static HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony("com.edern.allrandomaltars.patch");

        public static void ApplyPatches()
        {
            harmonyInstance.PatchAll();
        }
    }
}