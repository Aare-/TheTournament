using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Msg {
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
    
}
