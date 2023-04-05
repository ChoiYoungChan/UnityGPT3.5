using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLayer : BaseLayerTemplate
{
    [SerializeField] Button _settingBtn, _backBtn;
    [SerializeField] GameObject _tutorial, _cover;

    private bool _canTouch;

    public virtual void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize
    /// </summary>
    public virtual void Initialize()
    {
        if (CacheData.Instance.IsFirstOpen) {
            CacheData.Instance.Tutorial = false;
            _tutorial.SetActive(true);
            CacheData.Instance.IsFirstOpen = false;
        }

        _settingBtn.onClick.AddListener(()=> { DialogManager.Instance.OpenDialog(DialogManager.DialogKey.DialogKey_Setting);});
        _backBtn.onClick.AddListener(() => {
            LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Top);
        });
    }

    public virtual void OnEnable()
    {
        //SoundManager.Instance.Play("bgm");
        _canTouch = false;

    }

    private void GeterateObject()
    {

    }

    /// <summary>
    /// MoveNextlayer
    /// </summary>
    public void MoveLayer()
    {

    }
}
