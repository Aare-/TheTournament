using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player {
    public int NumberOfVictories;
    public List<Gladiator> _Party;
    int _FightingGladiatorId;    
    public Gladiator Opponent;
    public Gladiator FightingGladiator {
        get {
            foreach (Gladiator p in _Party) 
                if (p != null && p._Id == _FightingGladiatorId)
                    return p;
             
            return null;    
        }
        set {
            _FightingGladiatorId = value._Id;
        }
    }

    public Player() {
        NumberOfVictories = 0;
        _Party = new List<Gladiator>();

        GladiatorAllyFactory allyFactory = new GladiatorAllyFactory();
        allyFactory.SetPowerLevel(0);

        for (int i = 0; i < GameController.Instance.PartySlotsSize; i++)
            _Party.Add(null);

        for (int i = 0; i < GameController.Instance.StartPartySize; i++)
            _Party[i] = allyFactory.Generate();            

        TinyTokenManager.Instance.Register<Msg.StartFight>("PLAYER_INSTANCE_START_FIGHT", (m) => {
            foreach (Gladiator g in _Party) {
                if (g != null && g._Id == m.GladiatorId) {
                    _FightingGladiatorId = m.GladiatorId;
                    return;
                }
            }
        });
        TinyTokenManager.Instance.Register<Msg.GameOver>("PLAYER_INSTANCE_GAME_OVER", (m) => {
            TinyTokenManager.Instance.Unregister<Msg.GameOver>("PLAYER_INSTANCE_GAME_OVER");
            TinyTokenManager.Instance.Unregister<Msg.StartFight>("PLAYER_INSTANCE_START_FIGHT");
        });
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
        //TODO: fill this! - convert to party member

        if (!CanAddToParty()) return;
        int posToAddAt = 0;
        foreach (Gladiator g in _Party) {
            if (g == null) break;
            posToAddAt++;
        }

        //Converting to the ally type
        gladiator.Level = 1;
        gladiator.Flavour = Gladiator.GladiatorFlavour.Dude; //TODO: add dudessa

        _Party[posToAddAt] = gladiator;
    }
}
