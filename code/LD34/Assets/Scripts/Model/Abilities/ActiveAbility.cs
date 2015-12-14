using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ActiveAbility : Ability {

    public virtual int AdrenalineCost
    {
        get { return 5; }
        set { }
    }

    public virtual void ExecuteOnOpponent(Gladiator gladiator) {
        
    }
    public virtual void ExecuteOnAlly(Gladiator gladiator) {

    }
}

