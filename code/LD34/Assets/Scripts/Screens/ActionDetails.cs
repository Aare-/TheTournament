using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ActionDetails : MonoBehaviour {
    public Image Icon;
    public Text Description;

    public Sprite Active;
    public Sprite Passive;

    public void Awake() {

    }
    public void OnDestroy() {

    }

    public void SetAbility(Ability ability) {
        if ((ability is ActiveAbility))
            Icon.sprite = Active;
        else
            Icon.sprite = Passive;
        Icon.color = GameController.Instance.GetColorForAbilityColor(ability.Color);
        Description.text = ability.Name+" (LVL: "+ability.Level+")";
    }
}

