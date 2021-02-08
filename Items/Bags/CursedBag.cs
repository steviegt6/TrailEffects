using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using TrailEffects.Utilities;

namespace TrailEffects.Items.Bags
{
    public class CursedBag : DustItem
    {
        public override string GlowmaskTexture => "TrailEffects/Assets/CursedBag_Glow";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Flame Pouch");
            Tooltip.SetDefault("Creates a trail of cursed flames behind you");
        }

        public override void SafeSetDefaults() => Item.DefaultToBag(ItemRarityID.LightRed);

        public override void UpdateMovement(Player player)
        {
            for (int i = 0; i < 2; i++)
            {
                Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height - 4, DustID.CursedTorch, 0, 0, 128, Color.White, 1f)];
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
                .AddIngredient(ItemID.CursedFlame, 25)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}