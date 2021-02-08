using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using TrailEffects.Utilities;

namespace TrailEffects.Items.Bags
{
    public class MagmaBag : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Pouch");
            Tooltip.SetDefault("Magma and ash erupt from you when you move" +
                "\n'Classic Pursuit'");
        }

        public override void SafeSetDefaults() => Item.DefaultToBag(ItemRarityID.Orange);

        public override void UpdateMovement(Player player)
        {
            Dust dust = Dust.NewDustDirect(player.position, player.width, player.height - 4, 174 /* Inferno Dust */, 0, 0, 100, Color.White, 1f);
            dust.noGravity = true;
            dust.velocity *= 0.75f;
            dust.velocity.Y -= 0.5f;
            dust.fadeIn = 1.2f;
            dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);

            for (int i = 0; i < 3; i++)
            {
                dust = Dust.NewDustDirect(player.position, player.width, player.height - 4, 108 /* Ash Dust */, 0, -0.7f, 0, Color.White, 0.75f);
                dust.velocity *= 0.75f;
                dust.velocity.Y -= 0.5f;
                dust.fadeIn = 1.2f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.HellstoneBar, 2)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}