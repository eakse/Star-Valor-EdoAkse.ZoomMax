using BepInEx;
using HarmonyLib;


namespace EdoAkse.ZoomMax
{

    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "edoakse.starvalor.maxzoom";
        public const string pluginName = "EdoAkse Max Zoom";
        public const string pluginVersion = "1.0.0";


        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Main));
        }


        [HarmonyPatch(typeof(CameraControl))]
        [HarmonyPatch("SetupCamera")]
        [HarmonyPatch("Update")]
        [HarmonyPatch("AdjustCamera")]
        [HarmonyPatch("LateUpdate")]
        [HarmonyPrefix]
        private static void ZoomFix_Pre(ref int ___maxZoomLevel, ref float[] ___zoomScale)
        {
            // This number is the max zoomlevel. Basically the max index for the zoomScale array
            // maxZoomLevel used in two methods:
            // Update
            // AdjustCamera
            ___maxZoomLevel = 7;
            // ZoomScale is the list of floats actually containing the zooms
            // Needs to be one larger than the maxZoomLevel due to the Exploration skill Optics
            // it is used in the following methods:
            // SetupCamera
            // Update
            // LateUpdate
            // AdjustCamera
            ___zoomScale = new float[]
            {
                60f,
                120f,
                210f,
                360f,
                600f,
                850f,
                1000f,
                1250f,
                1600f,
                2000f
            };
        }
    }
}

