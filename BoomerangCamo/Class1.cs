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
            var harmony = HarmonyInstance.Create("com.abariba.BoomerangCamo");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Console.WriteLine("[BoomerangCamo] Initialized");

        }
    }

    [HarmonyPatch(typeof(Boomerang), "InitializeOnce")]
    internal class Boomerang_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Boomerang __instance)
        {

            var gameObject = __instance.gameObject;
            Console.WriteLine("[BoomerangCamo]gameobject loaded succesfully");


            var model = gameObject.FindChild("model").FindChild("Small_Fish_01");//FindChild("export_holder").
            if (model != null || true)
            {

                var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
                var texture = TextureUtils.LoadTexture(@"./QMods/BoomerangCamo/BoomerangCamoDiff.png");

                skinnedRenderer.sharedMaterial.mainTexture = texture;

                Console.WriteLine("[BoomerangCamo] Running as intended![this is a message to see if the boomerang creature gets called properly]");
            }
            else
            {
                Console.WriteLine("[BoomerangCamo slot1] Error: Model is null");
            }


        }

    }

}

