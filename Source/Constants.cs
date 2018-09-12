using RimWorld;
using Verse;

namespace Gastroliths
{
    class Constants
    {

        public static bool is_animal(Pawn pawn)
        {
            return pawn.RaceProps.Animal;
        }

        public static Thing makeGastrolith()
        {
            ThingDef what = Constants.whatGastrolith();
            if (what != null)
            {
                Log.Message("Generating Gastrolith", false);
                Thing t = ThingMaker.MakeThing(what, null);
                t.stackCount = Rand.RangeInclusive(0, 6) + 1;
                return t;
            }
            else
            {
                Log.Message("Gastrlith declined", false);
            }

            return null;
        }

        public static ThingDef whatGastrolith()
        {
            float roll = Rand.Value;
            roll %= 1.0f;

            //	Roll 1d20: 1-10 Nothing, 10-15 Chunks, 16 - Component, 17- Plastisteel, 18- Silver, 19-Gold, 20-Steel
            if (roll < .95f)
            {
                return ThingDefOf.Steel;
            }else if (roll < .90f)
            {
                return ThingDefOf.Gold;
            }else if (roll < .85f)
            {
                return ThingDefOf.Silver;
            }
            else if (roll < .80f)
            {
                return ThingDefOf.Plasteel;
            }
            else if (roll < .75f)
            {
                return ThingDefOf.ComponentIndustrial;
            }
            else if (roll < .50f)
            {
                return ThingDefOf.Granite;
            }
            else
            {
                return ThingDefOf.Hay;
            }
        }
    }
}
