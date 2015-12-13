using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class PassiveAbility : Ability {

    public virtual float ModifyBaseLife(float value) {
        return value;
    }
    public virtual float ModifyBaseAdrenaline(float value) {
        return value;
    }
    public virtual int ModifyBaseAttackQueueLength(int value) {
        return value;
    }

}
