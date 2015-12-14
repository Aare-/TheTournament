using TinyMessenger;
using UnityEngine;

//Deal 15-20 damage
public class Charge : ActiveAbility
{
    public override AbilityColor Color
    {
        get { return AbilityColor.Red; }
    }

    public override int Level
    {
        get { return 3; }
    }

    public override void ExecuteOnOpponent(Gladiator gladiator)
    {
        int damage = Random.Range(15, 20);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
    }

    public override void ExecuteOnAlly(Gladiator gladiator)
    {
        gladiator.Adrenaline -= 15;
    }
}
