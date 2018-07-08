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
            var harmony = HarmonyInstance.Create("com.abariba.CamoPack");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Console.WriteLine("[CamoPack] Initialized");
        }


    }

    [HarmonyPatch(typeof(Creature), "Start")]
    internal class SandShark_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Creature __instance)
        {

            var gameObject = __instance.gameObject;
            Console.WriteLine("[CamoPack]gameobject loaded succesfully");



            if (gameObject != null)
            {

                var model = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO");
                
                var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();

                var texture = TextureUtils.LoadTexture(@"./QMods/sandsharkCamo/sandsharkCamoDiff.png");

                skinnedRenderer.sharedMaterial.mainTexture = texture;

                //var model2 = gameObject.FindAncestor();



                Console.WriteLine("[sandsharkCamo] Running as intended![this is a message to see if the sandshark creature gets called properly]");
                Console.WriteLine("[peeperCamo] Running as intended![this is a message to see if the peeper creature gets called properly]");
            }
            else
            {
                Console.WriteLine("[CamoPack] Error: SkinnedMeshRenderer not found on component");
            }


        }

    }

    //var gameObject2 = __instance.gameObject;
    //onsole.WriteLine("[CamoPack]gameobject2 loaded succesfully");

    //var model2 = gameObject3.FindChild("Peeper").FindChild("model").FindChild("peeper").FindChild("aqua_bird").FindChild("peeper");
    //Destroy(gameObject);

    //var texture2 = TextureUtils.LoadTexture(@"./QMods/sandsharkCamo/sandsharkCamoDiff.png");



    //var skinnedRenderer2 = model2.GetComponent<SkinnedMeshRenderer>();
    //skinnedRenderer2.sharedMaterial.mainTexture = texture2;
}

