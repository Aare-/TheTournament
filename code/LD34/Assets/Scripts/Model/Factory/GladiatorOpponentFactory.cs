using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GladiatorOpponentFactory : GladiatorFactory {

    Gladiator.GladiatorFlavour[] _Flavours = new Gladiator.GladiatorFlavour[] {
        Gladiator.GladiatorFlavour.Blue,
        Gladiator.GladiatorFlavour.Green,
        Gladiator.GladiatorFlavour.Orange,
        Gladiator.GladiatorFlavour.Red,
    };    

    public override Gladiator Generate() {
        Gladiator gladiator = base.Generate();

        gladiator.Flavour = _Flavours[UnityEngine.Random.Range(0, _Flavours.Count())];

        #region Generating active abilities
        gladiator.ActiveAbilities.Clear();


        #endregion

        #region Generating passive abilities
        gladiator.PassiveAbilities.Clear();

        #endregion

        return gladiator;
    }
}
