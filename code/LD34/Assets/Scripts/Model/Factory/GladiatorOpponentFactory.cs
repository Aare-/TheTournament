using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GladiatorOpponentFactory : GladiatorFactory {

    Gladiator.GladiatorFlavour[] _Flavours = new Gladiator.GladiatorFlavour[] {
        Gladiator.GladiatorFlavour.Blue,
        Gladiator.GladiatorFlavour.Green,
        Gladiator.GladiatorFlavour.Orange,
        Gladiator.GladiatorFlavour.Red,
    };

    int GetPassiveAbilityLevel() {
        if (GameController.Instance.player.NumberOfVictories < 15)
            return 1;
        if (GameController.Instance.player.NumberOfVictories < 30)
            return 2;
        
        return 3;
    }

    public override Gladiator Generate() {
        Gladiator gladiator = base.Generate();

        gladiator.Flavour = _Flavours[UnityEngine.Random.Range(0, _Flavours.Count())];        

        #region Generating active abilities
        gladiator.ActiveAbilities.Clear();

        if (GameController.Instance.player.NumberOfVictories < 5) {
            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(1, 3), 1, Ability.AbilityColor.Neutral))
                gladiator.ActiveAbilities.Add(a);

            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.GetRandomColorNotNeutral()))
                gladiator.ActiveAbilities.Add(a);
        } else if (GameController.Instance.player.NumberOfVictories < 10) {
            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(1, 3), 1, Ability.AbilityColor.Neutral))
                gladiator.ActiveAbilities.Add(a);

            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.GetRandomColorNotNeutral())) 
                gladiator.ActiveAbilities.Add(a);
            if (Random.Range(0.0f, 1.0f) < 0.5f)
                foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 1, Ability.GetRandomColorNotNeutral())) {
                    gladiator.ActiveAbilities.Add(a);
                }        

        } else if (GameController.Instance.player.NumberOfVictories < 20) {
            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(1, 3), 1, Ability.AbilityColor.Neutral))
                gladiator.ActiveAbilities.Add(a);

            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(1,3), 1, Ability.GetRandomColorNotNeutral()))
                gladiator.ActiveAbilities.Add(a);
            if (Random.Range(0.0f, 1.0f) < 0.7f)
                foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 2, Ability.GetRandomColorNotNeutral())) {
                    gladiator.ActiveAbilities.Add(a);
                }        
        } else if (GameController.Instance.player.NumberOfVictories < 30) {
            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(1, 3), 1, Ability.AbilityColor.Neutral))
                gladiator.ActiveAbilities.Add(a);

            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 2, Ability.GetRandomColorNotNeutral()))
                gladiator.ActiveAbilities.Add(a);
            if (Random.Range(0.0f, 1.0f) < 0.5f)
                foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 2, Ability.GetRandomColorNotNeutral())) {
                    gladiator.ActiveAbilities.Add(a);
                }        
        } else {
            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(1, 3), 1, Ability.AbilityColor.Neutral))
                gladiator.ActiveAbilities.Add(a);

            foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(Random.Range(2,3), 2, Ability.GetRandomColorNotNeutral()))
                gladiator.ActiveAbilities.Add(a);
            if (Random.Range(0.0f, 1.0f) < 0.5f)
                foreach (ActiveAbility a in Ability.GetRandomAbilities<ActiveAbility>(1, 3, Ability.GetRandomColorNotNeutral())) {
                    gladiator.ActiveAbilities.Add(a);
                }        
        }    
        #endregion

        #region Generating passive abilities
        gladiator.PassiveAbilities.Clear();

        if (Random.Range(0, 1f) < GameController.Instance.ChanceOfPassiveAbility) {
            foreach (PassiveAbility a in Ability.GetRandomAbilities<PassiveAbility>(1, GetPassiveAbilityLevel(), Ability.AbilityColor.Neutral))
                gladiator.PassiveAbilities.Add(a);
        }             

        #endregion

        return gladiator;
    }
}
