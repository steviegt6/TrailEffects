using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace TrailEffects.Items.Bags
{
    public class LightningBag : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Pouch");
            Tooltip.SetDefault("Creates a trail of lightning behind you");
        }

        public override void SetDefaults()
        {
            DefaultToBag(ItemRarityID.Green);
        }

        public override void UpdateMovement(Player player)
        {
            for (int d = 0; d < 2; d++)
            {
                Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height - 4, 264, 0, 0, 100, new Color(0, 167, 255), 1.25f)];
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
                .AddTile(TileID.Loom);
            //.Register();
        }
    }
}