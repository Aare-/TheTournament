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
                new RangedAttack(1, "Slash", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 5, 
                    5, 10), 
                new RangedAttack(1, "Fast Slash", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 2, 
                    8, 10), 
                new RangedAttack(1, "Gun Shoot", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 5, 
                    7, 14), 
                new RangedAttack(1, "Fast Shoot", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 2, 
                    10, 14), 
                #endregion

                #region Green
                new RangedAttack(1, "Acid Shoot", AbilityColor.Green, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(1, "Melting Smash", AbilityColor.Green, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

                #region Red
                new RangedAttack(1, "Lava Shoot", AbilityColor.Red, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(1, "Fire Cut", AbilityColor.Red, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

                #region Blue
                new RangedAttack(1, "Electro Shoot", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(1, "Zapp", AbilityColor.Blue, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

            #endregion

            #region Level 1 Passive Abilities
            new AdrenalineRush(),
            new SuperVitality()
            #endregion
        
        },
        new Ability[] {
            #region Level 2 Active Abilities
                #region Neutral
                new RangedAttack(2, "Slash", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 5, 
                    5, 10), 
                new RangedAttack(2, "Fast Slash", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 2, 
                    8, 10), 
                new RangedAttack(2, "Gun Shoot", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 5, 
                    7, 14), 
                new RangedAttack(2, "Fast Shoot", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 2, 
                    10, 14), 
                #endregion

                #region Green
                new RangedAttack(2, "Acid Shoot", AbilityColor.Green, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(2, "Melting Smash", AbilityColor.Green, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

                #region Red
                new RangedAttack(2, "Lava Shoot", AbilityColor.Red, GladiatorController.AnimationState.Shoot, 10, 
                    50, 100), 
                new RangedAttack(2, "Fire Cut", AbilityColor.Red, GladiatorController.AnimationState.Meele, 5, 
                    50, 100), 
                #endregion

                #region Blue
                new RangedAttack(2, "Electro Shoot", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(2, "Zapp", AbilityColor.Blue, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

            #endregion

            #region Level 2 Passive Abilities
            new AdrenalineRush(),
            new SuperVitality()
            #endregion
        
        },
        new Ability[] {
            #region Level 3 Active Abilities
                #region Neutral
                new RangedAttack(3, "Slash", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 5, 
                    5, 10), 
                new RangedAttack(3, "Fast Slash", AbilityColor.Neutral, GladiatorController.AnimationState.Meele, 2, 
                    8, 10), 
                new RangedAttack(3, "Gun Shoot", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 5, 
                    7, 14), 
                new RangedAttack(3, "Fast Shoot", AbilityColor.Neutral, GladiatorController.AnimationState.Shoot, 2, 
                    10, 14), 
                #endregion

                #region Green
                new RangedAttack(3, "Acid Shoot", AbilityColor.Green, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(3, "Melting Smash", AbilityColor.Green, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

                #region Red
                new RangedAttack(3, "Lava Shoot", AbilityColor.Red, GladiatorController.AnimationState.Shoot, 10, 
                    50, 100), 
                new RangedAttack(3, "Fire Cut", AbilityColor.Red, GladiatorController.AnimationState.Meele, 5, 
                    50, 100), 
                #endregion

                #region Blue
                new RangedAttack(3, "Electro Shoot", AbilityColor.Blue, GladiatorController.AnimationState.Shoot, 10, 
                    4, 8), 
                new RangedAttack(3, "Zapp", AbilityColor.Blue, GladiatorController.AnimationState.Meele, 5, 
                    2, 4), 
                #endregion

            #endregion

            #region Level 3 Passive Abilities
            new AdrenalineRush(),
            new SuperVitality()
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
