using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrailEffects.Items
{
    public class WanderingBonbori : DustItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wandering Bonbori");
            Tooltip.SetDefault("Attracts fireflies");
            ItemID.Sets.ItemNoGravity[Type] = true;
        }

        public override void SetDefaults()
        {
            DefaultToBag(ItemRarityID.Green);
        }

        public override void UpdateVanity(Player player)
        {
            DustMethod(player, 5, 3);
        }

        public override void PostUpdate() => Lighting.AddLight(Item.Center, Color.DarkOrange.ToVector3() * 0.6f);

        private void DustMethod(Player player, int frequency1, int frequency2, float xV = 0, float yV = 0)
        {
            if (player.miscCounter % (frequency1) == 0 && Main.rand.Next(frequency2) == 0)
            {
                Vector2 center = player.position;
                float rand = 1f + Main.rand.NextFloat() * 0.5f;
                if (Main.rand.Next(2) == 0)
                    rand *= -1f;

                center += new Vector2(rand * -25f, -8f);
                Dust dust = Main.dust[Dust.NewDust(center, player.width, player.height, DustID.Firefly, xV, yV, 100)];
                dust.rotation = Main.rand.NextFloat() * ((float)Math.PI * 2f);
                dust.velocity.X = rand * 0.2f;
                dust.noGravity = true;
                dust.customData = player;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
            }
            Lighting.AddLight(player.Center, Color.DarkOrange.ToVector3() * 0.4f);
        }

        public override void HoldStyle(Player player)
        {
            DustMethod(player, 15, 4);
        }

        #region drawing

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = (Texture2D)ModContent.GetTexture("TrailEffects/Assets/WanderingBonbori_Glow");
            Vector2 position = Item.position - Main.screenPosition + new Vector2(Item.width / 2, Item.height - texture.Height * 0.5f);

            spriteBatch.Draw(texture, position, null, Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = (Texture2D)ModContent.GetTexture("TrailEffects/Assets/WanderingBonbori_Glow");
            Vector2 position = Item.position - Main.screenPosition + new Vector2(Item.width / 2, Item.height - texture.Height * 0.5f);

            for (int i = 0; i < 4; i++)
            {
                float sine = (float)Math.Sin(Main.GlobalTimeWrappedHourly * 3f) + 1f;
                Vector2 offsetPositon = new Vector2(0, sine).RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(texture, position + offsetPositon, null, Color.White * 0.25882352941f, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = (Texture2D)ModContent.GetTexture("TrailEffects/Assets/WanderingBonbori_Glow");

            for (int i = 0; i < 4; i++)
            {
                float sine = (float)Math.Sin(Main.GlobalTimeWrappedHourly * 3f);
                Vector2 offsetPositon = new Vector2(0, (sine + 1f) / 1.5f).RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(texture, position + offsetPositon, null, Color.White * 0.25882352941f, 0, origin, scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        #endregion drawing

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Firefly, 3)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}