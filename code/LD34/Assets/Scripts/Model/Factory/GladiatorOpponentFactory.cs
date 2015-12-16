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

        foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.AbilityColor.Neutral))
            gladiator.ActiveAbilities.Add(a);    
        foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.AbilityColor.Red))//Ability.GetRandomColorNotNeutral())) 
        {
            gladiator.ActiveAbilities.Add(a);
        }        

        #endregion

        #region Generating passive abilities
        gladiator.PassiveAbilities.Clear();

        foreach (PassiveAbility a in Ability.GetRandomAbilities<PassiveAbility>(1, 1, Ability.AbilityColor.Neutral)) {
            gladiator.PassiveAbilities.Add(a);
        }                    

        #endregion

        return gladiator;
    }
}
