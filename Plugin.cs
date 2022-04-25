using System;
using System.Reflection;

using HarmonyLib;
using BepInEx;

using Utilla;

namespace SuperMonke
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.3")]
    [ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        public bool modEnabled = false;
        public bool inRoom = false;

        public void Awake()
        {
            instance = this;
            var harmony = new Harmony(PluginInfo.GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnEnable()
        {
            modEnabled = true;
            Console.WriteLine("super enmnable");
        }

        public void OnDisable()
        {
            modEnabled = false;
            Console.WriteLine("super disable");
        }

        [ModdedGamemodeJoin]
        void JoinedModded()
        {
            inRoom = true;
            Console.WriteLine("joined modded room");
        }

        [ModdedGamemodeLeave]
        void LeftModded()
        {
            inRoom = false;
            Console.WriteLine("left modded room");
        }
    }
}
