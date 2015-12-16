using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyMessenger;
using System.Collections.Generic;

public class FateOfTheLooser : Fadeable {

    [Header("Prefab bindings")]
    public ActionDetails ActionDetailsPrefab;

    [Header("Object bindings")]
    public GameObject LooserContainer;
    public GameObject HandsContainer;
    public Text FreeSlot;
    public Text SkillsListLabel;
    public Text YouWon;

    public Image CrusherLeft;
    public Image CrusherRight;
    public GridLayoutGroup LooserSkillsList;
    List<Ability> _LooserList;

    private int _SelectedAbility = 0;
    bool abilityLimitReached = false;

    void Awake() {        
    }
	void Start () {
        if (GameController.Instance.player == null) return;

        GameController.Instance.player.NumberOfVictories++;

        #region Creating Gladiator
        Gladiator g = GameController.Instance.player.Opponent;
        GladiatorController c = Instantiate(GameController.Instance.GetPrefabForGladiator(g)).GetComponent<GladiatorController>();
        c.gameObject.transform.position = new Vector3(0, 40, 0);
        c.Id = g._Id;
        if (g._Id == GameController.Instance.player.Opponent._Id) {
            c.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        c.transform.SetParent(LooserContainer.transform, false);
        c.SwitchState(GladiatorController.AnimationState.Kneeling);
        #endregion

        FreeSlot.text = "";
        if (GameController.Instance.player.CanAddToParty()) {
            FreeSlot.gameObject.SetActive(false);
        } else {
            FreeSlot.gameObject.SetActive(true);
            FreeSlot.text = "You don't have free slots in your party to fit new gladiator";
        }
        abilityLimitReached = false;
        if(GameController.Instance.player.FightingGladiator.PassiveAbilities.Count + GameController.Instance.player.FightingGladiator.ActiveAbilities.Count >=
            GameController.Instance.MaxAbilitiesPerGladiator) {
                FreeSlot.gameObject.SetActive(true);
                abilityLimitReached = true;
                FreeSlot.text += "\nAbility limit reached: " + GameController.Instance.MaxAbilitiesPerGladiator;
        }

        _SelectedAbility = 0;

        #region Loading Opponent skill list
        _LooserList = new List<Ability>();
        foreach (PassiveAbility p in GameController.Instance.player.Opponent.PassiveAbilities) {
            _LooserList.Add(p);
        }
        foreach (ActiveAbility a in GameController.Instance.player.Opponent.ActiveAbilities) {
            _LooserList.Add(a);
        }
        //removing passive abilities that player already posses
        foreach (PassiveAbility p in GameController.Instance.player.FightingGladiator.PassiveAbilities) {
            if(_LooserList.Contains(p))
                _LooserList.Remove(p);
        }

        foreach (Ability p in _LooserList) {            
            ActionDetails action = Instantiate(ActionDetailsPrefab);
            action.transform.SetParent(LooserSkillsList.transform, false);
            action.SetAbility(p);
        }
        #endregion

        TinyTokenManager.Instance.Register<Msg.LeftPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "LEFT",
            (m) => {
                Unregister();
                HandsContainer.gameObject.SetActive(false);
                StartCoroutine(FateSpare());

                if (GameController.Instance.player.CanAddToParty()) {                    
                    GameController.Instance.player.AddToParty(GameController.Instance.player.Opponent);
                }
            });
        TinyTokenManager.Instance.Register<Msg.RightPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "RIGHT",
            (m) => {
                Unregister();
                HandsContainer.gameObject.SetActive(false);                
                StartCoroutine(FateKill());
            });

        TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(true));
	}
    void Unregister() {
        TinyTokenManager.Instance.Unregister<Msg.LeftPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "LEFT");
        TinyTokenManager.Instance.Unregister<Msg.RightPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "RIGHT");
        TinyTokenManager.Instance.Unregister<Msg.SelectPerformed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "SELECTED");        
    }
    void Crush() {        
        iTween.MoveBy(CrusherRight.gameObject, new Vector3(-2.82f, 0), 0.5f);
        iTween.MoveBy(CrusherLeft.gameObject, new Vector3(2.82f, 0), 0.5f);        
    }
    IEnumerator FateSpare() {
        FreeSlot.gameObject.SetActive(true);
        FreeSlot.text = GameController.Instance.player.Opponent.Name + " joined your party";
        
        yield return new WaitForSeconds(1.0f);
        StartFadeIn();

        yield return new WaitForSeconds(0.5f);
        GameController.Instance.EnableTrigger(GameController.TRIGGER_FATE_SPARE);
    }
    IEnumerator FateKill() {
        Crush();
        yield return new WaitForSeconds(0.45f);
        Destroy(LooserContainer);
        yield return new WaitForSeconds(0.5f);

        if (abilityLimitReached) {
            StartCoroutine(KillSkillSelected());


        } else {
            TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(false));

            SkillsListLabel.text = "";
            YouWon.text = "Select skill to learn";

            _SelectedAbility = 0;
            SelectAbilityOnTheList(_SelectedAbility);

            TinyTokenManager.Instance.Register<Msg.LeftPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "LEFT",
               (m) => {
                   Debug.Log("Selecting skill left");
                   _SelectedAbility--;
                   if (_SelectedAbility < 0) _SelectedAbility = LooserSkillsList.transform.childCount - 1;

                   SelectAbilityOnTheList(_SelectedAbility);
               });
            TinyTokenManager.Instance.Register<Msg.RightPressed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "RIGHT",
                (m) => {
                    _SelectedAbility++;
                    if (_SelectedAbility >= LooserSkillsList.transform.childCount) _SelectedAbility = 0;

                    SelectAbilityOnTheList(_SelectedAbility);
                });
            TinyTokenManager.Instance.Register<Msg.SelectPerformed>("FATE_OF_THE_LOOSER" + GetInstanceID() + "SELECTED",
                (m) => {
                    Unregister();

                    GameController.Instance.player.FightingGladiator.LearnNewAbility(_LooserList[_SelectedAbility]);

                    if (GameController.Instance.player.FightingGladiator.LastLevelUpedAbility != null) {
                        GameController.Instance.EnableTrigger("upgrade");
                    } else {
                        StartCoroutine(KillSkillSelected());
                    }
                });
        }
    }
    void SelectAbilityOnTheList(int ability) {
        for (int i = 0; i < LooserSkillsList.transform.childCount; i++)
            LooserSkillsList.transform.GetChild(i).localScale = Vector3.one;        
        LooserSkillsList.transform.GetChild(ability).localScale = Vector3.one * 1.20f;
    }

    IEnumerator KillSkillSelected() {
        StartFadeIn();                

        yield return new WaitForSeconds(0.5f);
        GameController.Instance.EnableTrigger(GameController.TRIGGER_FATE_SPARE);
    }
    void OnDestroy() {
        Unregister();
        TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(false));
    }	
}
