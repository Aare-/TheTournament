using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;
using UnityEngine;

public class Gladiator {

    public enum GladiatorFlavour {
        Dude,
        Dudesse,

        Red,
        Blue,
        Green,
        Orange
    }

    #region Data
    private bool _IsFighting;
    private int _Id;
    private string _Name;
    public GladiatorFlavour _Flavour;
    private int _Level;
    private float _BaseLife;
    private float _Life;
    private int _Shields;
    private float _BaseAdrenaline;
    private float _Adrenaline;
    private Ability.AbilityColor _LastActiveColor;
    List<ActiveAbility> _ActiveAbilities;
    List<PassiveAbility> _PassiveAbilities;
    List<ActiveAbility> _AttackQueue;
    #endregion

    #region Properties
    float BaseLife {
        get {
            float value = GameController.Instance.StartingLife;
            value += System.Math.Max(0, (Level - 1)) * GameController.Instance.LifeBoostPerLevel;

            foreach (var p in _PassiveAbilities)
                value = p.ModifyBaseLife(value);

            return value;
        }
        set { }
    }
    float BaseAdrenaline {
        get {
            float value = GameController.Instance.StartingAdrenaline;
            value += System.Math.Max(0, (Level - 1)) * GameController.Instance.AdrenalineBoostPerLevel;

            foreach (var p in _PassiveAbilities)
                value = p.ModifyBaseAdrenaline(value);

            return value;
        }
        set { }
    }
    public string Name {
        get { return _Name; }
        set {
            _Name = value;
        }
    }
    public GladiatorFlavour Flavour {
        get { return _Flavour; }
        set { _Flavour = value; }
    }
    public int Level {
        get { return _Level; }
        private set { }
    }
    public float Life {
        get { return _Life; }
        set {
            _Life = value;
            if (_Life <= 0) {
                TinyMessengerHub.Instance.Publish<Msg.GladiatorDefeated>(new Msg.GladiatorDefeated(_Id));
            }
        }
    }
    public float Adrenaline {
        get { return _Adrenaline; }
        set {

        }
    }
    public List<ActiveAbility> ActiveAbilities {
        get { return _ActiveAbilities; }
        private set { }
    }
    public List<PassiveAbility> PassiveAbilities {
        get { return _PassiveAbilities; }
        private set { }
    }
    public List<ActiveAbility> AttackQueue {
        get { return _AttackQueue; }
        private set { }
    }
    public Ability.AbilityColor LastActiveColor {
        get { 
            if (_IsFighting) return _LastActiveColor;
            return Ability.AbilityColor.Neutral;
        }
        set { }
    }
    int AttackQueueLength {
        get {
            int value = GameController.Instance.BaseAttackQueueLength;

            foreach (var p in _PassiveAbilities)
                value = p.ModifyBaseAttackQueueLength(value);

            return value;
        }
        set { }
    }
    #endregion

    public Gladiator() {
        _Level = 1;
        _Id = GameController.Instance.GetNewId();
        _ActiveAbilities = new List<ActiveAbility>();
        _PassiveAbilities = new List<PassiveAbility>();

        TinyTokenManager.Instance.Register<Msg.StartFight>("GLADIATOR_" + _Id + "_START_FIGHT", OnStartFight);
        TinyTokenManager.Instance.Register<Msg.StartFightRound>("GLADIATOR_" + _Id + "_FIGHT_ROUND_STARTED", OnFightRoundStarted);
        TinyTokenManager.Instance.Register<Msg.PerformAttack>("GLADIATOR_" + _Id + "_PERFORM_ATTACK", OnPerformAttack);
        TinyTokenManager.Instance.Register<Msg.PrepareToPerformAttack>("GLADIATOR_" + _Id + "_PREPARE_TO_PERFORM_ATTACK", OnPrepareToPerformAttack);
        TinyTokenManager.Instance.Register<Msg.PerformActiveAbility>("GLADIATOR_" + _Id + "_ABILITY", OnPerformAbility);
        TinyTokenManager.Instance.Register<Msg.GladiatorDefeated>("GLADIATOR_" + _Id + "_GLADIATOR_DEFEATED", OnGladiatorDefeated);        
        TinyTokenManager.Instance.Register<Msg.GladiatorKilled>("GLADIATOR_" + _Id + "_ON_KILLED", OnKilled);        
    }    

