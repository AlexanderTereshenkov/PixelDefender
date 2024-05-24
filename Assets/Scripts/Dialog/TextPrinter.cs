using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextPrinter : MonoBehaviour
{
    [SerializeField] private string[] textLines;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Button nextButton;

    private bool isDialogShown;
    private int index;

    private void Start()
    {
        nextButton.onClick.AddListener(ShowText);
        dialogText.text = "";
    }

    private void ShowText()
    {
        if (index >= textLines.Length)
        {
            Debug.Log("END OF TEXT");
            return;
        }
        if (isDialogShown)
        {
            StopAllCoroutines();
            dialogText.text = textLines[index];
            isDialogShown = false;
            index++;
        }
        else
        {
            
            StartCoroutine(ShowTextCoroutine());
        }
    }

    private IEnumerator ShowTextCoroutine()
    {
        dialogText.text = "";
        isDialogShown = true;
        for(int i = 0; i < textLines[index].Length; i++)
        {
            dialogText.text += textLines[index][i];
            yield return new WaitForSeconds(0.05f);
        }
        isDialogShown = false;
        index++;
    }


}
