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
            Console.WriteLine("[CamoPack] Initialized");

        }
    }

    [HarmonyPatch(typeof(Peeper), "InitializeOnce")]
    internal class Peeper_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Peeper __instance)
        {

            var gameObject = __instance.gameObject;
            Console.WriteLine("[CamoPack]gameobject2 loaded succesfully");
            

            var model = gameObject.FindChild("model").FindChild("peeper").FindChild("aqua_bird").FindChild("peeper");
            if (model != null)
            {
                
                var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                var texture = TextureUtils.LoadTexture(@"./QMods/PeeperCamo/sandsharkCamoDiff.png");

                skinnedRenderer.sharedMaterial.mainTexture = texture;
                                
                Console.WriteLine("[peeperCamo] Running as intended![this is a message to see if the peeper creature gets called properly]");
            }
            else
            {
                Console.WriteLine("[PeeperCamo slot1] Error: Model is null");
            }


        }

    }

}

