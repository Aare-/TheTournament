using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class AnimationSequence {
    [Header("Configuration")]        
    [SerializeField]
    private int _StartingNumber;
    [SerializeField]
    private int _Length;

    [HideInInspector]
    public string PathToAtlas;
    [HideInInspector]
    public string AtlasName;      

    List<AnimationFrame> _Frames;

    #region Local Static Cache 
    private static Dictionary<String, Sprite[]> _SpriteCache = new Dictionary<string,Sprite[]>();
    #endregion

    public List<AnimationFrame> Frames {
        get {
            if (_Frames == null)
                InitFrames();            

            return _Frames;
        }
        private set { }
    }

    void InitFrames() {
        _Frames = new List<AnimationFrame>();
        string pathPrefix = PathToAtlas + "/" + AtlasName;

        Sprite[] arr = null;
        if (_SpriteCache.ContainsKey(pathPrefix)) {
            arr = _SpriteCache[pathPrefix];
        } else {
            _SpriteCache.Add(pathPrefix, Resources.LoadAll<Sprite>(PathToAtlas + "/" + AtlasName));
            InitFrames();
            return;
        }                

        for (int i = 0; i < _Length; i++) {
            int pos = i + _StartingNumber;
            _Frames.Add(new AnimationFrame(arr[pos]));
        }
    }
}
