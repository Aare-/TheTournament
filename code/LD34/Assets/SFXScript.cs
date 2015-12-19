using System;
using UnityEngine;

/// <summary>
/// So, this class describe when and what sound will be played.
/// The problem is that one audiosource can afford one clip at one time, 
/// so if you want to play multiple sound in the same time, 
/// you have to play it from multiple/different audio sources.
/// 
/// My proposition:
/// [sourceID] - [description]
/// 0 - generally sounds like clicks etc
/// 1 - sounds for glad one
/// 2 - sounds for glad two
/// 3 - sound which must be played along with sound from source 1 or 2 or even 0 ;)
/// </summary>
public class SFXScript : MonoBehaviour
{
    private AudioSource[] audioSources;

    [Header("Audio Clips")] 
    public AudioClip click;
    public AudioClip sword;
    public AudioClip gun;
    public AudioClip hit;
    public AudioClip kill;
    public AudioClip aplause;
    public AudioClip oww;
    public AudioClip notEnughAdrenaline;
    public AudioClip upgrade;
    public AudioClip clampSmash;

    // Use this for initialization
    private void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();

        TinyTokenManager.Instance.Register<Msg.ArrowClicked>("SFX: ARROW CLICL SOUND", 
            (m) => { PlayClip(click); });

        TinyTokenManager.Instance.Register<Msg.GladiatorDefeated>("SFX: APLAUSE SOUND",
            (m) => { PlayClip(aplause); });

        TinyTokenManager.Instance.Register<Msg.AbilitySmirked>("SFX: ABILITY SMIRKED SOUND",
            (m) => { PlayClip(oww); });

        TinyTokenManager.Instance.Register<Msg.NotEnughAdrenaline>("SFX: NOT ENOUGHT ADRENALINE SOUND",
            (m) => { PlayClip(notEnughAdrenaline); });

        TinyTokenManager.Instance.Register<Msg.SetGladiatorState>("SFX ATTACK SOUND", (m) =>
        {
            if (m.NewState == GladiatorController.AnimationState.Meele)
            {
                PlayClip(sword, 1);
                //PlayClipDelayed(hit, sword.length, 3);
            }
            else if (m.NewState == GladiatorController.AnimationState.Shoot)
            {
                PlayClip(gun, 2);
                //PlayClipDelayed(hit, gun.length, 3);
            }
            else if (m.NewState == GladiatorController.AnimationState.Upgrade)
            {
                PlayClip(upgrade);
            }
        });

        TinyTokenManager.Instance.Register<Msg.DealDamage>("SFX: PERFORM ACTIVE ATTACK",
            (m) => { PlayClip(hit, 3); });
    }

    public void PlayClip(AudioClip clip, int sourceID = 0)
    {
        if (clip != null && sourceID < audioSources.Length)
        {
            audioSources[sourceID].clip = clip;
            audioSources[sourceID].Play();
        }
        else
        {
            throw new NullReferenceException("Clip/AudioSource not found");
        }
    }

    public void PlayClipDelayed(AudioClip clip, float delayTime, int sourceID = 0)
    {
        if (clip != null && sourceID < audioSources.Length)
        {
            audioSources[sourceID].clip = clip;
            audioSources[sourceID].PlayDelayed(delayTime);
        }
        else
        {
            throw new NullReferenceException("Clip/AudioSource not found");
        }
    }
}