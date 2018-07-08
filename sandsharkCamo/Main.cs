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

    [HarmonyPatch(typeof(SandShark), "Start")]
    internal class SandShark_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(SandShark __instance)
        {
    
            var gameObject = __instance.gameObject;
            if(gameObject != null){

                var model = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO");


                var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();


                var texture = TextureUtils.LoadTexture(@"./QMods/sandsharkCamo/sandsharkCamoDiff.png");

                skinnedRenderer.sharedMaterial.mainTexture = texture;


                Console.WriteLine("[sandsharkCamo] Running as intended![this is a message to see if the sandshark creature gets called properly]");
            }
            else{
                Console.WriteLine("[sandsharkCamo] Error: SkinnedMeshRenderer not found on component");
            }
        

        }
        
    }
}
