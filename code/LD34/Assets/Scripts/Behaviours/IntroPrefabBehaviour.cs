using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;
using UnityEngine;

class IntroPrefabBehaviour : PrefabBehaviour {
    public List<string> DisableOnEnter;    

    protected override void InitPrefabs() {
        base.InitPrefabs();

        TinyMessengerHub.Instance.Publish < Msg.HideArrowKeys>(new Msg.HideArrowKeys(true));
    }
    protected override void DestroyPrefabs() {
        base.DestroyPrefabs();

        TinyMessengerHub.Instance.Publish<Msg.HideArrowKeys>(new Msg.HideArrowKeys(false));
    }
}
