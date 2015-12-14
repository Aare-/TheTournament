using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GladiatorAllyFactory : GladiatorFactory {

    Gladiator.GladiatorFlavour[] _Flavours = new Gladiator.GladiatorFlavour[] {
        Gladiator.GladiatorFlavour.Dude//,
        //Gladiator.GladiatorFlavour.Dudesse
    };

    public override Gladiator Generate() {
        Gladiator gladiator = base.Generate();

        gladiator.Flavour = _Flavours[UnityEngine.Random.Range(0, _Flavours.Count())];

        return gladiator;
    }
}

