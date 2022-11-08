using UnityEngine;

public class CalculatorButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject calculator;
    private bool calcalutorOnScreen;
    void Start()
    {
        calculator.SetActive(false);
        calcalutorOnScreen = false;
    }

    // Update is called once per frame
    public void showHideCalculator()
    {
        calcalutorOnScreen = !calcalutorOnScreen;
        calculator.SetActive(calcalutorOnScreen);
    }
}
