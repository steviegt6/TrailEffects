using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace TrailEffects.Utilities
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Automatically sets the item to the defaults of a bag.
        /// </summary>
        public static void DefaultToBag(this Item item, int itemRarity, int sacrificesRequired = 1) => item.DefaultToBag((ItemRarityColor)itemRarity, sacrificesRequired);

        /// <summary>
        /// Automatically sets the item to the defaults of a bag.
        /// </summary>
        public static void DefaultToBag(this Item item, ItemRarityColor itemRarity, int sacrificesRequired = 1)
        {
            if ((int)itemRarity >= ItemRarityID.Count)
                itemRarity = ItemRarityColor.Purple11;

            item.accessory = true;
            item.vanity = true;
            item.canBePlacedInVanityRegardlessOfConditions = true;
            item.rare = (int)itemRarity;
            item.SetShopValues(itemRarity, Item.buyPrice(silver: 75));
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[item.type] = sacrificesRequired;
        }

        public static void Autosize(this Item item) => item.Size = TextureAssets.Item[item.type]?.Size() ?? Vector2.Zero;
    }
}