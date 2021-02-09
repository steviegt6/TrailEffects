using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TrailEffects.Buffs.Positive;
using TrailEffects.Items.Bags;
using TrailEffects.Projectiles.Friendly;

namespace TrailEffects.Items.Pets.LightPets
{
    public class FloatingBonbori : TEItem
    {
        public override string Texture => "TrailEffects/Items/Bags/WanderingBonbori";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Floating Bonbori");
            Tooltip.SetDefault("Attracts fireflies" +
                "\nFollows the player");
        }

        public override void SafeSetDefaults()
        {
            Item.damage = 0;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.shoot = ModContent.ProjectileType<FloatingBonboriProj>();
            Item.UseSound = SoundID.Item2;
            Item.useAnimation = Item.useTime = 20;
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.buffType = ModContent.BuffType<FloatingBonboriBuff>();
            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(silver: 75));
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffTime, 3600);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<WanderingBonbori>())
                .AddIngredient(ItemID.DynastyWood, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}