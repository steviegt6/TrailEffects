using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ModLoader;
using TrailEffects.Utilities;

namespace TrailEffects.Items
{
    /// <summary>
    /// Base <see cref="ModItem"/> class using by <see cref="TrailEffects"/>.
    /// </summary>
    public abstract class TEItem : ModItem
    {
        /// <summary>
        /// Whether this item's size should be set automatically or not.
        /// </summary>
        public virtual bool Autosize => true;

        public sealed override void SetDefaults()
        {
            if (Autosize)
                Item.Autosize();

            SafeSetDefaults();
        }

        /// <summary>
        /// Called at the end of <see cref="SetDefaults"/>.
        /// </summary>
        public virtual void SafeSetDefaults()
        {
        }
    }
}