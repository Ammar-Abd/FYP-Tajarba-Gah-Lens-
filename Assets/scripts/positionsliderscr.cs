using UnityEngine;
using UnityEngine.UI;

public class positionsliderscr : MonoBehaviour
{
    private GameObject bench;
    private Slider slider;
    private Text num;
    [HideInInspector] public GameObject upright;
    private GameObject lowend;
    private GameObject highend;
    private float maxdiff;
    void Start()
    {
        //Debug.Log(benchcontroller);
        num = GameObject.Find("Position-text").GetComponent<Text>();
        slider.onValueChanged.AddListener(OnValChange);
        slider.value = 0;   
    }
    private void OnEnable()
    {
        slider = this.GetComponent<Slider>();
    }
    void OnValChange(float v)
    {
        num.text = (v * 100).ToString("F2") + " cm";
        float xpos = lowend.transform.position.x - (v * maxdiff);
        upright.transform.position = new Vector3(xpos, upright.transform.position.y, upright.transform.position.z);
    }

    public void enablecall()
    {
        bench = GameObject.Find("OpticBench(Clone)");
        if (bench != null)
        {
            lowend = GameObject.Find("low-end");
            highend = GameObject.Find("high-end");
            maxdiff = Vector3.Distance(lowend.transform.position, highend.transform.position);
            slider.value = upright.GetComponent<uprightscr>().get_pos();
        }
    }
}
