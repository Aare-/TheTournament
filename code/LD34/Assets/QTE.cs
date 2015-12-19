using UnityEngine;
using System.Collections;

/// <summary>
/// All action in console like old days xD
/// 
/// Please, press:
/// 
/// L - for start QTE
/// K - just fuck this button until you win or lose ('tu jest buton, tu sie napierdala' - Dem3000)
/// R - reset QTE
/// </summary>
public class QTE : MonoBehaviour
{
    [Header("Settings")]
    public int max = 100;
    public int min = 0;
    public int startValue = 50;
    public int minusPerTick = -10;
    public int plusPerClick = 10;
    public float tickTime = 0.2f;
    
    private bool _isQTEActive = false;
    private bool _startQTE = false;
    private int _actualValue;

	// Use this for initialization
	void Start ()
	{
	    _actualValue = startValue;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K) && _isQTEActive)
        {
            _actualValue += plusPerClick;
            Debug.Log("Increasing! Actual value: " + _actualValue);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _startQTE = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (_startQTE)
	    {
	        _startQTE = false;
	        _isQTEActive = true;
	        StartCoroutine(FightWithPlayer());
	    }
	    if (_isQTEActive)
	    {
	        CheckQTEFight();
	    }
	}

    private void CheckQTEFight()
    {
        if (_actualValue <= min)
        {
            Debug.Log("You False, Faggot!");
            Reset();
        }
        else if (_actualValue >= max)
        {
            Debug.Log("You Win, Fagg... Master!");
            Reset();
        }
    }

    private IEnumerator FightWithPlayer()
    {
        Debug.Log("Fight Started!");
        while (_isQTEActive && _actualValue > min)
        {
            _actualValue += minusPerTick;
            Debug.Log("Decreasing! Actual value: " + _actualValue);
            yield return new WaitForSeconds(tickTime);
        }
    }

    public void Reset()
    {
        StopCoroutine(FightWithPlayer());
        _actualValue = startValue;
        _isQTEActive = false;
        _startQTE = false;
    }

    public void StartQTE()
    {
        _startQTE = true;
    }

}
