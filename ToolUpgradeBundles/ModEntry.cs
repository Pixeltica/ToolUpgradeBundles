using StardewModdingAPI;
using StardewValley;
using StardewValley.Triggers;
using StardewValley.Delegates;
using ToolUpgradeBundles;


public class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        TriggerActionManager.RegisterAction("Pixeltica_ApplyToolUpgrade", ToolUpgradeHandler.ApplyToolUpgrade);
        AnimationHandler.LoadAnimationData(helper);
    }
}