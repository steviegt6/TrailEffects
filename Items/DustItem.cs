using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TrailEffects.Items
{
    public abstract class DustItem : ModItem
    {
        public void DefaultToBag(int Rarity, int JourneySacrifices = 1)
        {
            Item.accessory = true;
            Item.vanity = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
            Item.rare = Rarity;
            Item.SetShopValues((Terraria.Enums.ItemRarityColor)Rarity, Item.buyPrice(0, 0, 75));
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = JourneySacrifices;
        }

        public override void SetDefaults()
        {
            Autosize();
        }

        private void Autosize()
        {
            try
            {
                Item.Size = TextureAssets.Item[Type].Size();
            }
            catch (System.NullReferenceException)
            {
                Item.Size = Vector2.Zero;
            }
        }

        public virtual void UpdateMovement(Player player)
        {
        }

        public override void UpdateVanity(Player player)
        {
            if (player.velocity != Vector2.Zero)
                UpdateMovement(player);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.velocity != Vector2.Zero)
                UpdateMovement(player);
        }
    }
}