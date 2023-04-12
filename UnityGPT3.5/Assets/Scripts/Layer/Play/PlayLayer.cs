using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLayer : BaseLayerTemplate
{
    [SerializeField] Button _backBtn, _enterBtn, _regenerateBtn;
    [SerializeField] Text _outputText;
    [SerializeField] InputField _inputText;
    [SerializeField] GameObject _textListObject;
    [SerializeField] Transform _initializePos;

    private void Start()
    {
         
    }

    public virtual void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize
    /// </summary>
    public virtual void Initialize()
    {
        _backBtn.onClick.AddListener(() => {
            LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Top);
        });

        _enterBtn.onClick.AddListener(()=> {
            
        });

        _regenerateBtn.onClick.AddListener(() => {

        });
    }

    public virtual void OnEnable()
    {

    }

    public void SetTalk()
    {

    }

    public void GetTalk()
    {

    }

    public void OnClickReGenerateAnswerButton()
    {

    }

    public void OnClickEnterButton()
    {

    }
}
