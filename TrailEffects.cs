using Terraria.ModLoader;

namespace TrailEffects
{
    public class TrailEffects : Mod
    {
        /// <summary>
        /// <see cref="TrailEffects"/>' instance, the same instance utilizied by tModLoader.
        /// </summary>
        public TrailEffects Instance { get; }

        public TrailEffects()
        {
            Instance = this;

            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}