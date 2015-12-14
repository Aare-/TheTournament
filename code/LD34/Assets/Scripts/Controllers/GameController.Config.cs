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

    [Header("Gladiator Flavours")]
    public List<GladiatorFlavourContainer> _Prefab4GladiatorFlavour;

    [Header("Party Settings")]
    public int PartySlotsSize = 4;
    public int PartySize = 4;    
    [Header("Fight Mode")]
    public int TacticRerolls = 3;
    public int BaseAttackQueueLength;

    [Serializable]
    public class GladiatorFlavourContainer {
        public GameObject Prefab;
        public Gladiator.GladiatorFlavour Flavour;
        public int Level;
    }

    public GameObject GetPrefabForGladiatorFlavour(Gladiator.GladiatorFlavour flavour, int level) {
        foreach (var p in _Prefab4GladiatorFlavour)
            if (p.Flavour == flavour) {
                if (p.Level == -1)
                    return p.Prefab;
                else if (p.Level == level) {
                    return p.Prefab;
                }
            }        

        return null;
    }
}

