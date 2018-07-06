using System;
using System.Reflection;
using Harmony;
using UnityEngine;
using Utilities;


namespace SharkStalkerCamo
{
    public class Main
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.abariba.SharkStalkerCamo");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

        }
    }

    [HarmonyPatch(typeof(Creature), "Start")]
    //[HarmonyPatch(typeof(Stalker),"Start")]

//    you could workaround this
//have a main mod that hooks Creature.Start but have it loop through a static public List<CreaturePatches>
//you can then make QMods load it early and have your other mods load later on, again with QMods
//there shouldn't be any problems referencing the main mod from your other mods(edited)





    internal class SandSharkCamo_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(Stalker __instance)
        {

            var gameObject1 = __instance.gameObject;



            if (gameObject1 != null)
            {
                Console.WriteLine("[sandsharkCamo] Initialized");
                var sandshark = gameObject1.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO");
                var model = gameObject1.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO");


                var sandshark_skinnedRenderer = sandshark.GetComponent<SkinnedMeshRenderer>();


                var texture = TextureUtils.LoadTexture(@"./QMods/SharkStalkerCamo/sandsharkCamoDiff.png");

                sandshark_skinnedRenderer.sharedMaterial.mainTexture = texture;


                Console.WriteLine("[sandsharkCamo] Running as intended![this is a message to see if the sandshark creature gets called properly!]");
            }
            else
            {
                Console.WriteLine("[sandsharkCamo] Error: SkinnedMeshRenderer not found on component");
            }
            if (gameObject1 != null)
            {
                Console.WriteLine("[stalkerCamo] Initialized");
                var model2 = gameObject1.FindChild("Stalker_02").FindChild("snout_shark_geo");// .FindChild("Stalker_02").FindChild("snout_shark_geo");
                //var model2 = gameObject2.FindChild("Stalker_02").FindChild("snout_shark_geo");
                var skinnedRenderer2 = model2.GetComponent<SkinnedMeshRenderer>();
                //if (rnd == 0)
                //{
                var texture2 = TextureUtils.LoadTexture(@"./QMods/SharkStalkerCamo/stalkerCamoDiff.png");
                skinnedRenderer2.sharedMaterial.mainTexture = texture2;
                Console.WriteLine("[stalkerCamo] Running as intended![this is a message to see if the stalker creature gets called properly]");
            }
            else
            {
                Console.WriteLine("[stalkerCamo] An unknown error occured. Stalker game object is null");
            }

            return;
        }
    }
    



}
