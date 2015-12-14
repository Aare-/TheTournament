using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player {
    public int NumberOfVictories;
    public List<Gladiator> _Party;
    public Gladiator Opponent;
    public Gladiator NextOpponent;

    public Player() {
        NumberOfVictories = 0;
        _Party = new List<Gladiator>(0);

        GladiatorAllyFactory allyFactory = new GladiatorAllyFactory();
        allyFactory.SetPowerLevel(0);

        for (int i = 0; i < 4; i++) //TODO: fix this to be set from inspector
            _Party.Add(allyFactory.Generate());      
       
    }

    public void RemoveFromParty(Gladiator gladiator) {
        _Party.Remove(gladiator);
        _Party.Add(null);
    }

    public int GetPartyLength() {
        int counter = 0;
        foreach (Gladiator g in _Party) 
            if (g != null)
                counter++;

        return counter;
    }

    public bool CanAddToParty() {
        foreach (Gladiator g in _Party)
            if (g == null) return true;
        
        return false;
    }

    public void AddToParty(Gladiator gladiator) {
        if (!CanAddToParty()) return;
        int posToAddAt = 0;
        foreach (Gladiator g in _Party) {
            if (g == null) break;
            posToAddAt++;
        }

        _Party[posToAddAt] = gladiator;
    }
}
