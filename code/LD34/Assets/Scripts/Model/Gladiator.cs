using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Gladiator {

    private int _Id;
    private int _Level;
    private float _BaseLife;
    private float _Life;
    private float _BaseAdrenaline;
    private float _Adrenaline;
    List<Ability> _Abilities;

    float BaseLife {
        get {
            float value = GameController.Instance.StartingLife;
            value += Math.Max(0, (_Level - 1)) * GameController.Instance.LifeBoostPerLevel;

            return value;
        }
        private set { }
    }
    float BaseAdrenaline {
        get {
            float value = GameController.Instance.StartingAdrenaline;
            return value;
        }
        private set { }
    }

    public float Life {
        get { return _Life; }
        private set { }
    }
    public float Adrenaline {
        get { return _Adrenaline; }
    }

    public Gladiator() {
        _Id = GameController.Instance.GetNewId();

        TinyTokenManager.Instance.Register<Msg.StartFight>("GLADIATOR_" + _Id + "_START_FIGHT", (m) => {
            if (m.OpponentId == _Id || m.AllyId == _Id) {
                _Life = _BaseLife;
                _Adrenaline = _BaseAdrenaline;
            }
        });
    }

}
