using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GladiatorHolder : MonoBehaviour {

    public GameObject _LoadCharacterToThis;
    public Image _Shadow;
    public GameObject _Damage;

    public ProgressBarr Health;
    public ProgressBarr Adrenaline;
	
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
                Health.Percent = m.NewPercentValue;
            });
        TinyTokenManager.Instance.Register<Msg.GladiatorAdrenalineChanged>("GLADIATOR_HOLDER_" + GetInstanceID() + "ADRENALINE_CHANGED",
            (m) => {
                Adrenaline.Percent = m.NewPercentValue;
            });
    }
}
