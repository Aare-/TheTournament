using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class GladiatorHolder : MonoBehaviour {

    public GameObject _LoadCharacterToThis;
    public Image _Shadow;
    public GameObject _Damage;
    public GameObject _Adrenaline;
    public GameObject _Smirk;

    public ProgressBarr Health;
    public ProgressBarr Adrenaline;
    int _GladiatorId;
	
	void Start () {
	            
	}
	void Update () {
	
	}
    void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.GladiatorHealthChanged>("GLADIATOR_HOLDER_" + GetInstanceID() + "HEALTH_CHANGED");
        TinyTokenManager.Instance.Unregister<Msg.GladiatorAdrenalineChanged>("GLADIATOR_HOLDER_" + GetInstanceID() + "ADRENALINE_CHANGED");
        TinyTokenManager.Instance.Unregister<Msg.DealDamage>("GLADIATOR_HOLDER_" + GetInstanceID() + "DAMAGE_RECEIVED");
        TinyTokenManager.Instance.Unregister<Msg.NotEnughAdrenaline>("GLADIATOR_HOLDER_" + GetInstanceID() + "NOT_ENOUGH_ADRENALINE");
        TinyTokenManager.Instance.Unregister<Msg.AbilitySmirked>("GLADIATOR_HOLDER_" + GetInstanceID() + "SMIRKED");                     
        TinyTokenManager.Instance.Unregister<Msg.PrepareToPerformAttack>("GLADIATOR_HOLDER_" + GetInstanceID() + "PREPARE_TO_ATTACK");
        TinyTokenManager.Instance.Unregister<Msg.StartFightRound>("GLADIATOR_HOLDER_" + GetInstanceID() + "START_FIGHT_ROUND");        
    }

    public void LoadGladiator(Gladiator g) {        
        #region Loading Passive abilities list

        _GladiatorId = g._Id;
        GladiatorController c = Instantiate(GameController.Instance.GetPrefabForGladiator(g)).GetComponent <GladiatorController>();
        c.gameObject.transform.position = new Vector3(0, 40, 0);
        c.Id = g._Id;
        if (g._Id == GameController.Instance.player.Opponent._Id) {
            c.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        c.transform.SetParent(_LoadCharacterToThis.transform, false);
        
        #endregion

        TinyTokenManager.Instance.Register<Msg.GladiatorHealthChanged>("GLADIATOR_HOLDER_" + GetInstanceID() + "HEALTH_CHANGED",
            (m) => {
                if (m.GladiatorId == _GladiatorId) {
                    Health.Value = m.NewValue;                    
                }
            });
        TinyTokenManager.Instance.Register<Msg.GladiatorAdrenalineChanged>("GLADIATOR_HOLDER_" + GetInstanceID() + "ADRENALINE_CHANGED",
            (m) => {
                if (m.GladiatorId == _GladiatorId) {
                    Adrenaline.Value = m.NewValue;                                        
                }
                
            });
        TinyTokenManager.Instance.Register<Msg.NotEnughAdrenaline>("GLADIATOR_HOLDER_" + GetInstanceID() + "NOT_ENOUGH_ADRENALINE",
            (m) => {
                if (m.GladiatorId == _GladiatorId) {
                    _Adrenaline.gameObject.SetActive(true);
                    Text t = _Adrenaline.GetComponent<Text>();
                    t.text = "NOT ENOUGH ADRENALINE!";

                    t.color = new Color(1.0f, 1.0f, 0.4f, 1.0f);

                }

            });
        TinyTokenManager.Instance.Register<Msg.DealDamage>("GLADIATOR_HOLDER_" + GetInstanceID() + "DAMAGE_RECEIVED",
            (m) => {
                if (m.GladiatorID == _GladiatorId) {
                    _Damage.gameObject.SetActive(true);
                    Text t = _Damage.GetComponent<Text>();
                    t.text = "-" + m.Damage;

                    t.color = GameController.Instance.GetColorForAbilityColor(
                        _GladiatorId == GameController.Instance.player.FightingGladiator._Id ?
                            GameController.Instance.player.Opponent.LastActiveColor :
                            GameController.Instance.player.FightingGladiator.LastActiveColor
                        );

                }

            });
        TinyTokenManager.Instance.Register<Msg.AbilitySmirked>("GLADIATOR_HOLDER_" + GetInstanceID() + "SMIRKED",
            (m) => {
                if (m.SmirkGladiatorTargetId  == _GladiatorId) {
                    _Smirk.gameObject.SetActive(true);
                    Text t = _Smirk.GetComponent<Text>();

                    t.color = GameController.Instance.GetColorForAbilityColor(
                        _GladiatorId == GameController.Instance.player.FightingGladiator._Id ?
                            GameController.Instance.player.FightingGladiator.LastActiveColor :
                            GameController.Instance.player.Opponent.LastActiveColor
                        );

                }

            });
        TinyTokenManager.Instance.Register<Msg.PrepareToPerformAttack>("GLADIATOR_HOLDER_" + GetInstanceID() + "PREPARE_TO_ATTACK",
            (m) => {
                _Smirk.gameObject.SetActive(false);
                _Damage.gameObject.SetActive(false);
                _Adrenaline.gameObject.SetActive(false);
            });
        TinyTokenManager.Instance.Register<Msg.StartFightRound>("GLADIATOR_HOLDER_" + GetInstanceID() + "START_FIGHT_ROUND",
            (m) => {
                _Smirk.gameObject.SetActive(false);
                _Damage.gameObject.SetActive(false);
                _Adrenaline.gameObject.SetActive(false);
            });
        
    }
}
