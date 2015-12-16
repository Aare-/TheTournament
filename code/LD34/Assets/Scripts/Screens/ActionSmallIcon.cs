using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ActionSmallIcon : MonoBehaviour {
    public Image image;

    public Sprite Active;
    public Sprite Passive;

    public void Awake() {

    }

    public void SetAbility(Ability ability) {
        if ((ability is ActiveAbility))
            image.sprite = Active;
        else
            image.sprite = Passive;
        image.color = GameController.Instance.GetColorForAbilityColor(ability.Color);

    }

}

