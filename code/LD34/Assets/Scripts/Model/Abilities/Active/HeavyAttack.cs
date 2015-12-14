﻿using UnityEngine;
using System.Collections;
using TinyMessenger;

//Deal 10-15 damage - can be Red, Blue, Green
public class HeavyAttack : ActiveAbility {
    private AbilityColor _Color;

	public override AbilityColor Color {
        get { return _Color; }
        set { }
    }

    public override int Level {
        get { return 2; }
    }

    public HeavyAttack(AbilityColor color) {
        _Color = color;
    }

    public override void ExecuteOnOpponent(Gladiator gladiator) {
        int damage = Random.Range(10, 15);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
        
    }

    public override void ExecuteOnAlly(Gladiator gladiator) {
        gladiator.Adrenaline -= 10;
    }
}
