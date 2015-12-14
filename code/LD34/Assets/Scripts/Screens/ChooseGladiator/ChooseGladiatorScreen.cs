using UnityEngine;
using System.Collections;
using TinyMessenger;
using UnityEngine.UI;

public class ChooseGladiatorScreen : MonoBehaviour {

    public Text NumberOfWins;
    public MyGladiatorInfo myGladiatorInfo;
    public EnemyInfo enemyInfo;
    public GladiatorSlot[] gladiatorSlots;
    private int _currentIndex = 0;    

	// Use this for initialization
	void Start () {        
        if (GameController.Instance.player == null)
            TinyMessengerHub.Instance.Publish<Msg.StartNewGame>(new Msg.StartNewGame());

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

        TinyTokenManager.Instance.Register<Msg.SelectPerformed>("CHOOSE_GLADIATOR_SCREEN_" + GetInstanceID() + "_SELECT_PERFORMED",
            (m) => {
                Debug.Log("Starting game!");
                TinyMessengerHub.Instance.Publish<Msg.StartFight>(new Msg.StartFight(GameController.Instance.player._Party[_currentIndex]._Id));
                TinyMessengerHub.Instance.Publish<Msg.StartFight>(new Msg.StartFight(GameController.Instance.player.Opponent._Id));
            });
	}
    void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.SelectPerformed>("CHOOSE_GLADIATOR_SCREEN_" + GetInstanceID() + "_SELECT_PERFORMED");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SelectNextGladiator();
            UpdateMyGladiator(_currentIndex);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SelectPreviousGladiator();
            UpdateMyGladiator(_currentIndex);
        }
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
