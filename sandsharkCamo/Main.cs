using System;
using System.IO;
using System.Reflection;
using Harmony;
using UnityEngine;


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
                Console.WriteLine("[sandsharkCamo] ERROR: File not found " + path);
            }
            return null;
        }
    }

    [HarmonyPatch(typeof(SandShark))]
    [HarmonyPatch("Start")]
    internal class sandsharkCamo_Start_Patch
    {
        static void Postfix(SandShark __instance)
        {
    
            var gameObject = __instance.gameObject;
            if(gameObject != null){
                var model = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SSGlobalTSR");
                var model1 = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO");
                var model2 = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO_LOD1");
                var model3 = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO_LOD2");
                var model4 = gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO_LOD3");
                var model5 = gameObject.FindChild("models").FindChild("sand_shark_01");

                var skinnedRenderer = model.GetComponent<MeshRenderer>();
                var skinnedRenderer1 = model1.GetComponent<MeshRenderer>();
                var skinnedRenderer2 = model2.GetComponent<MeshRenderer>();
                var skinnedRenderer3 = model3.GetComponent<MeshRenderer>();
                var skinnedRenderer4 = model4.GetComponent<MeshRenderer>();
                var skinnedRenderer5 = model5.GetComponent<MeshRenderer>();

                var texture = Main.LoadTexture(@"./QMods/sandsharkCamo/sandsharkCamoDiff.png");

                skinnedRenderer.sharedMaterial.mainTexture = texture;
                skinnedRenderer1.sharedMaterial.mainTexture = texture;
                skinnedRenderer2.sharedMaterial.mainTexture = texture;
                skinnedRenderer3.sharedMaterial.mainTexture = texture;
                skinnedRenderer4.sharedMaterial.mainTexture = texture;
                skinnedRenderer5.sharedMaterial.mainTexture = texture;
            }
            else{
                Console.WriteLine("[sandsharkCamo] Error: SkinnedMeshRenderer not found on component");
            }
        

        }
        
    }
}
