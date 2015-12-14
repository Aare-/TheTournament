using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class GladiatorFactory {

    protected int _PowerLevel;
    protected int _ForceLevel;
    NameGenerator _NameGenerator;

    public GladiatorFactory() {
        _PowerLevel = 0;
        _ForceLevel = -1;
        _NameGenerator = new NameGenerator();
    }

    public virtual void SetPowerLevel(int powerLevel) {
        _PowerLevel = powerLevel;
    }
    public virtual void ForceLevel(int level) {
        _ForceLevel = level;
    }

    public virtual Gladiator Generate() {
        Gladiator gladiator = new Gladiator();

        gladiator.Name = _NameGenerator.GenerateName();
        if (_ForceLevel != -1)
            gladiator.Level = _ForceLevel;
        else {
            gladiator.Level = 1;
            //TODO: make it dependable on the power level
        }

        return gladiator;
    }
}

