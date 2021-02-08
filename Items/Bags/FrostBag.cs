using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace TrailEffects.Items.Bags
{
    public class FrostBag : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Pouch");
            Tooltip.SetDefault("Creates a trail of frostfire behind you");
        }

        public override void SetDefaults()
        {
            DefaultToBag(ItemRarityID.Green);
        }

        public override void UpdateMovement(Player player)
        {
            for (int d = 0; d < 4; d++)
            {
                Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height - 4, 187, 0, 0, 128, Color.White, 1.25f)];
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                dust.velocity.Y -= 0.5f;
                dust.fadeIn = 1.2f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient(ItemID.Cobweb, 20)
                .AddIngredient(ItemID.IceBlock, 20)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}