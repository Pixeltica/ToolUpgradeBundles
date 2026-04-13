using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace ToolUpgradeBundles
{
    public static class AnimationHandler
    {
        private static Dictionary<string, AnimationData> customAnimations = new();
        private static IModHelper Helper;

        // Animation Data Entries
        public static void LoadAnimationData(IModHelper helper)
        {
            Helper = helper;

            

            //  Special Seasonal Vegetables
            customAnimations["Pixeltica/SpecialSeasonalVegetableBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Tilesheets/objects_2",
                BlankTemplatePath = "assets/animation_64x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(0, 160, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },     // Carrot (Spring)
		            new() { SourceArea = new Rectangle(16, 160, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },   // Summer Squash (Summer)
		            new() { SourceArea = new Rectangle(32, 160, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },   // Broccoli (Fall)
		            new() { SourceArea = new Rectangle(48, 160, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }    // Powdermelon (Winter)
	            }
            };

            // Any Tree Fruit Bundle Sprites
            customAnimations["Pixeltica/AnyTreeFruitBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_96x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(208, 400, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },  // Apple (Fall)
		            new() { SourceArea = new Rectangle(160, 416, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) }, // Apricot (Spring)
		            new() { SourceArea = new Rectangle(224, 416, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) }, // Cherry (Spring)
		            new() { SourceArea = new Rectangle(176, 416, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }, // Orange (Summer)
		            new() { SourceArea = new Rectangle(192, 416, 16, 16), TargetArea = new Rectangle(64, 0, 16, 16) }, // Peach (Summer)
		            new() { SourceArea = new Rectangle(208, 416, 16, 16), TargetArea = new Rectangle(80, 0, 16, 16) }  // Pomegranate (Fall)
	            }
            };

            //  Simple Seasonal Forage
            customAnimations["Pixeltica/SimpleSeasonalForageBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_64x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(352, 0, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },    // Dandelion (Spring)
		            new() { SourceArea = new Rectangle(288, 256, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) }, // Sweet Pea (Summer)
		            new() { SourceArea = new Rectangle(0, 272, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },   // Hazelnut (Fall)
		            new() { SourceArea = new Rectangle(304, 176, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }  // Holly (Winter)
	            }
            };

            // Seasonal Forage Fruit Bundle Sprites
            customAnimations["Pixeltica/SeasonalFruitForageBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_64x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(128, 192, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },   // Salmonberry (Spring)
                    new() { SourceArea = new Rectangle(224, 256, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },  // Grape (Summer)
                    new() { SourceArea = new Rectangle(32, 272, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },   // Blackberry (Fall)
                    new() { SourceArea = new Rectangle(96, 272, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }    // Crystal Fruit (Winter)
                }
            };

            // Seasonal Flower Bundle Sprites
            customAnimations["Pixeltica/SeasonalFlowerBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_64x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(240, 384, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },   // Tulip (Spring)
                    new() { SourceArea = new Rectangle(256, 240, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },  // Poppy (Summer)
                    new() { SourceArea = new Rectangle(208, 272, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },  // Sunflower (Fall)
                    new() { SourceArea = new Rectangle(160, 272, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }   // Crocus (Winter)
                }
            };

            // Precious Gems Bundle Sprites
            customAnimations["Pixeltica/PreciousGemsBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_80x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(0, 48, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },      // Diamond
                    new() { SourceArea = new Rectangle(256, 32, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },   // Ruby
                    new() { SourceArea = new Rectangle(192, 32, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },   // Emerald
                    new() { SourceArea = new Rectangle(352, 32, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) },   // Jade
                    new() { SourceArea = new Rectangle(224, 32, 16, 16), TargetArea = new Rectangle(64, 0, 16, 16) }    // Aquamarine
                }
            };

            // Early Tapper Bundle Sprites
            customAnimations["Pixeltica/EarlyTapperBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_32x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(80, 480, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },    // Oak Resin
                    new() { SourceArea = new Rectangle(96, 480, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) }    // Pine Tar
                }
            };

            // Warm Beverage Bundle Sprites
            customAnimations["Pixeltica/WarmBeverageBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_32x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(224, 400, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },    // Green Tea
                    new() { SourceArea = new Rectangle(176, 256, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) }    // Coffee
                }
            };

            // Basic Beach Forage Bundle Sprites
            customAnimations["Pixeltica/BeachForageBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_64x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(192, 240, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },   // Clam
                    new() { SourceArea = new Rectangle(352, 464, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },  // Mussel
                    new() { SourceArea = new Rectangle(368, 464, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },  // Cockle
                    new() { SourceArea = new Rectangle(48, 480, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }    // Oyster
                }
            };

            // Any Season Fish Bundle Sprites
            customAnimations["Pixeltica/AnySeasonFishBundleSlot"] = new AnimationData
			{
				SourceAssetPath = "Maps/springobjects",
				BlankTemplatePath = "assets/animation_48x16.png",
				Frames = new List<AnimationData.FrameData>
	            {
		            new() { SourceArea = new Rectangle(96, 464, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },   // Chub
		            new() { SourceArea = new Rectangle(192, 80, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },  // Bream
		            new() { SourceArea = new Rectangle(256, 80, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) }   // Largemouth Bass
	            }
			};

            // Beginner Fish Bundle Sprites
            customAnimations["Pixeltica/BeginnerFishBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_48x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(48, 96, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },     // Herring
		            new() { SourceArea = new Rectangle(272, 80, 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },   // Smallmouth Bass
		            new() { SourceArea = new Rectangle(352, 80, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) }    // Carp
	            }
            };

            // Rainy Day Fish Bundle Sprites
            customAnimations["Pixeltica/RainyDayFishBundleSlot"] = new AnimationData
            {
                SourceAssetPath = "Maps/springobjects",
                BlankTemplatePath = "assets/animation_80x16.png",
                Frames = new List<AnimationData.FrameData>
                {
                    new() { SourceArea = new Rectangle(64, 96, 16, 16), TargetArea = new Rectangle(0, 0, 16, 16) },     // Eel
                    new() { SourceArea = new Rectangle(320, 80 , 16, 16), TargetArea = new Rectangle(16, 0, 16, 16) },  // Walleye
                    new() { SourceArea = new Rectangle(160, 464, 16, 16), TargetArea = new Rectangle(32, 0, 16, 16) },  // Shad
                    new() { SourceArea = new Rectangle(96, 96, 16, 16), TargetArea = new Rectangle(64, 0, 16, 16) },    // Red Snapper
                    new() { SourceArea = new Rectangle(368, 80, 16, 16), TargetArea = new Rectangle(48, 0, 16, 16) }    // Catfish
                }
            };

            

            // Subscribe to the asset requested event
            Helper.Events.Content.AssetRequested += OnAssetRequested;
		}

        private static void OnAssetRequested(object? sender, AssetRequestedEventArgs e)
        {
            foreach (var animation in customAnimations)
            {
                string targetAssetName = animation.Key;
                AnimationData animationData = animation.Value;

                if (e.NameWithoutLocale.IsEquivalentTo(targetAssetName))
                {
                    // Blank template load
                    e.LoadFromModFile<Texture2D>(animationData.BlankTemplatePath, AssetLoadPriority.Medium);


                    e.Edit(asset =>
                    {
                        var editor = asset.AsImage();
                        Texture2D sourceAsset = Helper.GameContent.Load<Texture2D>(animationData.SourceAssetPath);

                        foreach (var frame in animationData.Frames)
                        {
                            editor.PatchImage(
                                source: sourceAsset,
                                sourceArea: frame.SourceArea,
                                targetArea: frame.TargetArea,
                                patchMode: PatchMode.Replace
                            );
                        }
                    });

                    return;
                }
            }
        }
    }
}
