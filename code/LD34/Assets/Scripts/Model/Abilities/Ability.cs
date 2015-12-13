using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Ability {
    public enum AbilityColor {
        Neutral,
        Blue,
        Red,
        Green
    }    

    #region Properties
    public virtual AbilityColor Color {
        get { return AbilityColor.Neutral; }
    }
    public virtual int Level {
        get { return 1; }
    }
    #endregion

    #region Util functions
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
