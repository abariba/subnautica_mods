using System;
using System.Reflection;
using Harmony;
using UnityEngine;
using Utilities;


namespace PeeperCamo
{
    public class Main
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.abariba.PeeperCamo");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Console.WriteLine("[PeeperCamo] Initialized");

        }
    }

    [HarmonyPatch(typeof(Peeper), "InitializeOnce")]
    internal class Peeper_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Peeper __instance)
        {
            try
            {
                var model = Findpeeper.Find_peeper(__instance);
                Console.WriteLine("[PeeperCamo]gameobject loaded succesfully");
                if (model != null)
                {
                    var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                    var texture = TextureUtils.LoadTexture(@"./QMods/PeeperCamo/sandsharkCamoDiff.png", "Peeper");
                    skinnedRenderer.sharedMaterial.mainTexture = texture;
                    Console.WriteLine("[peeperCamo] Running as intended![this is a message to see if the peeper creature gets called properly]");
                }
                else
                {
                    Console.WriteLine("[PeeperCamo slot1] Error: Model is null");
                }
            }
            catch (Exception e)
            {
                string naam = "beeber";
                Console.WriteLine("[" + naam + "]" + e.Message);
            }
        }

    }

}

