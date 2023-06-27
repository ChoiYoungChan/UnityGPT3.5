using Cysharp.Threading.Tasks;
using openAI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLayer : MonoBehaviour
{
    [SerializeField] Button EnterBtn;
    [SerializeField] Text OutputText;
    [SerializeField] InputField InputText;

    private string answerText = "";

    private void Start()
    {
        EnterBtn.onClick.AddListener(OnClickEnterButton);
    }

    public void OnClickEnterButton()
    {
        _ = GetAnswerData();
    }

    private async UniTask GetAnswerData()
    {
       await ChatGPTConnection.Instance.GetAPIResponse(InputText.text);

        answerText = ChatGPTConnection.Instance.GetAnswerData();

        if (answerText == "") Debug.LogError("### Text is Empty");
        if (answerText.StartsWith("\n\n")) answerText = answerText.Substring(2);

        OutputText.text = answerText;
    }
}
