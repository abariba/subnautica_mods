using System;
using System.Reflection;
using Harmony;
using UnityEngine;
using Utilities;


namespace ReaperCamo
{
    public class Main
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.abariba.ReaperCamo");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

        }
    }

    
    //[HarmonyPatch(typeof(Stalker),"Start")]

//    you could workaround this
//have a main mod that hooks Creature.Start but have it loop through a static public List<CreaturePatches>
//you can then make QMods load it early and have your other mods load later on, again with QMods
//there shouldn't be any problems referencing the main mod from your other mods(edited)





    internal class SandSharkCamo_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(int.MinValue)]
        static void Postfix(ReaperLeviathan __instance)
        {
            string naam = "Reaper";
            var gameObject1 = __instance.gameObject;



            if (gameObject1 != null)
            {
               

                var model = Findreaper.Find_reaper(__instance);
                Console.WriteLine("[" + naam + "Camo] Initialized");

                var sandshark_skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();


                var texture = TextureUtils.LoadTexture(@"./QMods/ReaperCamo/ReaperCamoDiff.png");

                sandshark_skinnedRenderer.sharedMaterial.mainTexture = texture;


                Console.WriteLine("[" + naam + "Camo] Running as intended![this is a message to see if the "+naam+" creature gets called properly!]");
            }
            else
            {
                Console.WriteLine("[" + naam + "Camo] Error: SkinnedMeshRenderer not found on component");
            }

        }
    }
    



}
