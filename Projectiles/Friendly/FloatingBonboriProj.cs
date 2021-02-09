using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrailEffects.Projectiles.Friendly
{
    public class FloatingBonboriProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Floating Bonbori");

            Main.projFrames[Type] = 1;
            Main.projPet[Type] = true;
            ProjectileID.Sets.TrailingMode[Type] = 2;
            ProjectileID.Sets.LightPet[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.Size = TextureAssets.Projectile[Type]?.Size() ?? Vector2.Zero;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
    }
}