using Netcode;
using StardewValley;
using StardewValley.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolUpgradeBundles
{
    internal class ToolUpgradeHandler
    {
        public static bool ApplyToolUpgrade(string[] args, TriggerActionContext context, out string? error)
        {
            // oldToolIdOrLevel would be a qualified Tool ID except for Trash Can, where it will be the target upgrade level
            if (!ArgUtility.TryGet(args, 1, out string oldToolIdOrLevel, out error) ||
                !ArgUtility.TryGet(args, 2, out string newToolId, out error))
            {
                return false;
            }

            // Because why can't we have consistent IDs for tools for the love of my sanity
            if (newToolId.Contains("Bamboo"))
            { 
                newToolId = newToolId.Replace("Rod", "Pole");
            }

            if (newToolId.Contains("TrashCan"))
            {
                return UpgradeTrashCan(oldToolIdOrLevel, newToolId, out error);
            }
            return UpgradeRegularTool(oldToolIdOrLevel, newToolId, out error);
        }

        private static bool UpgradeRegularTool(string oldToolId, string newToolId, out string? error)
        {
            error = null;
            Tool? oldTool = null;

            foreach (var item in Game1.player.Items)
            {
                if (item is Tool t && t.QualifiedItemId == oldToolId)
                {
                    oldTool = t;
                    break;
                }
            }

            if (oldTool == null)    
            {
                error = $"Player doesn't have the required tool '{oldToolId}' for this upgrade.";
                return false;
            }
            
            Tool newTool = ItemRegistry.Create<Tool>(newToolId);
            newTool.UpgradeFrom(oldTool);
            int index = Game1.player.Items.IndexOf(oldTool);
            Game1.player.Items[index] = newTool;

            string tempObjectId = $"(O)Pixeltica_UpgradeShopStock_{newToolId}";
            Game1.player.removeFirstOfThisItemFromInventory(tempObjectId); // Remove the temp 

            // Pretend the player just received the new tool like at Clint's
            Game1.exitActiveMenu();
            Game1.player.holdUpItemThenMessage(newTool);
            return true;
        }


        private static bool UpgradeTrashCan(string currentLevel, string newToolId, out string? error)
        {
            error = null;


            if (int.TryParse(currentLevel, out int currentLevelInt))
            {
                // Up by 1 from current Trash Can level passed to the action
                Game1.player.trashCanLevel = currentLevelInt + 1;

                string tempObjectId = $"(O)Pixeltica_UpgradeShopStock_{newToolId}";
                Game1.player.removeFirstOfThisItemFromInventory(tempObjectId); // Remove the temp

                // Pretend the player just received the new tool like at Clint's
                Game1.exitActiveMenu();
                Tool newTrashCan = ItemRegistry.Create<Tool>(newToolId);
                Game1.player.holdUpItemThenMessage(newTrashCan);

                return true;
            }
            else
            {
                // In case I fob the wrong argument
                error = $"Wrong value passed to action '{currentLevel}'. Expected an integer representing current Trash Can level (0=Basic, 1=Copper, 2=Steel, 3=Gold).";
                return false;
            }
        }
    }
}
