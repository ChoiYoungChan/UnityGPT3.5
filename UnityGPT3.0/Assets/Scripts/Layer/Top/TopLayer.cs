using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopLayer : BaseLayerTemplate
{
    [SerializeField] Button _startBtn;

    private void Start()
    {
        _startBtn.onClick.AddListener(OnClickStartButton);
    }

    public virtual void OnEnable()
    { }

    private void OnClickStartButton()
    {
        LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Play);
    }
}
