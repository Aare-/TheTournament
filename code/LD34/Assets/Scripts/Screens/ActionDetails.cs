using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ActionDetails : MonoBehaviour {
    public Image Icon;
    public Text Description;

    public void Awake() {

    }
    public void OnDestroy() {

    }

    public void SetAbility(Ability ability) {
        Icon.color = GameController.Instance.GetColorForAbilityColor(ability.Color);
        Description.text = ability.Name;
    }
}

