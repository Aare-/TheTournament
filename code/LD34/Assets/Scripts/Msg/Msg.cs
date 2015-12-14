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

    public class ChangeArrowSprite : TinyMessenger.ITinyMessage {

        public int ArrowID;
        public int IconID;

        #region Implementation
        public ChangeArrowSprite(int arrowID, int iconID)
        {
            ArrowID = arrowID;
            IconID = iconID;
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

    public class ShowDamage : TinyMessenger.ITinyMessage
    {
        public int GladiatorID;
        public float Damage;

        #region Implementation
        public ShowDamage(int gladiatorID, float damage)
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


}
