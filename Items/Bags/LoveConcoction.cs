using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using TrailEffects.Utilities;

namespace TrailEffects.Items.Bags
{
    public class LoveConcoction : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Love Concoction");
            Tooltip.SetDefault("You are spreading love!");
        }

        public override void SafeSetDefaults() => Item.DefaultToBag(ItemRarityID.LightRed);

        public override void UpdateMovement(Player player)
        {
            if (Main.rand.NextBool(2))
            {
                Vector2 randPos = new Vector2(Main.rand.Next(0, player.width), Main.rand.Next(0, player.height));
                Gore.NewGoreDirect(player.position + randPos - new Vector2(0, 8), Vector2.Zero, 331, Main.rand.Next(10, 50) * 0.02f).sticky = false;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater, 5)
                .AddIngredient(ItemID.PrincessFish, 3)
                .AddIngredient(ItemID.Shiverthorn, 35)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}