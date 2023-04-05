using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLayer : BaseLayerTemplate
{
    [SerializeField] Button _nextBtn, _backBtn;
    [SerializeField] Image _resultImg;
    [SerializeField] Sprite[] _resultSprite;

    public virtual void Awake()
    {
        _nextBtn.onClick.AddListener(OnClickNextButton);
        _backBtn.onClick.AddListener(OnClickBackButton);
    }

    public virtual void OnEnable()
    {
        _nextBtn.gameObject.SetActive(false);

        ShowResultImage();
        ShowResultEffect();
    }

    private void OnClickNextButton()
    {
        LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Play);
    }

    private void OnClickBackButton()
    {
        LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Top);
    }

    private void ShowResultImage()
    {
        //_resultSprite[0] = clearImage, _resultSprite[1] = failureImage
        _resultImg.sprite = GameManager.Instance.GetIsClear() ? _resultSprite[0] : _resultSprite[1];
    }

    private void ShowResultEffect()
    {
        DelayControlClass.Instance.CallAfter(1.0f, ()=> { _nextBtn.gameObject.SetActive(true); });
    }
}
