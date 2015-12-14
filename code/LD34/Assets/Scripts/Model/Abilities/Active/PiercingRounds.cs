using UnityEngine;
using System.Collections;
using TinyMessenger;

//Deals 2-4 damage twice - can be Red, Blue, Green
public class PiercingRounds : ActiveAbility {

    public override AbilityColor Color
    {
        get { return Color; }
        set { }
    }

    public override int Level
    {
        get { return 1; }
    }

    public PiercingRounds(AbilityColor color)
    {
        Color = color;
    }

    public override void ExecuteOnOpponent(Gladiator gladiator)
    {
        int damage = Random.Range(2, 4);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
        
        damage = Random.Range(2, 4);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
    }

    public override void ExecuteOnAlly(Gladiator gladiator)
    {
        gladiator.Adrenaline -= 5;
    }
}
