using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Linq;

[BepInPlugin(Plugin.PLUGIN_GUID, Plugin.PLUGIN_NAME, Plugin.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public const string PLUGIN_GUID = "com.mikhaelo.cloverpitneverendinggame";
    public const string PLUGIN_NAME = "CloverPit Never Ending Game";
    public const string PLUGIN_VERSION = "1.0.0";

    internal static ManualLogSource Log;

    public static ConfigEntry<int> MaxDeadlines;
    public static ConfigEntry<int> KeyCost;
    public static ConfigEntry<bool> InfiniteMode;
    public static ConfigEntry<float> DebtMultiplier;

    private void Awake()
    {
        Log = Logger;
        Logger.LogInfo($"Plugin {PLUGIN_GUID} v{PLUGIN_VERSION} loaded!");

        MaxDeadlines = Config.Bind("General",
            "MaxDeadlines",
            5,
            new ConfigDescription(
                "Maximum number of deadlines",
                new AcceptableValueRange<int>(0, 9999999999)));

        InfiniteMode = Config.Bind("General",
            "InfiniteMode",
            false,
            "Endless game mode");

        var harmony = new Harmony(PLUGIN_GUID);
        harmony.PatchAll();

        Logger.LogInfo($"Applied {harmony.GetPatchedMethods().Count()} harmony patches");
    }
}