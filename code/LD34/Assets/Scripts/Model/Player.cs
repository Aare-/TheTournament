using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player {
    public List<Gladiator> _Party;

    public Player() {
        _Party = new List<Gladiator>(GameController.Instance.PartySlotsSize);

        GladiatorAllyFactory allyFactory = new GladiatorAllyFactory();
        allyFactory.SetPowerLevel(0);

        for (int i = 0; i < GameController.Instance.PartySize; i++)
            _Party[i] = allyFactory.Generate();        
    }

}
