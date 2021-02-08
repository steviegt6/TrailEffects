using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrailEffects.Items.Bags
{
    public class IchorBag : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Pouch");
            Tooltip.SetDefault("Creates a trail of ichor behind you");
        }

        public override void SetDefaults()
        {
            DefaultToBag(ItemRarityID.LightRed);
        }

        public override void UpdateMovement(Player player)
        {
            for (int d = 0; d < 2; d++)
            {
                Dust dust = Main.dust[Dust.NewDust(player.position, player.width, player.height - 4, 170, 0, 0, 128, Color.White, 0.75f)];
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                dust.velocity.Y -= 0.5f;
                dust.fadeIn = 1.2f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
            }
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = (Texture2D)ModContent.GetTexture("TrailEffects/Assets/IchorBag_Glow");
            Vector2 position = Item.position - Main.screenPosition + new Vector2(Item.width / 2, Item.height - texture.Height * 0.5f);

            spriteBatch.Draw(texture, position, null, Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient(ItemID.Cobweb, 20)
                .AddIngredient(ItemID.Ichor, 25)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}