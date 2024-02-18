using HarmonyLib;
using System;
using Verse;

namespace VNPE_Compat
{
    [StaticConstructorOnStartup]
    public class Init
    {
        static Init()
        {
            Harmony harmony = new Harmony("VNPE-Compat");
            
            Type bioreactor = AccessTools.TypeByName("BioReactor.Building_BioReactor");
            if (bioreactor != null)
            {
                var bioreactorTick = bioreactor.GetMethod("Tick");
                var postfix = typeof(Building_BioReactor_Tick).GetMethod("Postfix");
                harmony.Patch(bioreactorTick, postfix: new HarmonyMethod(postfix));
            }

            Type hemogenExtractor = AccessTools.TypeByName("HemogenExtractor.Building_HemogenExtractor");
            if (hemogenExtractor != null)
            {
                var hemogenExtractorTick = hemogenExtractor.GetMethod("Tick");
                var postfix = typeof(Building_HemogenExtractor_Tick).GetMethod("Postfix");
                harmony.Patch(hemogenExtractorTick, postfix: new HarmonyMethod(postfix));
            }
        }
    }
}