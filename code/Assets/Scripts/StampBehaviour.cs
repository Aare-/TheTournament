using UnityEngine;
using System.Collections;

public class StampBehaviour : MonoBehaviour {

    public GameObject stampImage;

    void Start()
    {
        stampImage.SetActive(false);
    }

    public void ShowStamp()
    {
        stampImage.SetActive(true);
    }
}
