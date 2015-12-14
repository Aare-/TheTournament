using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GladiatorHolder : MonoBehaviour {

    public GameObject _LoadCharacterToThis;
    public Image _Shadow;
    public GameObject _Damage;    

	
	void Start () {
	        
	}
	void Update () {
	
	}
    void OnDestroy() {

    }

    public void LoadGladiator(Gladiator g) {        
        #region Loading Passive abilities list

        GladiatorController c = Instantiate(GameController.Instance.GetPrefabForGladiator(g)).GetComponent <GladiatorController>();
        c.gameObject.transform.position = new Vector3(0, 40, 0);
        if (g._Id == GameController.Instance.player.Opponent._Id) {
            c.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        c.transform.SetParent(_LoadCharacterToThis.transform, false);
        
        #endregion
    }
}
