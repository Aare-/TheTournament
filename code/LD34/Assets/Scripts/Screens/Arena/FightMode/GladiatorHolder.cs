using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class GladiatorHolder : MonoBehaviour {

    public GameObject _LoadCharacterToThis;
    public Image _Shadow;
    public GameObject _Damage;

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
                    Health.Percent = m.NewPercentValue;
                    Debug.Log("New Health Percent: " + m.NewPercentValue + " 4: " + _GladiatorId);
                }
            });
        TinyTokenManager.Instance.Register<Msg.GladiatorAdrenalineChanged>("GLADIATOR_HOLDER_" + GetInstanceID() + "ADRENALINE_CHANGED",
            (m) => {
                if (m.GladiatorId == _GladiatorId) {
                    Adrenaline.Percent = m.NewPercentValue;                    
                    Debug.Log("New Adrenaline Percent: " + m.NewPercentValue+" 4: "+_GladiatorId);
                }
                
            });
        TinyTokenManager.Instance.Register<Msg.NotEnughAdrenaline>("GLADIATOR_HOLDER_" + GetInstanceID() + "NOT_ENOUGH_ADRENALINE",
            (m) => {
                if (m.GladiatorId == _GladiatorId) {
                    _Damage.gameObject.SetActive(true);
                    Text t = _Damage.GetComponent<Text>();
                    t.text = "NOT ENOUGH ADRENALINE!";

                    t.color = new Color(1.0f, 1.0f, 0.4f, 1.0f);

                    StartCoroutine(FadeOut(t));
                }

            });
        TinyTokenManager.Instance.Register<Msg.DealDamage>("GLADIATOR_HOLDER_" + GetInstanceID() + "DAMAGE_RECEIVED",
            (m) => {
                if (m.GladiatorID == _GladiatorId) {
                    _Damage.gameObject.SetActive(true);
                    Text t = _Damage.GetComponent<Text>();
                    t.text = "-" + m.Damage;

                    t.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                    StartCoroutine(FadeOut(t));
                }

            });
    }

    IEnumerator FadeOut(Text t) {
        float timeLeft = 0.5f;

        while (timeLeft > 0) {
            yield return new WaitForEndOfFrame();
            timeLeft -= Time.deltaTime;

            float percent = Mathf.Clamp01(timeLeft / 0.5f);
            t.color = new Color(t.color.r, t.color.g, t.color.b, percent);
        }
    }
}
