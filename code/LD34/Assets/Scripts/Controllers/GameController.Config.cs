﻿using System;
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
    [Header("Fight Mode")]
    public int BaseAttackQueueLength;
}
