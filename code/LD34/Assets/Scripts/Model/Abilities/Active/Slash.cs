using UnityEngine;
using System.Collections;
using TinyMessenger;

//Deals 10-15 damage
public class Slash : ActiveAbility {

    public override AbilityColor Color
    {
        get { return AbilityColor.Neutral; }
    }

    public override void ExecuteOnOpponent(Gladiator gladiator)
    {
        int damage = Random.Range(10, 15);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
    }

    public override void ExecuteOnAlly(Gladiator gladiator)
    {
        gladiator.Adrenaline += GameController.Instance.AdrenalineBoostPerNeutralAbility;
    }
}
