using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Msg {
    public class StartNewGame : TinyMessenger.ITinyMessage {        

        #region Implementation
        public StartNewGame() {            
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class GameOver : TinyMessenger.ITinyMessage {

        #region Implementation
        public GameOver() {
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class GenerateNewOpponent : TinyMessenger.ITinyMessage {

        #region Implementation
        public GenerateNewOpponent() {
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    /* 
     * This event is called twice, once for each gladiator
     */
    public class StartFight : TinyMessenger.ITinyMessage {

        public int GladiatorId;

        #region Implementation
        public StartFight(int gladiatorId) {
            GladiatorId = gladiatorId;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    /* 
     * This event is called twice, once for each gladiator
     */
    public class StartFightRound : TinyMessenger.ITinyMessage {

        public int GladiatorId;

        #region Implementation
        public StartFightRound(int gladiatorId) {
            GladiatorId = gladiatorId;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class GladiatorDefeated : TinyMessenger.ITinyMessage {

        public int GladiatorId;

        #region Implementation
        public GladiatorDefeated(int gladiatorId) {
            GladiatorId = gladiatorId;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }        
    public class PrepareToPerformAttack : TinyMessenger.ITinyMessage {

        #region Implementation
        public PrepareToPerformAttack() {            
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class PerformAttack : TinyMessenger.ITinyMessage {

        #region Implementation
        public PerformAttack() {            
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class GladiatorKilled : TinyMessenger.ITinyMessage {

        public int GladiatorId;

        #region Implementation
        public GladiatorKilled(int gladiatorKilled) {
            GladiatorId = gladiatorKilled;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class GladiatorSpared : TinyMessenger.ITinyMessage {

        public int GladiatorId;

        #region Implementation
        public GladiatorSpared(int giadiatorId) {
            GladiatorId = giadiatorId;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class PerformActiveAbility : TinyMessenger.ITinyMessage {

        public ActiveAbility Ability;
        public int ExecutingGladiatorId;

        #region Implementation
        public PerformActiveAbility(ActiveAbility ability, int executingGladiatorId) {
            Ability = ability;
            ExecutingGladiatorId = executingGladiatorId;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }   

    public class NotEnughAdrenaline : TinyMessenger.ITinyMessage {

        public int GladiatorId;
        
        #region Implementation
        public NotEnughAdrenaline(int gladiatorId) {
            GladiatorId = gladiatorId;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class ArrowClicked : TinyMessenger.ITinyMessage {

        public int ArrowID;
        
        #region Implementation
        public ArrowClicked(int arrowID)
        {
            ArrowID = arrowID;
        }

        public object Sender
        {
            get { return null; }
        }
        #endregion
    }

    public class ArrowReleased : TinyMessenger.ITinyMessage {

        public int ArrowID;

        #region Implementation
        public ArrowReleased(int arrowID)
        {
            ArrowID = arrowID;
        }

        public object Sender
        {
            get { return null; }
        }
        #endregion
    }

    public class SetGladiatorState : TinyMessenger.ITinyMessage {

        public int GladiatorId;
        public GladiatorController.AnimationState NewState;

        #region Implementation
        public SetGladiatorState(int gladiatorId, GladiatorController.AnimationState newState) {
            GladiatorId = gladiatorId;
            NewState = newState;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class DealDamage : TinyMessenger.ITinyMessage
    {
        public int GladiatorID;
        public float Damage;

        #region Implementation
        public DealDamage(int gladiatorID, float damage)
        {
            GladiatorID = gladiatorID;
            Damage = damage;
        }

        public object Sender
        {
            get { return null; }
        }
        #endregion
    }

    public class SelectPerformed : TinyMessenger.ITinyMessage {

        #region Implementation
        public SelectPerformed() {            
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class LeftPressed : TinyMessenger.ITinyMessage {

        #region Implementation
        public LeftPressed() {
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class RightPressed : TinyMessenger.ITinyMessage {

        #region Implementation
        public RightPressed() {
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class GladiatorHealthChanged : TinyMessenger.ITinyMessage {

        public int GladiatorId;
        public float NewPercentValue;

        #region Implementation
        public GladiatorHealthChanged(int gladiatorId, float percent) {
            GladiatorId = gladiatorId;
            NewPercentValue = percent;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class GladiatorAdrenalineChanged : TinyMessenger.ITinyMessage {

        public int GladiatorId;
        public float NewPercentValue;

        #region Implementation
        public GladiatorAdrenalineChanged(int gladiatorId, float percent) {
            GladiatorId = gladiatorId;
            NewPercentValue = percent;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class AbilitySmirked : TinyMessenger.ITinyMessage {

        public int SmirkGladiatorTargetId;

        #region Implementation
        public AbilitySmirked(int smirkGladiatorTargetId) {
            SmirkGladiatorTargetId = smirkGladiatorTargetId;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }

    public class HideArrowKeys : TinyMessenger.ITinyMessage {

        public bool Hide;

        #region Implementation
        public HideArrowKeys(bool hide) {
            Hide = hide;
        }

        public object Sender {
            get { return null; }
        }
        #endregion
    }
}
