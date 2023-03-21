using PulsarModLoader;

namespace SimpleCheat
{
    public class Mod : PulsarMod
    {
        public override string Version => "0.1";

        public override string Author => "Mr__Brick";

        public override string LongDescription => "Lets you replay races for the small price of 100000CR";

        public override string Name => "raceRedo";

        public override string HarmonyIdentifier()
        {
            return $"{Author}.{Name}";
        }
    }
}
