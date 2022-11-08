using UnityEngine.UI;
using UnityEngine;

public class SecondarySlider : MonoBehaviour
{
    private GameObject bench;
    private GameObject lowend;
    private GameObject highend;
    private Slider slider;
    private Text num;
    private float maxdiff;
    private Transform upright;
    private GameObject transferer;
    private Text upr_text;
    // Start is called before the first frame update
    public void enablecall()
    {
        bench = GameObject.Find("OpticBench(Clone)");
        num = GameObject.Find("Position-text-2").GetComponent<Text>();
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnValChange);
        upr_text = GameObject.Find("Position-upr").GetComponent<Text>();
        //Debug.Log(num.name);
        if (bench != null)
        {
            transferer = GameObject.Find("transferer");
            lowend = GameObject.Find("low-end");
            highend = GameObject.Find("high-end");
            maxdiff = Vector3.Distance(lowend.transform.position, highend.transform.position);
            upright = transferer.GetComponent<PivotTransferer>().get_pivot();
            //Debug.Log(upright);
            if (upright != null)
            {
                slider.interactable = true;
                slider.value = upright.GetComponent<uprightscr>().get_pos();
                upr_text.text = "Upright " + (transferer.GetComponent<PivotTransferer>().get_pivot_index() + 1);
                num.text = (slider.value * 100).ToString("F2") + " cm";
            }
            else
            {
                slider.interactable = false;
                upr_text.text = "No Pivot";
            }
        }
        else
        {
            slider.interactable = false;
        }
    }

    void OnValChange(float v)
    {
        //Debug.Log("V="+ v.ToString());
        //Debug.Log("onvalchange");
        num.text = (v * 100).ToString("F2") + " cm";
        float xpos = lowend.transform.position.x - (v * maxdiff);
        upright.transform.position = new Vector3(xpos, upright.transform.position.y, upright.transform.position.z);
    }

    
}
