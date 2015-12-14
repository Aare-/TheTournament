using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour
{
    public AudioSource[] audios;
    public AudioSource playingClip;
    public AudioSource nextClip;
    public float fadeStep = 0.1f;
    public float fadeDelayTime = 0.2f;
    private int _musicIndex = 0;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine("FadeInAudio", audios[0]);
        playingClip = audios[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (playingClip.time + 5 > playingClip.clip.length)
        {
            nextClip = GetNextClip();
            SmoothClipChange(playingClip, nextClip);
            playingClip = nextClip;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            nextClip = GetNextClip();
            SmoothClipChange(playingClip, nextClip);
            playingClip = nextClip;
        }
    }

    private AudioSource GetNextClip()
    {
        _musicIndex = (_musicIndex + 1)%audios.Length;
        return audios[_musicIndex];
    }

    private void SmoothClipChange(AudioSource clip1, AudioSource clip2)
    {
        StartCoroutine("FadeOutAudio", clip1);
        StartCoroutine("FadeInAudio", clip2);
    }

    private IEnumerator FadeInAudio(AudioSource audio)
    {
        audio.volume = 0;
        audio.Play();
        while (audio.volume < 1.0f)
        {
            audio.volume += fadeStep;
            yield return new WaitForSeconds(fadeDelayTime);
        }
    }

    private IEnumerator FadeOutAudio(AudioSource audio)
    {
        while (audio.volume > 0)
        {
            audio.volume -= fadeStep;
            yield return new WaitForSeconds(fadeDelayTime);
        }
        audio.Stop();
    }
}