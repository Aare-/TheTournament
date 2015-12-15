using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;

public abstract class ActiveAbility : Ability {

    int _AdrenalineCost;

    public int AdrenalineCost {
        get {
            if (Color == AbilityColor.Neutral)
                return Math.Abs(_AdrenalineCost);            
            return -Math.Abs(_AdrenalineCost);            
        }
        set { }
    }

    public ActiveAbility(int level, string name, AbilityColor color, int adrenalineCost, GladiatorController.AnimationState state) : base(level, name, color, state) {
        _AdrenalineCost = adrenalineCost;
    }

    public void ExecuteOnOpponent(Gladiator gladiator) {
        if (IsSmirkingAgainst(gladiator.LastActiveColor)) {
            TinyMessengerHub.Instance.Publish<Msg.AbilitySmirked>(new Msg.AbilitySmirked(gladiator._Id));
            ExecuteOnOpponent(gladiator, true);
        } else {
            ExecuteOnOpponent(gladiator, false);
        }
    }
    protected abstract void ExecuteOnOpponent(Gladiator gladiator, bool isSmirked);
    public virtual void ExecuteOnAlly(Gladiator gladiator) {
        gladiator.Adrenaline += AdrenalineCost;
    }
    public bool CanPerformAbility(Gladiator g) {
        if (Color != AbilityColor.Neutral && g.Adrenaline < AdrenalineCost)
            return false;
        return true;
    }
}

