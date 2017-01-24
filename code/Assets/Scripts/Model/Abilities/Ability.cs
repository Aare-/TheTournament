using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Ability {
    public enum AbilityColor {
        Neutral,
        Blue,
        Red,
        Green
    }

    static Ability[][] Abilities = new Ability[][] { 
        new Ability[] {
            #region Level 1 Active Abilities
                #region Neutral
                new RangedAttack(1, "Deal 2 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, GameController.Instance.AdrenalineBoostPerNeutralAbility, 
                    2, 2),
                new RangedAttack(1, "Deal 1-3 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, GameController.Instance.AdrenalineBoostPerNeutralAbility, 
                    1, 3),
                #endregion

                #region Green
                new RangedAttack(1, "Deal 3 DMG", AbilityColor.Green, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength, 
                    3, 3),
                new RangedAttack(1, "Deal 2-4 DMG", AbilityColor.Green, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength, 
                    2, 4),
                #endregion

                #region Red
                new RangedAttack(1, "Deal 3 DMG", AbilityColor.Red, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength, 
                    3, 3),
                new RangedAttack(1, "Deal 2-4 DMG", AbilityColor.Red, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength, 
                    2, 4),
                #endregion

                #region Blue
                new RangedAttack(1, "Deal 3 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength, 
                    3, 3),
                new RangedAttack(1, "Deal 2-4 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength, 
                    2, 4),
                #endregion

            #endregion

            #region Level 1 Passive Abilities
            new AdrenalineRush(1, GameController.Instance.BaseAttackQueueLength * 1),
            new SuperVitality(1, 10)
            #endregion
        
        },
        new Ability[] {
            #region Level 2 Active Abilities
                #region Neutral
                new RangedAttack(2, "Deal 4 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 0, 
                    4, 4),
                new RangedAttack(2, "Deal 3-5 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 0, 
                    3, 5),
                #endregion

                #region Green
                new RangedAttack(2, "Deal 5 DMG", AbilityColor.Green, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 1, 
                    5, 5), 
                new RangedAttack(2, "Deal 4-6 DMG", AbilityColor.Green, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 1, 
                    4, 6),  
                #endregion

                #region Red
                new RangedAttack(2, "Deal 5 DMG", AbilityColor.Red, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 1, 
                    5, 5), 
                new RangedAttack(2, "Deal 4-6 DMG", AbilityColor.Red, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 1, 
                    4, 6),  
                #endregion

                #region Blue
                new RangedAttack(2, "Deal 5 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 1, 
                    5, 5), 
                new RangedAttack(2, "Deal 4-6 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 1, 
                    4, 6), 
                #endregion

            #endregion

            #region Level 2 Passive Abilities
            new AdrenalineRush(2, GameController.Instance.BaseAttackQueueLength * 2),
            new SuperVitality(2, 20)
            #endregion
        
        },
        new Ability[] {
            #region Level 3 Active Abilities
                #region Neutral
                new RangedAttack(3, "Deal 6 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 0, 
                    6, 6),
                new RangedAttack(3, "Deal 5-7 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 0, 
                    5, 7),
                #endregion

                #region Green
                new RangedAttack(3, "Deal 7 DMG", AbilityColor.Green, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 2, 
                    7, 7),
                new RangedAttack(3, "Deal 6-8 DMG", AbilityColor.Green, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 2, 
                    6, 8), 
                #endregion

                #region Red
                new RangedAttack(3, "Deal 7 DMG", AbilityColor.Red, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 2, 
                    7, 7),
                new RangedAttack(3, "Deal 6-8 DMG", AbilityColor.Red, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 2, 
                    6, 8),  
                #endregion

                #region Blue
                new RangedAttack(3, "Deal 7 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 2, 
                    7, 7),
                new RangedAttack(3, "Deal 6-8 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 2, 
                    6, 8),  
                #endregion

            #endregion

            #region Level 3 Passive Abilities
            new AdrenalineRush(3, GameController.Instance.BaseAttackQueueLength * 3),
            new SuperVitality(3, 30)
            #endregion
        
        },
        new Ability[] {
            #region Level 4 Active Abilities
                #region Neutral
                new RangedAttack(4, "Deal 8 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 0, 
                    8, 8),
                new RangedAttack(4, "Deal 7-9 DMG", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 0, 
                    7, 9),
                #endregion

                #region Green
                new RangedAttack(4, "Deal 9 DMG", AbilityColor.Green, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 3, 
                    9, 9),
                new RangedAttack(4, "Deal 8-10 DMG", AbilityColor.Green, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 3, 
                    8, 10), 
                #endregion

                #region Red
                new RangedAttack(4, "Deal 9 DMG", AbilityColor.Red, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 3, 
                    9, 9),
                new RangedAttack(4, "Deal 8-10 DMG", AbilityColor.Red, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 3, 
                    8, 10),  
                #endregion

                #region Blue
                new RangedAttack(4, "Deal 9 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, GameController.Instance.BaseAttackQueueLength + 3, 
                    9, 9),
                new RangedAttack(4, "Deal 8-10 DMG", AbilityColor.Blue, GladiatorController.AnimationState.Meele, GameController.Instance.BaseAttackQueueLength + 3, 
                    8, 10),  
                #endregion

            #endregion

            #region Level 4 Passive Abilities
            new AdrenalineRush(4, GameController.Instance.BaseAttackQueueLength * 4),
            new SuperVitality(4, 40)
            #endregion
        
        }
    };

    public static T[] GetRandomAbilities<T>(int count, int level, AbilityColor color) where T : Ability {
        level--;        
        if (level < 0 || level >= Abilities.Count())
            throw new System.ArgumentOutOfRangeException("Level is out of range");

        List<Ability> candidates = new List<Ability>(Abilities[level]).Where((a) => (a is T) && a.Color == color).ToList();
        if(candidates.Count() < count)
            throw new System.ArgumentOutOfRangeException("Not enough elements at this level");

        T[] result = new T[count];

        for (int i = 0; i < count; i++) {
            result[i] = (T)candidates[Random.Range(0, candidates.Count())];
            candidates.Remove(result[i]);
        }

        return result;
    }

    #region Data
    string _Name = "";
    int _Level = 1;
    GladiatorController.AnimationState _State;
    AbilityColor _Color = AbilityColor.Neutral;
    #endregion

    #region Properties
    public string Name {
        get { 
            return _Name; 
        }
        private set {
        }
    }
    public virtual AbilityColor Color {
        get { return _Color; }
        set { }
    }
    public int Level {
        get { return _Level; }
    }
    #endregion

    public Ability(int level, string name, AbilityColor color, GladiatorController.AnimationState state) {
        _Level = level;
        _Name = name;
        _Color = color;
        _State = state;
    }
    public virtual string Info {
        get { return "No Info";  }
        set { }
    }

    public bool IsSmirkingAgainst(AbilityColor b) {
        if (Color == b) return false;
        if (Color == AbilityColor.Neutral) return false;
        if (b == AbilityColor.Neutral) return true;
        if (Color == AbilityColor.Blue && b == AbilityColor.Red) return true;
        if (Color == AbilityColor.Green && b == AbilityColor.Blue) return true;
        if (Color == AbilityColor.Red && b == AbilityColor.Green) return true;

        return false;
    }
    public virtual GladiatorController.AnimationState AttackState {
        get {                            
            return _State;
        }
        private set { }
    }
    public static AbilityColor GetRandomColorNotNeutral() {
        int r = Random.Range(0, 3);
        if (r == 0)
            return AbilityColor.Blue;
        if (r == 1)
            return AbilityColor.Green;
        return AbilityColor.Red;
    }
}
