using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Msg {
    public class StartFight : TinyMessenger.ITinyMessage {

        public int AllyId;
        public int OpponentId;

        #region Implementation
        public StartFight(int allyId, int opponentId) {
            AllyId = allyId;
            OpponentId = opponentId;
        }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
}
