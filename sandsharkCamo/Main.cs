using System;
using System.Reflection;
using Harmony;
using UnityEngine;
using Utilities;


namespace sandsharkCamo
{
    public class Main
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.abariba.sandsharkCamo");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Console.WriteLine("[sandsharkCamo] Initialized");

        }
    }
    
    [HarmonyPatch(typeof(SandShark), "InitializeOnce")]
    internal class SandShark_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(SandShark __instance)
        {
            try
            {
                string naam1 = "Sandshark";
                var model = Findsandshark.Find_sandshark(__instance);
                if (model != null || true)
                {
                    var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                    var texture = TextureUtils.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff.png");
                    skinnedRenderer.sharedMaterial.mainTexture = texture;
                    Console.WriteLine("["+naam1+"] Running as intended![this is a message to see if the "+naam1+" creature gets called properly]");
                }
                else
                {
                    Console.WriteLine("["+naam1+"Camo] An unknown error occured. "+naam1+" game object is null");
                }
            }
            catch (Exception e)
            {
                string naam = "sandshark";
                Console.WriteLine("[" + naam + "]" + e.Message);
                Console.WriteLine("[" + naam + "]" + e.StackTrace);
                Console.WriteLine("End error" + naam);
            }
        }
        
    }
    

}
