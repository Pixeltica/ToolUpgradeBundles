using StardewModdingAPI;
using StardewValley;
using StardewValley.Triggers;
using StardewValley.Delegates;

public class ModEntry : Mod
{
    public override void Entry(IModHelper helper)
    {
        TriggerActionManager.RegisterAction("Pixeltica_UpgradeTrashCan", this.UpgradeTrashCan);
    }

    private bool UpgradeTrashCan(string[] args, TriggerActionContext context, out string error)
    {
        if (!ArgUtility.TryGet(args, 1, out string levelStr, out error, allowBlank: false))
        {
            return false;
        }

        if (int.TryParse(levelStr, out int targetLevel))
        {
            Game1.player.trashCanLevel = targetLevel;
            return true;
        }

        // In case I fob the wrong argument
        error = $"Wrong upgrade level '{levelStr}'. Expected an integer (1=Copper, 2=Steel, 3=Gold, 4=Iridium).";
        return false;
    }
}