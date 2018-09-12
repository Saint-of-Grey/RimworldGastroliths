using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Gastroliths
{
    class Harmony
    {
        [HarmonyPatch(typeof(GenRecipe), "MakeRecipeProducts", null)]
        public static class MakeRecipeProductsnPatch
        {
            [HarmonyPostfix]
            public static void Postfix(ref IEnumerable<Thing> __result, RecipeDef recipeDef, Pawn worker, List<Thing> ingredients)
            {

                Log.Message("0HarmonyHook, butcher", false);
                List<Thing> list = (__result as List<Thing>) ?? __result.ToList<Thing>();
                
                foreach (Corpse corpse in ingredients.OfType<Corpse>())
                {
                    Log.Message("0HarmonyHook, butchering corpse; adding gastrolith", false);
                    Thing var = Constants.makeGastrolith();

                    if (var != null)
                    {
                        list.Add(var);
                    }
                }

                __result = list;
                return;
            }


        }
    }
}

