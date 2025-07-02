using HarmonyLib;
using System.Numerics;

namespace CloverPitNeverEndingGame
{
    [HarmonyPatch]
    public static class Patchers
    {
        [HarmonyPatch(typeof(GameplayData), "GetRewardBoxDebtIndex")]
        [HarmonyPrefix]
        static bool GetRewardBoxDebtIndex_Prefix(ref BigInteger __result)
        {
            if (Plugin.InfiniteMode.Value)
            {
                __result = 999999;
            }
            else
            {
                __result = Plugin.MaxDeadlines.Value - 1;
            }
            return false;
        }
    }
}