using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;

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

        public override void SetDefaults()
        {
            DefaultToBag(ItemRarityID.Orange);
        }

        public override void UpdateMovement(Player player)
        {
            //inferno
            Dust dust1 = Main.dust[Dust.NewDust(player.position, player.width, player.height - 4, 174, 0, 0, 100, Color.White, 1f)];
            dust1.noGravity = true;
            dust1.velocity *= 0.75f;
            dust1.velocity.Y -= 0.5f;
            dust1.fadeIn = 1.2f;
            dust1.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);

            for (int d = 0; d < 3; d++)
            {
                //ash
                Dust dust2 = Main.dust[Dust.NewDust(player.position, player.width, player.height - 4, 109, 0, 0, 0, Color.White, 1.25f)];
                dust2.noGravity = true;
                dust2.velocity *= 0.75f;
                dust2.velocity.Y -= 0.5f;
                dust2.fadeIn = 1.2f;
                dust2.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
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