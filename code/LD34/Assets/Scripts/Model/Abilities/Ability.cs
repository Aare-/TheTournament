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
        new Ability[] {new Charge(), new AdrenalineRush()},
        new Ability[] {},
        new Ability[] {}
    };

    public static Ability[] GetRandomAbilities(int count, int level, AbilityColor color) {
        level--;        
        if (level < 0 || level >= Abilities.Count())
            throw new System.ArgumentOutOfRangeException("Level is out of range");
        
        List<Ability> candidates = new List<Ability>(Abilities[level]).Where((a) => a.Color == color).ToList();
        if(candidates.Count() < count)
            throw new System.ArgumentOutOfRangeException("Not enough elements at this level");
        
        Ability[] result = new Ability[count];

        for (int i = 0; i < count; i++) {
            result[i] = candidates[Random.Range(0, candidates.Count())];
            candidates.Remove(result[i]);
        }

        return result;
    }

    #region Properties
    public virtual string Name
    {
        get { return "NoName Ability"; }
        set { }
    }

    public virtual string Info
    {
        get { return "No Info";  }
        set { }
    }

    public virtual AbilityColor Color {
        get { return AbilityColor.Neutral; }
        set { }
    }
    public virtual int Level {
        get { return 1; }
    }
    public bool IsSmirkingAgainst(Ability b) {
        if (Color == b.Color) return false;
        if (Color == AbilityColor.Neutral) return false;
        if (b.Color == AbilityColor.Neutral) return true;
        if (Color == AbilityColor.Blue && b.Color == AbilityColor.Red) return true;
        if (Color == AbilityColor.Green && b.Color == AbilityColor.Blue) return true;
        if (Color == AbilityColor.Red && b.Color == AbilityColor.Green) return true;

        return false;
    }
    #endregion

}
