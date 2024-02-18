using PipeSystem;
using RimWorld;
using Verse;

namespace VNPE_Compat
{
    public static class Building_HemogenExtractor_Tick
    {
        public static void Postfix(Building __instance)
        {
            if (__instance.IsHashIntervalTick(250))
            {
                var compResource = __instance.GetComp<CompResource>();
                var compRefuelable = __instance.GetComp<CompRefuelable>();

                if (compRefuelable != null && compResource != null && compResource.PipeNet is PipeNet net)
                {
                    var stored = net.Stored;
                    while (compRefuelable.GetFuelCountToFullyRefuel() > 6 && stored > 0)
                    {
                        net.DrawAmongStorage(1, net.storages);

                        stored--;
                        compRefuelable.Refuel(6);
                    }
                }
            }
        }
    }
}
