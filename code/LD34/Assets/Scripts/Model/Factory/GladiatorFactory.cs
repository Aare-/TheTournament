using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class GladiatorFactory {

    protected int _PowerLevel;
    NameGenerator _NameGenerator;

    public GladiatorFactory() {
        _PowerLevel = 0;
        _NameGenerator = new NameGenerator();
    }

    public virtual void SetPowerLevel(int powerLevel) {
        _PowerLevel = powerLevel;
    }

    public virtual Gladiator Generate() {
        Gladiator gladiator = new Gladiator();

        gladiator.Name = _NameGenerator.GenerateName();

        return gladiator;
    }
}

