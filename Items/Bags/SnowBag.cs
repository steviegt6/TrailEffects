using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using TrailEffects.Utilities;

namespace TrailEffects.Items.Bags
{
    public class SnowBag : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Pouch");
            Tooltip.SetDefault("Creates a storm of snow around you");
        }

        public override void SafeSetDefaults() => Item.DefaultToBag(ItemRarityID.Orange);

        public override void SafeUpdateVanity(Player player)
        {
            Dust dust = Dust.NewDustDirect(player.position - new Vector2(player.width / 2, 20), player.width * 2, player.height, 76, 0, 2.2f, 0, Color.White, 0.85f);
            dust.velocity.Y += 0.1f;
            dust.scale *= 0.985f;
            dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);

            Lighting.AddLight(dust.position, Color.SlateGray.ToVector3() * 0.7f * dust.scale);
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