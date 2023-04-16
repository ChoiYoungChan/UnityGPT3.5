using Cysharp.Threading.Tasks;
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
        Initialize();
    }

    /// <summary>
    /// Initialize
    /// </summary>
    public override void Initialize()
    {
        backBtn.onClick.AddListener(() => {
            LayerManager.Instance.MoveLayer(LayerManager.LayerKey.LayerKey_Top);
        });

        enterBtn.onClick.AddListener(OnClickEnterButton);

    }

    public void OnClickEnterButton()
    {
        _ = GetAnswerData();
        answerText = ChatGPTConnection.Instance.GetAnswerData();
    }

    private async UniTask GetAnswerData()
    {
       await ChatGPTConnection.Instance.GetAPIResponse(inputText.text);

        answerText = ChatGPTConnection.Instance.GetAnswerData();

        if (answerText == "") Debug.LogError("### Text is Empty");
        if (answerText.StartsWith("\n\n")) answerText = answerText.Substring(2);

        outputText.text = answerText;
    }
}
