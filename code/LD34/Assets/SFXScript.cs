using UnityEngine;
using System.Collections;

public class SFXScript : MonoBehaviour
{
    public AudioSource main;
    public AudioSource glad1;
    public AudioSource glad2;

    [Header("Clips")] public AudioClip click;
    public AudioClip sword;
    public AudioClip gun;
    public AudioClip hit;
    public AudioClip kill;
    public AudioClip aplause;
    public AudioClip oww;
    public AudioClip notEnughAdrenaline;
    public AudioClip upgradeSound;

    // Use this for initialization
    private void Start()
    {
        main = GetComponent<AudioSource>();

        TinyTokenManager.Instance.Register<Msg.GladiatorDefeated>("SFX: APLAUSE SOUND",
            (m) => { PlayClip(aplause); });

        TinyTokenManager.Instance.Register<Msg.AbilitySmirked>("SFX: ABILITY SMIRKED SOUND",
            (m) => { PlayClip(oww); });

        TinyTokenManager.Instance.Register<Msg.NotEnughAdrenaline>("SFX: NOT ENOUGHT ADRENALINE SOUND",
            (m) => { PlayClip(notEnughAdrenaline); });

        TinyTokenManager.Instance.Register<Msg.SetGladiatorState>("SFX" + GetInstanceID() + "ATTACK SOUND", (m) =>
        {
            if (m.NewState == GladiatorController.AnimationState.Meele)
            {
                PlayClip(sword, 1);
            }
            else if (m.NewState == GladiatorController.AnimationState.Shoot)
            {
                PlayClip(gun, 2);
            }
            else if (m.NewState == GladiatorController.AnimationState.Upgrade)
            {
                PlayClip(upgradeSound);
            }
        });

        //TinyTokenManager.Instance.Register<Msg.DealDamage>("SFX: PERFORM ACTIVE ATTACK",
        //    (m) => { PlayClip(hit, 1); });
    }

    public void PlayClip(AudioClip clip, int sourceID = 0)
    {
        if (clip != null)
        {
            if (sourceID == 1)
            {
                glad1.clip = clip;
                glad1.Play();
            }
            else if (sourceID == 2)
            {
                glad2.clip = clip;
                glad2.Play();
            }
            else
            {
                main.clip = clip;
                main.Play();
            }
        }
    }
}