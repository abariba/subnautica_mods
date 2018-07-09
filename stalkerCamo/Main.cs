using System;
using System.Reflection;
using Harmony;
using UnityEngine;
using Utilities;


namespace stalkerCamo
{
    public class Main
    {
        
        public static void Patch()
        {

                var harmony = HarmonyInstance.Create("com.abariba.stalkerCamo");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                Console.WriteLine("[stalkerCamo] Initialized");
            

        }
    }

    [HarmonyPatch(typeof(Stalker), "InitializeOnce")]
    internal class Stalker_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Stalker __instance)
        {
            try
            {
                var model = Findstalker.Find_stalker(__instance);
                if (model != null || true)
                {
                    var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                    var texture = TextureUtils.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff.png");
                    skinnedRenderer.sharedMaterial.mainTexture = texture;
                    Console.WriteLine("[stalkerCamo] Running as intended![this is a message to see if the stalker creature gets called properly]");
                }
                else
                {
                    Console.WriteLine("[stalkerCamo] An unknown error occured. Stalker game object is null");
                }
            }
            catch (Exception e)
            {
                string naam = "stalker";
                Console.WriteLine("[" + naam + "]" + e.Message);
                Console.WriteLine("[" + naam + "]" + e.StackTrace);
                Console.WriteLine("End error"+naam);
            }
        }

    }
}
