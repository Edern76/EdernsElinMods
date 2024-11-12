using AllRandomAltars.Harmony;
using BepInEx;

namespace AllRandomAltars
{
    [BepInPlugin("com.edern.allrandomaltars", "Better Tax Evasion", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        private void Awake()
        {
            HarmonyBase.ApplyPatches();
        }
    }
}