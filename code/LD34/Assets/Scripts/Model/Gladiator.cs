using System;
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
    public int _Id;
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
    public float BaseLife {
        get {
            float value = GameController.Instance.StartingLife;
            value += System.Math.Max(0, (Level - 1)) * GameController.Instance.LifeBoostPerLevel;

            if(_PassiveAbilities != null)
                foreach (var p in _PassiveAbilities)
                    value = p.ModifyBaseLife(value);

            return value;
        }
        set { }
    }
    public float BaseAdrenaline {
        get {
            float value = GameController.Instance.StartingAdrenaline;
            value += System.Math.Max(0, (Level - 1)) * GameController.Instance.AdrenalineBoostPerLevel;

            if (_PassiveAbilities != null)
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
        set {
            _Level = Math.Min(3, value); //TODO: zmien jak dojdzie kolejna ewolucja
        }
    }
    public float Life {
        get { return _Life; }
        set {
            _Life = value;
            TinyMessengerHub.Instance.Publish<Msg.GladiatorHealthChanged>(new Msg.GladiatorHealthChanged(_Id, _Life / BaseLife));            
        }
    }
    public float Adrenaline {
        get { return _Adrenaline; }
        set {
            _Adrenaline = value;
            TinyMessengerHub.Instance.Publish<Msg.GladiatorAdrenalineChanged>(new Msg.GladiatorAdrenalineChanged(_Id, _Adrenaline / BaseAdrenaline));
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

            //foreach (var p in _PassiveAbilities)
              //  value = p.ModifyBaseAttackQueueLength(value);

            return value;
        }
        set { }
    }

    public ActiveAbility LastLevelUpedAbility = null;
    public List<ActiveAbility> EvolvedAbilities = null;
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
        TinyTokenManager.Instance.Register<Msg.DealDamage>("GLADIATOR_" + _Id + "_DEAL_DAMAGE", 
            (m) => {
                if (m.GladiatorID == _Id) Life -= m.Damage;                
            });        
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
                ActiveAbility a = _AttackQueue[0];
                _AttackQueue.RemoveAt(0);

                if(a.CanPerformAbility(this)) {
                    TinyMessengerHub.Instance.Publish<Msg.PerformActiveAbility>(new Msg.PerformActiveAbility(a, _Id));
                } else {
                    TinyMessengerHub.Instance.Publish<Msg.NotEnughAdrenaline>(new Msg.NotEnughAdrenaline(_Id));
                }
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
            TinyTokenManager.Instance.Unregister<Msg.DealDamage>("GLADIATOR_" + _Id + "_DEAL_DAMAGE");
        }
    }
    #endregion

    private List<ActiveAbility> GetNewAttackQueue() {
        if (_AttackQueue == null)
            _AttackQueue = new List<ActiveAbility>();
        _AttackQueue.Clear();

        int queueLength = AttackQueueLength;
        for (int i = 0; i < queueLength; i++)
            _AttackQueue.Add(_ActiveAbilities[UnityEngine.Random.Range(0, _ActiveAbilities.Count)]);

        return _AttackQueue;
    }
    public void LearnNewAbility(Ability a) {
        if (a == null) return;

        if ((a is ActiveAbility))
            _ActiveAbilities.Add((ActiveAbility)a);        
        if ((a is PassiveAbility))
            _PassiveAbilities.Add((PassiveAbility)a);
        
        TestForLevelUp();
    }
    void TestForLevelUp() {        

        List<ActiveAbility> _AllAbilities = new List<ActiveAbility>();
        foreach (var b in _ActiveAbilities)
            if(b.Color != Ability.AbilityColor.Neutral)
                _AllAbilities.Add(b);

        _AllAbilities.Sort(CompareByColorAndLevel);

        if (_AllAbilities.Count <= 0) return;

        int counter = 0;
        int position = 0;
        int lastLevel = _AllAbilities[0].Level;
        Ability.AbilityColor lastColor = _AllAbilities[0].Color;        
        foreach (var b in _AllAbilities) {            

            if (b.Level != lastLevel || b.Color != lastColor) {
                counter = 1;
                lastColor = b.Color;
                lastLevel = b.Level;
            } else
                counter++;

            if (counter >= GameController.Instance.LevelUpAtAbilityC) {
                List<ActiveAbility> abilitiesToUpgrade = new List<ActiveAbility>();
                for (int i = 0; i < GameController.Instance.LevelUpAtAbilityC; i++)
                    abilitiesToUpgrade.Add(_AllAbilities[position - i]);
                
                LevelUp(abilitiesToUpgrade);

                return;
            }

            position++;
        } 
    }
    private void LevelUp(List<ActiveAbility> abilities) {        

        foreach (var a in abilities) 
            _ActiveAbilities.Remove(a);

        EvolvedAbilities = abilities;
        ActiveAbility newAbility = Ability.GetRandomAbilities<ActiveAbility>(1, abilities[0].Level + 1, abilities[0].Color)[0];
        LastLevelUpedAbility = newAbility;
        

        LearnNewAbility(newAbility);
    }

    private static int CompareByColorAndLevel(Ability x, Ability y) {
        if (x.Color == y.Color)
            return x.Level - y.Level;
        return x.Color - y.Color;
    }
}