using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TrailEffects.Items
{
    /// <summary>
    /// Base <see cref="ModItem"/> used for <c>Bags</c>, extends <see cref="TEItem"/>.
    /// </summary>
    public abstract class DustItem : TEItem
    {
        public sealed override void UpdateVanity(Player player)
        {
            if (player.velocity != Vector2.Zero)
                UpdateMovement(player);

            SafeUpdateVanity(player);
        }

        public sealed override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.velocity != Vector2.Zero)
                UpdateMovement(player);

            SafeUpdateAccessory(player, hideVisual);
        }

        /// <summary>
        /// Method automatically called in <see cref="UpdateVanity(Player)"/> and <see cref="UpdateAccessory(Player, bool)"/>.
        /// </summary>
        public virtual void UpdateMovement(Player player)
        {
        }

        /// <summary>
        /// Called at the end of <see cref="UpdateVanity(Player)"/>.
        /// </summary>
        public virtual void SafeUpdateVanity(Player player)
        {
        }

        /// <summary>
        /// Called at the end of <see cref="UpdateAccessory(Player, bool)"/>
        /// </summary>
        public virtual void SafeUpdateAccessory(Player player, bool hidVisual)
        {
        }
    }
}