using System;
using System.Reflection;
using Harmony;
using UnityEngine;
using Utilities;



namespace BoomerangCamo
{
    
    public class Main
    {
        public static void Patch()
        {
            string naam = "BoomerangCamo";
            var harmony = HarmonyInstance.Create("com.abariba."+naam+"");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Console.WriteLine("[" + naam + "] Initialized");
            
        }
    }

    [HarmonyPatch(typeof(Boomerang), "InitializeOnce")]
    internal class Boomerang_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Boomerang __instance)
        {
            string naam = "BoomerangCamo";
            try
            {
                var model = Findboomerang.Find_boomerang(__instance);
                Console.WriteLine("[" + naam + "]gameobject loaded succesfully");
                if (model != null)
                {
                    var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                    var texture = TextureUtils.LoadTexture(@"./QMods/BoomerangCamo/BoomerangCamoDiff.png", naam);
                    skinnedRenderer.sharedMaterial.mainTexture = texture;
                    Console.WriteLine("[" + naam + "] Running as intended![this is a message to see if the peeper creature gets called properly]");
                }
                else
                {
                    Console.WriteLine("[" + naam + "] An unknown error occured. Boomerang game object is null");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[" + naam + "]" + e.Message);
            }
        }

    }
}
