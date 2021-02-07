using Terraria.ModLoader;

namespace TrailEffects
{
    public class TrailEffects : Mod
    {
        public override void Load()
        {
            Terraria.Main.instance = new Terraria.Main();
        }
    }
}
