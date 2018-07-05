using System;
using System.IO;
using System.Reflection;
using Harmony;
using UnityEngine;


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

        // Ripped from: https://github.com/RandyKnapp/SubnauticaModSystem/blob/master/SubnauticaModSystem/Common/Utility/ImageUtils.cs
        public static Texture2D LoadTexture(string path, TextureFormat format = TextureFormat.BC7, int width = 2, int height = 2)
        {
            if (File.Exists(path))
            {
                byte[] data = File.ReadAllBytes(path);
                Texture2D texture2D = new Texture2D(width, height, format, false);
                if (texture2D.LoadImage(data))
                {
                    return texture2D;
                }
            }
            else
            {
                Console.WriteLine("[stalkerCamo] ERROR: File not found " + path);
            }
            return null;
        }
    }

    [HarmonyPatch(typeof(Stalker))]
    [HarmonyPatch("Start")]
    internal class stalkerCamo_Start_Patch
    {
        static void Postfix(Stalker __instance)
        {
            
            var rnd = new System.Random().Next(0, 2);
            var gameObject = __instance.gameObject;
            var model = gameObject.FindChild("Stalker_02").FindChild("snout_shark_geo");
            var skinnedRenderer = model.GetComponent<SkinnedMeshRenderer>();
            if (rnd == 0)
            {
                var texture = Main.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff.png");
                skinnedRenderer.sharedMaterial.mainTexture = texture;
            }
            else if(rnd == 1)
            {
                var texture = Main.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff_0.png");
                skinnedRenderer.sharedMaterial.mainTexture = texture;
            }
            else if(rnd == 2)
            {
                var texture = Main.LoadTexture(@"./QMods/stalkerCamo/stalkerCamoDiff_1.png");
                skinnedRenderer.sharedMaterial.mainTexture = texture;
            }
            

        }
        
    }
}
