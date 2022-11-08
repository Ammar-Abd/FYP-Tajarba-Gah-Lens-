using UnityEngine;
using UnityEngine.UI;

public class ViewSwitchController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainCamera;
    public GameObject secondaryCameraRig;
    bool state = false;
    GameObject secondary_canvas;
    Slider secondary_slider;
    GameObject bench;
    public GameObject inventory;
    void Start()
    {
        mainCamera = GameObject.Find("Camera");
        secondary_canvas = GameObject.Find("Secondary Canvas");
        secondary_slider = GameObject.Find("Position-slider 2").GetComponent<Slider>(); ;
        secondary_canvas.SetActive(false);
    }

    public void switchView()
    {
        bench = GameObject.Find("OpticBench(Clone)");
        if (!state)
        {
            mainCamera.SetActive(false);
            secondaryCameraRig.SetActive(true);
            secondary_canvas.SetActive(true);
            secondary_slider.GetComponent<SecondarySlider>().enablecall();
            state = !state;
            if (bench)
            {
                bench.GetComponent<Tajurbah_Gah.DragDropController>().enabled = false;
            }
            inventory.SetActive(false);
            
        }
        else
        {
            mainCamera.SetActive(true);
            secondaryCameraRig.SetActive(false);
            secondary_canvas.SetActive(false);
            state = !state;
            if (bench)
            {
                bench.GetComponent<Tajurbah_Gah.DragDropController>().enabled = true;
            }
            inventory.SetActive(true);
        }
    }
}
