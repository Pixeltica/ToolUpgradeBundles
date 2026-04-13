using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ToolUpgradeBundles
{
    public class AnimationData
    {
        // The vanilla game asset to pull sprites from
        public string SourceAssetPath { get; set; }

        // The blank PNG template
        public string BlankTemplatePath { get; set; }

        // A list source and target rectangle pairs for each sprite/frame
        public List<FrameData> Frames { get; set; } = new List<FrameData>();

        public class FrameData
        {
            public Rectangle SourceArea { get; set; }
            public Rectangle TargetArea { get; set; }
        }
    }
}
