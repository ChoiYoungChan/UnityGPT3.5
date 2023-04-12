using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextList : MonoBehaviour
{
    [SerializeField] Text _outputText;

    private const float speed = 0.2f;
    void Start()
    {
        if(!_outputText) Debug.LogError("Output Text is not Selected!!");
    }

    public void SetText(string outputTextData)
    {
        StartCoroutine(TypeText(outputTextData));
    }

    IEnumerator TypeText(string typTextData)
    {
        for(int count = 0; count < typTextData.Length; count ++)
        {
            _outputText.text = typTextData.Substring(0, count+1);
            yield return new WaitForSeconds(speed);
        }
    }
}
