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
                "Максимальное количество дедлайнов (0 = бесконечно)",
                new AcceptableValueRange<int>(0, 100)));

        InfiniteMode = Config.Bind("General",
            "InfiniteMode",
            false,
            "Бесконечный режим игры");

        var harmony = new Harmony(PLUGIN_GUID);
        harmony.PatchAll();

        Logger.LogInfo($"Applied {harmony.GetPatchedMethods().Count()} harmony patches");
    }
}