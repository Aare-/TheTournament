using UnityEngine;
using System.Collections;

//Performing actions with neutral color gives 150% boost in adrenaline
public class AdrenalineRush : PassiveAbility {

    int _AdrenalineBoost;

    public AdrenalineRush(int level, int adrenalineBoost)
        : base(level, "Extra " + adrenalineBoost + " ADR") {
            _AdrenalineBoost = adrenalineBoost;
    }

    public override float ModifyBaseLife(float value) {
        return value;
    }
    public override float ModifyBaseAdrenaline(float value) {
        return Mathf.Floor(value + _AdrenalineBoost);
    }
    public override int ModifyBaseAttackQueueLength(int value) {
        return value;
    }
}
