using BepInEx;
using System.Reflection;
using UnityEngine;
using HarmonyLib;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace TransAllTheThings
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony Harmony;

        void Start()
        {
            Harmony = new Harmony(PluginInfo.GUID);
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(VRRig), "Start", MethodType.Normal)]
        public class Init
        {
            public static async void Postfix(VRRig __instance)
            {
                await Task.Delay(500);
                GameObject[] cosmeticArray = __instance.cosmetics;

                foreach (TransferrableObject transferrable in __instance.GetComponent<BodyDockPositions>().allObjects)
                {
                    if (transferrable != null && transferrable.GetComponent<Renderer>() != null)
                    {
                        // completely override the texture with a blank white one to fully bring out the transness
                        transferrable.GetComponent<Renderer>().sharedMaterial.mainTexture = Texture2D.whiteTexture;
                        transferrable.gameObject.AddComponent<ColorLerp>();
                    }
                }
                foreach (GameObject cosmeticObject in cosmeticArray)
                {
                    if (cosmeticObject != null && cosmeticObject.GetComponent<Renderer>() != null) 
                    {
                        // completely override the texture with a blank white one to fully bring out the transness
                        cosmeticObject.GetComponent<Renderer>().sharedMaterial.mainTexture = Texture2D.whiteTexture;
                        cosmeticObject.gameObject.AddComponent<ColorLerp>();
                    }
                }
            }
        }
    }
}