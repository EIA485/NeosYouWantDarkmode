using HarmonyLib;
using NeosModLoader;
using BaseX;

namespace YouWantDarkmode
{
	public class YouWantDarkmode : NeosMod
	{
		public override string Name => "YouWantDarkmode?";
		public override string Author => "eia485";
		public override string Version => "1.0.0";
		public override string Link => "https://github.com/EIA485/NeosYouWantDarkmode/";
		public override void OnEngineInit()
		{
			Harmony harmony = new Harmony("net.eia485.YouWantDarkmode?");
			harmony.PatchAll();
		}

		[HarmonyPatch(typeof(color), MethodType.Getter)]
		class MoreReferenceProxiesPatch
		{
			[HarmonyPrefix]
			[HarmonyPatch("Black")]
			static bool BlackPreFix(ref color __result)
			{
				__result = new color(1);
				return false;
			}

			[HarmonyPrefix]
			[HarmonyPatch("White")]
			static bool whitePreFix(ref color __result)
			{
				__result = new color(0);
				return false;
			}
		}
	}
}