using HarmonyLib;

namespace SuperMonke.Patches
{
    //i need to make sure the scene is loaded
    [HarmonyPatch(typeof(GorillaTagger))]
    [HarmonyPatch("Start")]
    class SuperMonkePlayerPatch
    {
        private static void Postfix(GorillaTagger __instance)
        {
            __instance.gameObject.AddComponent<Behaviours.SuperMonke>();
        }
    }
}
