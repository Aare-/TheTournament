using UnityEngine;
using System.Collections;

//Performing actions with neutral color gives 150% boost in adrenaline
public class SuperVitality : PassiveAbility {    

     int _LifeBoost;

     public SuperVitality(int level, int lifeBoost)
         : base(level, "Extra " + lifeBoost + " HP") {
            _LifeBoost = lifeBoost;
    }

    public override float ModifyBaseLife(float value) {
        return Mathf.Floor(value + _LifeBoost);
    }
    public override float ModifyBaseAdrenaline(float value) {
        return value;
    }
    public override int ModifyBaseAttackQueueLength(int value) {
        return value;
    }
}
