using HarmonyLib;

namespace SuperMonke.Patches
{
    //i need to make sure the scene is loaded
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Awake")]
    class SuperMonkePlayerPatch
    {
        private static void Postfix(GorillaLocomotion.Player __instance)
        {
            __instance.gameObject.AddComponent<Behaviours.SuperMonke>();
        }
    }
}
