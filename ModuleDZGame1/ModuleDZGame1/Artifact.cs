using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDZGame1
{
    #region Artifact
    public abstract class Artifact
    {
        public string Name { get; set; }
        public int Weigth { get; set; }
        protected Player Player;
        protected KeyValuePair<ArtifactTypesEnum, int> ArtifaktType;
        public Artifact(Player player, string name, KeyValuePair<ArtifactTypesEnum, int> artifactType, int weigth )
        {
            Player = player;
            Name = name;
            Weigth = weigth;
            ArtifaktType = artifactType;
        }

        public abstract void Use();
    }
    #endregion

    #region FunfWthMn
    public class FunfWthMn: Artifact
    {

        public FunfWthMn(Player player, string name, KeyValuePair<ArtifactTypesEnum, int> artifactType, int weigth) :base (player, name, artifactType, weigth)
        {
            Player.Mn += Player.Mn + artifactType.Value;

        }
            public override void Use()
        {
            Player.Mn += new Random().Next(1, 5);
            Console.WriteLine($"Players Mn: {Player.Mn}");
        }
    }
    #endregion

    #region FunfWthHlt
    public class FunfWthHlt: Artifact
    {
        public FunfWthHlt(Player player, string name, KeyValuePair<ArtifactTypesEnum, int> artifactType, int weigth) : base(player, name, artifactType, weigth)
        {
            Player.Health += Player.Health + artifactType.Value;
        }
            public override void Use()
        {
            Player.Health += new Random().Next(1, 5);
            Console.WriteLine($"Players health: {Player.Health}");
        }
    }
    #endregion

    #region AmulOfPwr
    public class AmulOfPwr: Artifact
    { 
    public AmulOfPwr(Player player, string name, KeyValuePair<ArtifactTypesEnum, int> artifactType, int weigth) : base(player, name, artifactType, weigth)
        {
            Player.Power += Player.Power + artifactType.Value;
        }

        public override void Use()
        {
            Player.Mn += new Random().Next(1, 5);
            Console.WriteLine($"Players power: {Player.Power}");
        }
    }
    #endregion
}
