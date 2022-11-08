using UnityEngine;
using UnityEngine.UI;
public class KeyboardDisabler : InputField 
{
    // Start is called before the first frame update
    protected override void Start()
    {
        keyboardType = (TouchScreenKeyboardType)(-1);
        base.Start();
    }

}
