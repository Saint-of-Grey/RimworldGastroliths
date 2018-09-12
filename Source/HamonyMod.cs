using System.Reflection;
using Harmony;
using Verse;

namespace Gastroliths
{
    public class HamonyMod : Mod
    {
        public HamonyMod(ModContentPack content) : base(content)
        {
            HarmonyInstance.DEBUG = true;
            var harmony = HarmonyInstance.Create("acecil.rimworld.gastroliths");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}