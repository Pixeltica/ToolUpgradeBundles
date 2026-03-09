using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Tools;
using StardewValley.Menus;

namespace ToolUpgradeBundles
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Player.InventoryChanged += OnInventoryChanged;
            helper.Events.Display.MenuChanged += this.OnMenuChanged;
        }
        // Reduce the 2 day upgrade time to 0 to give the player the tool immediately,
        // play the "hold item over head" animation (condition to account for the trash can throwing a wobbly)
        private void OnInventoryChanged(object sender, InventoryChangedEventArgs e)
        {
            if (Game1.player.daysLeftForToolUpgrade.Value > 0 && Game1.player.toolBeingUpgraded.Value != null)
            {
                Tool tool = Game1.player.toolBeingUpgraded.Value;

                if (tool is GenericTool)
                {
                    tool.actionWhenClaimed();
                }
                else
                {
                    Game1.player.addItemToInventory(tool);
                }
                Game1.player.toolBeingUpgraded.Value = null;
                Game1.player.daysLeftForToolUpgrade.Value = 0;
                Game1.player.holdUpItemThenMessage(tool);
                
            }
        }
        // Close Clint's dialogue before it can open because I cannot figure out how to prevent the 
        // "hold item over head" animation from interrupting the dialogue box T_T
        private void OnMenuChanged(object sender, MenuChangedEventArgs e)
        {
            
            if (e.NewMenu is StardewValley.Menus.DialogueBox dialogueBox)
            {
                string clintUpgradeText = Game1.content.LoadString("Strings\\StringsFromCSFiles:Tool.cs.14317");
                if (dialogueBox.getCurrentString() == clintUpgradeText)
                {
                    Game1.activeClickableMenu = null;
                }
            }
        }
    }
}