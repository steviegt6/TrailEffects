using Terraria.ModLoader;
using TrailEffects.Items.Pets.LightPets;

namespace TrailEffects.ModPlayers
{
    /// <summary>
    /// Only used to manage the <see cref="FloatingBonbori"/>
    /// </summary>
    public class FloatingBonboriPlayer : ModPlayer
    {
        public bool hasFloatingBonboriPet;

        public override void ResetEffects() => hasFloatingBonboriPet = false;
    }
}