using openAI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLayer : BaseLayerTemplate
{
    [SerializeField] Button backBtn, enterBtn, regenerateBtn;
    [SerializeField] Text outputText;
    [SerializeField] InputField inputText;
    [SerializeField] GameObject initializePos;

    private string answerText = "";
    private GameObject textlistObject;

    private void Start()
    {
        textlistObject = outputText.gameObject;
        outputText.gameObject.SetActive(false);
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
        backBtn.onClick.AddListener(() => {
            LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Top);
        });

        enterBtn.onClick.AddListener(OnClickEnterButton);

        regenerateBtn.onClick.AddListener(() => {

        });
    }

    public virtual void OnEnable()
    {

    }

    public void SetTalk()
    {
        if (answerText == "") OnClickEnterButton();

        GameObject _object = Instantiate(textlistObject, initializePos.transform, initializePos);
        _object.GetComponent<Text>().text = answerText;
    }

    public void OnClickReGenerateAnswerButton()
    {

    }

    public void OnClickEnterButton()
    {
        answerText = ChatGPTConnection.Instance.GetAPIResponse(inputText.text).ToString();
        SetTalk();
    }
}
