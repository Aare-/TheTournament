using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GladiatorAllyFactory : GladiatorFactory {

    Gladiator.GladiatorFlavour[] _Flavours = new Gladiator.GladiatorFlavour[] {
        Gladiator.GladiatorFlavour.Dude//,
        //Gladiator.GladiatorFlavour.Dudesse
    };

    public override Gladiator Generate() {
        Gladiator gladiator = base.Generate();
        
        gladiator.Flavour = _Flavours[UnityEngine.Random.Range(0, _Flavours.Count())];

        Array colorValues = Enum.GetValues(typeof(Ability.AbilityColor));

        gladiator.ActiveAbilities.Clear();
        for (int i = 0; i < 3; i++ )
            gladiator.ActiveAbilities.Add(new HeavyAttack(
                (Ability.AbilityColor)colorValues.GetValue(UnityEngine.Random.Range(0, colorValues.Length))
                ));
        
        gladiator.PassiveAbilities.Clear();
        gladiator.PassiveAbilities.Add(new AdrenalineRush());


        return gladiator;
    }    
}

