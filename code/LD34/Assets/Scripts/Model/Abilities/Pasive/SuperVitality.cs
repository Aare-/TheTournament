using UnityEngine;
using System.Collections;

//Performing actions with neutral color gives 150% boost in adrenaline
public class SuperVitality : PassiveAbility {

    public SuperVitality()
        : base(1, "Super Vitality") {

    }

    public override float ModifyBaseLife(float value) {
        return Mathf.Floor(value + value * 0.25f);
    }
    public override float ModifyBaseAdrenaline(float value) {
        return value;
    }
    public override int ModifyBaseAttackQueueLength(int value) {
        return value;
    }
}
