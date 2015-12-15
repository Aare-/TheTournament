using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    }
}
