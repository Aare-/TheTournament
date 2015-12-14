using UnityEngine;
using System.Collections;

//Performing actions with neutral color gives 150% boost in adrenaline
public class AdrenalineRush : PassiveAbility {

    public override float ModifyBaseLife(float value)
    {
        return value;
    }
    public override float ModifyBaseAdrenaline(float value)
    {
        return value;
    }
    public override int ModifyBaseAttackQueueLength(int value)
    {
        return value;
    }
}
