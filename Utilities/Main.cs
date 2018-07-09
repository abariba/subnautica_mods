// This is your shared project

// Shared project can be used as references by adding them in References > Add Reference 
// and clicking "Shared Projects" in the left-hand-side panel

// Unlike normal projects, shared projects can't be built (turned into a DLL) manually
// Shared projects are built automatically when building other projects that require it,
// and the two DLLs are merged

using System;
using System.IO;
using UnityEngine;
using Harmony;
//using UnityEngine;
using Utilities;


namespace Utilities
{
    public class TextureUtils
    {
        // Ripped from: https://github.com/RandyKnapp/SubnauticaModSystem/blob/master/SubnauticaModSystem/Common/Utility/ImageUtils.cs
        public static Texture2D LoadTexture(string path, string callingmod = "sandsharkCamo", TextureFormat format = TextureFormat.BC7, int width = 2, int height = 2)
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
                Console.WriteLine("["+callingmod+"] ERROR: File not found " + path);
            }
            return null;
        }
    }

    [HarmonyPatch(typeof(Boomerang), "InitializeOnce")]
    public class Findboomerang
    {

        public static GameObject Find_boomerang(Boomerang __instance)
        {
            var gameObject = __instance.gameObject;
            try
            {
                Console.WriteLine("utils succes");
                return gameObject.FindChild("model").FindChild("Small_Fish_01");//.FindChild("Stalker_02").FindChild("snout_shark_geo"); ;
            }
            catch
            {
                Console.WriteLine("utils fail");
                return gameObject;
            }
        }
    }

    [HarmonyPatch(typeof(Stalker), "InitializeOnce")]
    public class Findstalker
    {

        public static GameObject Find_stalker(Stalker __instance)
        {
            var gameObject = __instance.gameObject;
            try
            {
                Console.WriteLine("utils succes");
                return gameObject.FindChild("Stalker_02").FindChild("snout_shark_geo");//.FindChild("Stalker_02").FindChild("snout_shark_geo"); ;
            }
            catch
            {
                Console.WriteLine("utils fail");
                return gameObject;
            }
        }
    }

    [HarmonyPatch(typeof(Peeper), "InitializeOnce")]
    public class Findpeeper
    {

        public static GameObject Find_peeper(Peeper __instance)
        {
            var gameObject = __instance.gameObject;
            try
            {
                Console.WriteLine("utils succes");
                return gameObject.FindChild("model").FindChild("peeper").FindChild("aqua_bird").FindChild("peeper");//.FindChild("Stalker_02").FindChild("snout_shark_geo"); ;
            }
            catch
            {
                Console.WriteLine("utils fail");
                return gameObject;
            }
        }
    }
    [HarmonyPatch(typeof(SandShark), "InitializeOnce")]
    public class Findsandshark { 
        public static GameObject Find_sandshark(SandShark __instance)
        {
            var gameObject = __instance.gameObject;
            try
            {
                Console.WriteLine("utils succes");
                return gameObject.FindChild("models").FindChild("sand_shark_01").FindChild("sand_shark_rig_SandSharkGEO");//.FindChild("Stalker_02").FindChild("snout_shark_geo"); ;
            }
            catch
            {
                Console.WriteLine("utils fail");
                return gameObject;
            }
        }
    }

    [HarmonyPatch(typeof(ReaperLeviathan), "InitializeOnce")]
    public class Findreaper
    {

        public static GameObject Find_reaper(ReaperLeviathan __instance)
        {
            var gameObject = __instance.gameObject;
            try
            {
                Console.WriteLine("utils succes");
                return gameObject.FindChild("reaper_leviathan").FindChild("reaper_leviathan_geo");//.FindChild("Stalker_02").FindChild("snout_shark_geo"); ;
            }
            catch
            {
                Console.WriteLine("utils fail");
                return gameObject;
            }
        }
    }
}
