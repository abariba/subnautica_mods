// This is your shared project

// Shared project can be used as references by adding them in References > Add Reference 
// and clicking "Shared Projects" in the left-hand-side panel

// Unlike normal projects, shared projects can't be built (turned into a DLL) manually
// Shared projects are built automatically when building other projects that require it,
// and the two DLLs are merged

using System;
using System.IO;
using UnityEngine;

namespace Utilities
{
    public class TextureUtils
    {
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
}
