using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using TrailEffects.Utilities;

namespace TrailEffects.Items.Bags
{
    public class WanderingBonbori : DustItem
    {
        public override string Glowmask => "TrailEffects/Assets/WanderingBonbori_Glow";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wandering Bonbori");
            Tooltip.SetDefault("Attracts fireflies");

            ItemID.Sets.ItemNoGravity[Type] = true;
        }

        public override void SafeSetDefaults() => Item.DefaultToBag(ItemRarityID.Green);

        public override void SafeUpdateVanity(Player player) => DustMethod(player, 5, 3);

        public override void HoldStyle(Player player) => DustMethod(player, 15, 4);

        public override void PostUpdate() => Lighting.AddLight(Item.Center, Color.DarkOrange.ToVector3() * 0.6f);

        private void DustMethod(Player player, int frequency1, int frequency2, float xV = 0, float yV = 0)
        {
            if (player.miscCounter % frequency1 == 0 && Main.rand.NextBool(frequency2))
            {
                Vector2 center = player.position;
                float rand = 1f + Main.rand.NextFloat() * 0.5f;

                if (Main.rand.NextBool(2))
                    rand *= -1f;

                center += new Vector2(rand * -25f, -8f);

                Dust dust = Dust.NewDustDirect(center, player.width, player.height, DustID.Firefly, xV, yV, 100);
                dust.rotation = Main.rand.NextFloat() * ((float)Math.PI * 2f);
                dust.velocity.X = rand * 0.2f;
                dust.noGravity = true;
                dust.customData = player;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMinion, player);
            }

            Lighting.AddLight(player.Center, Color.DarkOrange.ToVector3() * 0.4f);
        }

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