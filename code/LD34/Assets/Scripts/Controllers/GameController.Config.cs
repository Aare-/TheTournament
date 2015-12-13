using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class GameController : Singleton<GameController> {
    [Header("Gladiator Settings")]
    public float StartingLife;
    public float LifeBoostPerLevel;
    public float StartingAdrenaline;
}

