using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ActionSmallIcon : MonoBehaviour {
    public Image image;

    public void Awake() {

    }

    public void SetAbility(Ability ability) {
        image.color = GameController.Instance.GetColorForAbilityColor(ability.Color);

        if ((ability is ActiveAbility)) {

        } else {

        }
    }

}

