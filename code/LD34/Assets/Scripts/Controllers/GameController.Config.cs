using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public partial class GameController : Singleton<GameController> {
    [Header("Gladiator Settings")]
    public float StartingLife = 100;
    public float LifeBoostPerLevel = 20;
    public float StartingAdrenaline = 50;
    public float AdrenalineBoostPerLevel = 10;
    public float AdrenalineBoostPerNeutralAbility = 5;
    [Header("Party Settings")]
    public int PartySlotsSize = 4;
    public int PartySize = 4;
    [Header("Fight Mode")]
    public int BaseAttackQueueLength;
}

