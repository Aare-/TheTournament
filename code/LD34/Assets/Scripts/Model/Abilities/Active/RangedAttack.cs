using TinyMessenger;
using UnityEngine;

public class RangedAttack : ActiveAbility {

    int _MinDamage;
    int _MaxDamage;

    public RangedAttack(int level, string name, AbilityColor color, GladiatorController.AnimationState state, int adrenalineCost, int minDamage, int maxDamage)
        : base(level, name, color, adrenalineCost, state) {

        _MinDamage = minDamage;
        _MaxDamage = maxDamage;
    }
    
    protected override void ExecuteOnOpponent(Gladiator gladiator, bool isSmirked) {
        float damageValue = Random.Range(_MinDamage, _MaxDamage);
        if (isSmirked)
            damageValue = Mathf.Floor(damageValue * 1.5f);

        TinyMessengerHub.Instance.Publish<Msg.DealDamage>(new Msg.DealDamage(gladiator._Id, damageValue));
    }
    
}