    #region Event handlers
    void OnStartFight(Msg.StartFight m) {
        if (m.GladiatorId == _Id) {
            _IsFighting = true;
            _Life = BaseLife;
            _Adrenaline = BaseAdrenaline;
            _Shields = 0;
        }
    }
    void OnFightRoundStarted(Msg.StartFightRound m) {
        if (m.GladiatorId == _Id) {
            GetNewAttackQueue();
        }
    }
    void OnPrepareToPerformAttack(Msg.PrepareToPerformAttack m) {
        if (_IsFighting && _AttackQueue.Count > 0) {            
            _LastActiveColor = _AttackQueue[0].Color;            
        }
    }
    void OnPerformAttack(Msg.PerformAttack m) {
        if (_IsFighting) {
            if (AttackQueue.Count > 0) {
                ActiveAbility a = AttackQueue[0];
                AttackQueue.RemoveAt(0);

                TinyMessengerHub.Instance.Publish<Msg.PerformActiveAbility>(new Msg.PerformActiveAbility(a, _Id));                
            }
        }
    }
    void OnPerformAbility(Msg.PerformActiveAbility m) {
        if (m.ExecutingGladiatorId == _Id)
            m.Ability.ExecuteOnAlly(this);
        else if (_IsFighting)
            m.Ability.ExecuteOnOpponent(this);        
    }
    void OnGladiatorDefeated(Msg.GladiatorDefeated m) {
        if (_IsFighting) {
            _IsFighting = false;
        }
    }
    void OnKilled(Msg.GladiatorKilled m) {
        if (m.GladiatorId == _Id) {
            TinyTokenManager.Instance.Unregister<Msg.StartFight>("GLADIATOR_" + _Id + "_START_FIGHT");
            TinyTokenManager.Instance.Unregister<Msg.StartFightRound>("GLADIATOR_" + _Id + "_FIGHT_ROUND_STARTED");
            TinyTokenManager.Instance.Unregister<Msg.StartFight>("GLADIATOR_" + _Id + "_ON_KILLED");
            TinyTokenManager.Instance.Unregister<Msg.GladiatorDefeated>("GLADIATOR_" + _Id + "_GLADIATOR_DEFEATED");
            TinyTokenManager.Instance.Unregister<Msg.PerformActiveAbility>("GLADIATOR_" + _Id + "_ABILITY");
            TinyTokenManager.Instance.Unregister<Msg.PerformAttack>("GLADIATOR_" + _Id + "_PERFORM_ATTACK");
            TinyTokenManager.Instance.Unregister<Msg.PrepareToPerformAttack>("GLADIATOR_" + _Id + "_PREPARE_TO_PERFORM_ATTACK");
        }
    }
    #endregion

    public List<ActiveAbility> GetNewAttackQueue() {
        AttackQueue.Clear();

        int queueLength = AttackQueueLength;
        for (int i = 0; i < queueLength; i++)
            AttackQueue.Add(_ActiveAbilities[Random.Range(0, _ActiveAbilities.Count)]);        

        return AttackQueue;
    }
    public void LearnNewAbility(Ability a) {
        if ((a is ActiveAbility))
            _ActiveAbilities.Add((ActiveAbility)a);        
        if ((a is PassiveAbility))
            _PassiveAbilities.Add((PassiveAbility)a);


        List<Ability> _AllAbilities = new List<Ability>();
        foreach (var b in _ActiveAbilities)
            _AllAbilities.Add(b);
        foreach (var p in _PassiveAbilities)
            _AllAbilities.Add(p);

        _AllAbilities.Sort(CompareByColorAndLevel);

        int counter = 0;
        int position = 0;
        int lastLevel = _AllAbilities[0].Level;
        Ability.AbilityColor lastColor = _AllAbilities[0].Color;
        foreach(var b in _AllAbilities) {
            if (b.Level != lastLevel || b.Color != lastColor)
                counter = 0;
            else
                counter++;
            if (counter >= 3) {
                List<Ability> abilitiesToUpgrade = new List<Ability>();
                for (int i = 0; i < 3; i++)
                    abilitiesToUpgrade.Add(_AllAbilities[position - i]);

                LevelUp(abilitiesToUpgrade);

                break;
            }

            position++;
        }
    }
    private void LevelUp(List<Ability> abilities) {
        foreach (var a in abilities) {
            if((a is ActiveAbility))
                _ActiveAbilities.Remove((ActiveAbility)a);
            else
                _PassiveAbilities.Remove((PassiveAbility)a);
        }

        //TODO: show UI tha tallow to choose
        Ability.GetRandomAbilities(3, abilities[0].Level, abilities[0].Color);

        Level++;
    }

    private static int CompareByColorAndLevel(Ability x, Ability y) {
        if (x.Color == y.Color)
            return x.Level - y.Level;
        return x.Color - y.Color;
    }
}