using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class GladiatorFactory {

    protected int _PowerLevel;

    public GladiatorFactory() {
        _PowerLevel = 0;
    }

    public virtual void SetPowerLevel(int powerLevel) {
        _PowerLevel = powerLevel;
    }

    public virtual Gladiator Generate() {
        Gladiator gladiator = new Gladiator();
        return gladiator;
    }
}

