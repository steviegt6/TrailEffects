using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace TrailEffects.Items.Bags
{
    public class SnowBag : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Pouch");
            Tooltip.SetDefault("Creates a storm of snow behind you");
        }

        public override void SetDefaults()
        {
            DefaultToBag(ItemRarityID.Orange);
        }

        public override void UpdateMovement(Player player)
        {
            for (int d = 0; d < 1; d++)
            {
                Dust dust = Main.dust[Dust.NewDust(player.position - (Vector2.UnitY * 11), player.width, player.height, 76, 0, 0, 0, Color.White, 1.05f)];
                dust.fadeIn = 0.5f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
                Lighting.AddLight(dust.position, Color.SlateGray.ToVector3() * 0.7f * dust.scale);
            }
        }

        public override void UpdateVanity(Player player)
        {
            if (Main.rand.Next(3) == 0)
            {
                Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height, 76, -player.velocity.X, 2, 0, Color.White, 1.05f)];
                dust.velocity.Y -= 0.05f;
                dust.fadeIn = 0.5f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
                Lighting.AddLight(dust.position, Color.SlateGray.ToVector3() * 0.7f * dust.scale);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.FlinxFur, 3)
                .AddIngredient(ItemID.GoldBar, 2)
                .AddIngredient(ItemID.SnowBlock, 20)
                .AddTile(TileID.Loom)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.FlinxFur, 3)
                .AddIngredient(ItemID.PlatinumBar, 2)
                .AddIngredient(ItemID.SnowBlock, 20)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}