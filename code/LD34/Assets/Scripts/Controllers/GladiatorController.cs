using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using TinyMessenger;
using UnityEngine;
using UnityEngine.UI;

public class GladiatorController : MonoBehaviour {
    /**
     * I'm implementing this animation state machine here from scratch 'cause we need custom implementation of the state machine for our IT class on software design patterns.
     */
    public enum AnimationState {
        Idle,
        Meele,
        Shoot,
        Upgrade,
        Kneeling,
        PerformUpgrade
    }

    #region Properties
    [Header("Animations")]
    [SerializeField]
    private string _PathToAtlas;
    [SerializeField]
    private string _AtlasName;  
    [SerializeField]
    List<AnimationSequenceHolder> _AnimationSequences;
    #endregion

    AnimationState _CurrentState = AnimationState.Idle;
    AnimationState _NextState = AnimationState.Idle;

    int _Id = -1;
    int currentFrame;
    float frameTime;
    Image _SpriteImage;

    #region Properties
    public int Id {
        get { return _Id; }
        set { _Id = value; }
    }
    #endregion

    public void Awake() {
        foreach (AnimationSequenceHolder h in _AnimationSequences) {
            h.Sequence.AtlasName = _AtlasName;
            h.Sequence.PathToAtlas = _PathToAtlas;
        }

        _SpriteImage = GetComponent<Image>();
        SwitchState(AnimationState.Idle);
    }
    public void Start() {        
        TinyTokenManager.Instance.Register<Msg.PerformActiveAbility>(            
            "GLADIATOR_CONTROLLER_"+GetInstanceID() + "PERFORM_ACTIVE",
            (m) => {                
                if (_Id != -1 && _Id == m.ExecutingGladiatorId) {
                    TinyMessengerHub.Instance.Publish<Msg.SetGladiatorState> (
                        new Msg.SetGladiatorState(
                            m.ExecutingGladiatorId, 
                            m.Ability.AttackState));
                }                    
            });
        TinyTokenManager.Instance.Register<Msg.SetGladiatorState>(
            "GLADIATOR_CONTROLLER_" + GetInstanceID() + "_SET_GLADIATOR_STATE",
            (m) => {
                if (_Id != -1 && _Id == m.GladiatorId) {                    
                    SwitchState(m.NewState);
                }
            });
    }
    public void OnDestroy() {
        TinyTokenManager.Instance.Unregister<Msg.SetGladiatorState>("GLADIATOR_CONTROLLER_" + GetInstanceID() + "_SET_GLADIATOR_STATE");
        TinyTokenManager.Instance.Unregister<Msg.PerformActiveAbility>("GLADIATOR_CONTROLLER_" + GetInstanceID() + "PERFORM_ACTIVE");
    }
    
    public void Update() {
        List<AnimationFrame> list = null;

        foreach (AnimationSequenceHolder h in _AnimationSequences)
            if (h.State == _CurrentState)
                list = h.Sequence.Frames;                    

        if (list != null && list.Count() > 0) {
            frameTime += Time.deltaTime;
            while (frameTime > list[currentFrame].FrameTime) {
                frameTime -= list[currentFrame].FrameTime;
                currentFrame++;

                if (currentFrame >= list.Count()) {
                    float lastFrameTime = frameTime;
                    SwitchState(_NextState);
                    frameTime = lastFrameTime;
                }                
            }

            _SpriteImage.sprite = list[currentFrame].Frame;
        }        
    }

    public void SwitchState(AnimationState nextState) {
        currentFrame = 0;
        frameTime = 0.0f;

        _CurrentState = nextState;
        switch (_CurrentState) {
            case AnimationState.Idle: _NextState = AnimationState.Idle; break;
            case AnimationState.Kneeling: _NextState = AnimationState.Kneeling; break;
            case AnimationState.Meele: _NextState = AnimationState.Idle; break;
            case AnimationState.Shoot: _NextState = AnimationState.Idle; break;
            case AnimationState.Upgrade: _NextState = AnimationState.PerformUpgrade; break;
            case AnimationState.PerformUpgrade:
                TinyMessengerHub.Instance.Publish<Msg.UpgradeFinished>(new Msg.UpgradeFinished());
                break;
        }
    }

    [Serializable]
    public class AnimationSequenceHolder {
        public AnimationState State;
        public AnimationSequence Sequence;        
    }
}
