using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GladiatorAllyFactory : GladiatorFactory {

    Gladiator.GladiatorFlavour[] _Flavours = new Gladiator.GladiatorFlavour[] {
        Gladiator.GladiatorFlavour.Dude,
        Gladiator.GladiatorFlavour.Dudesse
    };

    public override Gladiator Generate() {
        Gladiator gladiator = base.Generate();
        
        gladiator.Flavour = _Flavours[UnityEngine.Random.Range(0, _Flavours.Count())];

        System.Array colorValues = System.Enum.GetValues(typeof(Ability.AbilityColor));

        gladiator.ActiveAbilities.Clear();


        #region Generating active abilities
        gladiator.ActiveAbilities.Clear();

        foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.AbilityColor.Neutral))
            gladiator.ActiveAbilities.Add(a);
        foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.GetRandomColorNotNeutral()))
            gladiator.ActiveAbilities.Add(a);
        
        #endregion

        #region Generating passive abilities
        gladiator.PassiveAbilities.Clear();
        if (Random.Range(0, 1f) < GameController.Instance.ChanceOfPassiveAbility) {
            foreach (PassiveAbility a in Ability.GetRandomAbilities<PassiveAbility>(1, 1, Ability.AbilityColor.Neutral))
                gladiator.PassiveAbilities.Add(a);
        }
        #endregion

        return gladiator;
    }    
}

