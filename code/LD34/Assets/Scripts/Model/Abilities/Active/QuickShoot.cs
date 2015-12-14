using UnityEngine;
using System.Collections;
using TinyMessenger;

//Deal 3-9 damage twice - can be Red, Blue, Green
public class QuickShoot : ActiveAbility {

	public override AbilityColor Color
    {
        get { return Color; }
        set { }
    }

    public override int Level
    {
        get { return 2; }
    }

    public QuickShoot(AbilityColor color)
    {
        Color = color;
        Name = "QuickShoot";
    }

    public override void ExecuteOnOpponent(Gladiator gladiator)
    {
        int damage = Random.Range(3, 9);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
        
        damage = Random.Range(3, 9);
        gladiator.Life -= damage;
        TinyMessengerHub.Instance.Publish<Msg.ShowDamage>(new Msg.ShowDamage(gladiator._Id, damage));
    }

    public override void ExecuteOnAlly(Gladiator gladiator)
    {
        gladiator.Adrenaline -= 10;
    }
}
