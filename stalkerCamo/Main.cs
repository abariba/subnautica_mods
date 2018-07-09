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
    internal class Stalker_Start_Patch
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Stalker __instance)
        {
            
            //var rnd = new System.Random().Next(0, 4);
            var gameObject = __instance.gameObject;
           
            var model = gameObject.FindChild("Stalker_02").FindChild("snout_shark_geo");
            if (model != null)
            {
                var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                //if (rnd == 0)
                //{
                var texture = TextureUtils.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff.png");
                skinnedRenderer.sharedMaterial.mainTexture = texture;

            }
            else{
                Console.WriteLine("[stalkerCamo] An unknown error occured. Stalker game object is null");
            }
            //}
            //else if(rnd == 1)
            //{
            //    var texture = TextureUtils.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff_0.png");
            //    skinnedRenderer.sharedMaterial.mainTexture = texture;
            // }
            //else if(rnd == 2)
            //{
            //   var texture = TextureUtils.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff_1.png");
            //   skinnedRenderer.sharedMaterial.mainTexture = texture;
            //}


        }

    }
}
