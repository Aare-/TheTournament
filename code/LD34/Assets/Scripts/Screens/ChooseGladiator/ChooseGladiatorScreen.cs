using UnityEngine;
using System.Collections;

public class ChooseGladiatorScreen : MonoBehaviour {

    public MyGladiatorInfo myGladiatorInfo;
    public EnemyInfo enemyInfo;
    public GladiatorSlot[] gladiatorSlots;
    private int _currentIndex = 0;
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameController.Instance.player;
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
        _currentIndex = (_currentIndex + 1) % gladiatorSlots.Length;
        gladiatorSlots[_currentIndex].SelectGladiator();
    }

    private void SelectPreviousGladiator() {
        gladiatorSlots[_currentIndex].DeselectGladiator();
        _currentIndex = (_currentIndex + gladiatorSlots.Length - 1) % gladiatorSlots.Length;
        gladiatorSlots[_currentIndex].SelectGladiator();
    }

    //Not finished! Waiting for working GladiatorFactory
    private void UpdateMyGladiator(int index) {
        //Gladiator glad = player._Party[index];
        //myGladiatorInfo.health.text = glad.Life.ToString();
        //myGladiatorInfo.level.text = glad.Level.ToString();
        
        //TODO Move name generating to Gladiator Class (or Factory, maybe?)
        myGladiatorInfo.name.text = new NameGenerator().GenerateName();
        //myGladiatorInfo.avatar = null; 
    }

}
