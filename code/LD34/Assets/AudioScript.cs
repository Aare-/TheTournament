using UnityEngine;
using System.Collections;
using System.Linq;

public class AudioScript : MonoBehaviour
{
    public AudioSource[] audiosFight;
    public AudioSource[] audiosMenu;
    public AudioSource[] audiosSuppressed;
    private AudioSource[] _actualPlaylist;
    private AudioSource _playingClip;
    private AudioSource _nextClip;

    [Header("Ustawienia")] public float fadeStep = 0.1f;
    public float fadeDelayTime = 0.2f;
    private int _musicIndex = 0;

    // Use this for initialization
    private void Start()
    {
        _actualPlaylist = audiosMenu;
        _playingClip = _actualPlaylist[0];
        StartCoroutine("FadeInAudio", _playingClip);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_playingClip.time + 5 > _playingClip.clip.length)
        {
            PlayNextClip();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayNextClip();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetFightPlaylist();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetMenuPlaylist();
        }
    }

    public void SetFightPlaylist()
    {
        SetPlaylist(audiosFight);
    }

    public void SetMenuPlaylist()
    {
        SetPlaylist(audiosMenu);
    }

    public void SetSuppresedPlaylist()
    {
        SetPlaylist(audiosSuppressed);
    }

    private void SetPlaylist(AudioSource[] playlist)
    {
        if (_actualPlaylist != playlist)
        {
            _musicIndex = 0;
            _actualPlaylist = playlist;
            PlayNextClip();
        }
    }

    public void PlayPlaylist()
    {
        PlayNextClip();
    }

    private void PlayNextClip()
    {
        _nextClip = GetNextClip();
        StopAllCoroutines();
        StartCoroutine(SmoothClipChange(_playingClip, _nextClip));
        _playingClip = _nextClip;
    }

    private AudioSource GetNextClip()
    {
        _musicIndex = (_musicIndex + 1)%_actualPlaylist.Length;
        return _actualPlaylist[_musicIndex];
    }

    //private void SmoothClipChange(AudioSource clip1, AudioSource clip2)
    //{
    //    if (clip1 != clip2)
    //    {
    //        StartCoroutine("FadeOutAudio", clip1);
    //        StartCoroutine("FadeInAudio", clip2);
    //    }
    //}

    public IEnumerator SmoothClipChange(AudioSource clip1, AudioSource clip2)
    {
        if (clip1 != clip2)
        {
            clip2.volume = 0;
            clip1.volume = 1;
            clip2.Play();
            while (clip1.volume > 0 && clip2.volume < 1)
            {
                clip1.volume -= fadeStep;
                clip2.volume += fadeStep;
                //Debug.Log(clip1.clip.name + " volume: " + clip1.volume);
                //Debug.Log(clip2.clip.name + " volume: " + clip2.volume);
                yield return new WaitForSeconds(fadeDelayTime);
            }
            clip1.Stop();
        }
    }

    private IEnumerator FadeInAudio(AudioSource audio)
    {
        audio.volume = 0;
        audio.Play();
        while (audio.volume < 1.0f)
        {
            audio.volume += fadeStep;
            //Debug.Log(audio.clip.name + " volume: " + audio.volume);
            yield return new WaitForSeconds(fadeDelayTime);
        }
    }

    private IEnumerator FadeOutAudio(AudioSource audio)
    {
        while (audio.volume > 0)
        {
            audio.volume -= fadeStep;
            //Debug.Log(audio.clip.name + " volume: " + audio.volume);
            yield return new WaitForSeconds(fadeDelayTime);
        }
        audio.Stop();
    }
}