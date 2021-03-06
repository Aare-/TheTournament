﻿using UnityEngine;
using System.Collections;
using TinyMessenger;
using UnityEngine.UI;

public class ChooseGladiatorScreen : Fadeable {
    [Header("Game Object bindings")]
    public Text NumberOfWins;
    public MyGladiatorInfo myGladiatorInfo;
    public EnemyInfo enemyInfo;
    public GladiatorSlot[] gladiatorSlots;
    private int _currentIndex = 0;    

	// Use this for initialization
	void Start () {                

        TinyMessengerHub.Instance.Publish<Msg.GenerateNewOpponent>(new Msg.GenerateNewOpponent());

        #region Filling Slots with gladiator details
        for (int i = 0; i < gladiatorSlots.Length; i++)
            gladiatorSlots[i].FillWithGladiatorDetails(null);
        for (int i = 0; i < GameController.Instance.player.GetPartyLength(); i++)
            gladiatorSlots[i].FillWithGladiatorDetails(GameController.Instance.player._Party[i]);
        #endregion

        UpdateMyGladiator(0);
        enemyInfo.SetGladiatorInfo(GameController.Instance.player.Opponent);

        NumberOfWins.text = "Fights won: " + GameController.Instance.player.NumberOfVictories;

        TinyTokenManager.Instance.Register<Msg.LeftPressed>("CHOOSE_GLADIATOR_SCREEN_" + GetInstanceID() + "_LEFT_PRESSED",
            (m) => {                
                SelectPreviousGladiator();
                UpdateMyGladiator(_currentIndex);
            });
        TinyTokenManager.Instance.Register<Msg.RightPressed>("CHOOSE_GLADIATOR_SCREEN_" + GetInstanceID() + "_RIGHT_PRESSED",
            (m) => {                
                SelectNextGladiator();
                UpdateMyGladiator(_currentIndex);
            });
        TinyTokenManager.Instance.Register<Msg.SelectPerformed>("CHOOSE_GLADIATOR_SCREEN_" + GetInstanceID() + "_SELECT_PERFORMED",
            (m) => {
                Unsubscribe();
                StartCoroutine(StartGameCoroutine());
                
            });

        StartFadeOut();
	}
    void OnDestroy() {
        Unsubscribe();
    }
    void Unsubscribe() {        
        TinyTokenManager.Instance.Unregister<Msg.SelectPerformed>("CHOOSE_GLADIATOR_SCREEN_" + GetInstanceID() + "_SELECT_PERFORMED");
    }
    IEnumerator StartGameCoroutine() {
        StartFadeIn();
        yield return new WaitForSeconds(0.6f);

        GameController.Instance.EnableTrigger("gladiatorChoosen");
        TinyMessengerHub.Instance.Publish<Msg.StartFight>(new Msg.StartFight(GameController.Instance.player._Party[_currentIndex]._Id));
        TinyMessengerHub.Instance.Publish<Msg.StartFight>(new Msg.StartFight(GameController.Instance.player.Opponent._Id));
    }


    private void SelectNextGladiator() {
        gladiatorSlots[_currentIndex].DeselectGladiator();
        _currentIndex = (_currentIndex + 1) % GameController.Instance.player.GetPartyLength();
        gladiatorSlots[_currentIndex].SelectGladiator();

        //GameController.Instance.player.FightingGladiator = GameController.Instance.player._Party[_currentIndex];
    }

    private void SelectPreviousGladiator() {
        gladiatorSlots[_currentIndex].DeselectGladiator();
        _currentIndex = (_currentIndex + GameController.Instance.player.GetPartyLength() - 1) % GameController.Instance.player.GetPartyLength();
        gladiatorSlots[_currentIndex].SelectGladiator();

        //GameController.Instance.player.FightingGladiator = GameController.Instance.player._Party[_currentIndex];
    }

    //Not finished! Waiting for working GladiatorFactory
    private void UpdateMyGladiator(int index) {
        myGladiatorInfo.FillWithGladiatorDetails(GameController.Instance.player._Party[index]);        
    }

}
