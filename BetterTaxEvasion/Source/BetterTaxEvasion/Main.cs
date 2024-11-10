using BepInEx;
using BetterTaxEvasion.Harmony;

namespace BetterTaxEvasion
{
    [BepInPlugin("com.edern.bettertaxevasion", "Better Tax Evasion", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        private void Awake()
        {
            HarmonyBase.ApplyPatches();
        }
    }
}