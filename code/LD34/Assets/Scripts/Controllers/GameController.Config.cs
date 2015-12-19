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
    public int AdrenalineBoostPerNeutralAbility = 5;
    public int LevelUpAtAbilityC = 2;
    public int MaxAbilitiesPerGladiator = 6;
    public int MaxLevel = 4;
    public float SmirkBoost = 1.5f;
    public float ChanceOfColourSkill = 0.75f;
    public List<AbilityColorColorContainer> AbilitiesColors;

    [Header("Gladiator Parameters")]
    public float ChanceOfPassiveAbility = 0.4f;

    [Header("Gladiator Flavours")]
    public List<GladiatorFlavourContainer> _Prefab4GladiatorFlavour;

    [Header("Party Settings")]
    public int PartySlotsSize = 4;
    public int StartPartySize = 3;    
    [Header("Fight Mode")]
    public int TacticRerolls = 3;
    public int BaseAttackQueueLength = 6;

    [Serializable]
    public class GladiatorFlavourContainer {
        public GameObject Prefab;
        public Gladiator.GladiatorFlavour Flavour;
        public int Level;
    }

    [Serializable]
    public class AbilityColorColorContainer {
        public Ability.AbilityColor AbilityColor;
        public Color Color;
    }

    public GameObject GetPrefabForGladiator(Gladiator gladiator) {
        Gladiator.GladiatorFlavour flavour = gladiator.Flavour;
        int level = gladiator.Level;        

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
   
     public Color GetColorForAbilityColor(Ability.AbilityColor color) {
         foreach (AbilityColorColorContainer c in AbilitiesColors) {
             if (color == c.AbilityColor)
                 return c.Color;
         }

         return Color.white;
    }
}

