using UnityEngine;
using System;
using TMPro;

public class InputVerifier : MonoBehaviour
{
    public float validRangeStart;
    public float validRangeEnd;
    private TMP_InputField inputField;
    private float currentValue;
    private Color emptyFieldColor;
    private Color validFieldColor;
    private Color invalidFieldColor;
    void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        emptyFieldColor = inputField.image.color;
        validFieldColor = Color.green;
        invalidFieldColor = Color.red;

    }

    void Update()
    {
        try
        {
            currentValue = float.Parse(inputField.text);
        }
        catch (FormatException)
        {
            inputField.image.color = emptyFieldColor;
            return;
        }
        if ( currentValue <= validRangeEnd && currentValue >= validRangeStart)
        {
            inputField.image.color = validFieldColor;
        }
        else
        {
            inputField.image.color = invalidFieldColor;
        }
    }
    
}
