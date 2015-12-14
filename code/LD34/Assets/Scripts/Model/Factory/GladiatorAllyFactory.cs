using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GladiatorAllyFactory : GladiatorFactory {

    public override Gladiator Generate() {
        Gladiator gladiator = base.Generate();

        return gladiator;
    }
}

