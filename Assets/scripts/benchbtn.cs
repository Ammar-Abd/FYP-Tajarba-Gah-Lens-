using UnityEngine;
using UnityEngine.UI;

public class benchbtn : MonoBehaviour
{
    private GameObject bench;
    [HideInInspector] public Camera curr_cam;
    private Camera maincam;
    private Canvas mainUI;
    private Canvas benchUI;
    private GameObject transferer;
    private GameObject secondary_canvas;
    private bool secondary_check;
    private bool first_time_click;
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(onclick);
        maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainUI = GameObject.Find("Main UI canvas").GetComponent<Canvas>();
        benchUI = GameObject.Find("Bench Canvas").GetComponent<Canvas>();
        benchUI.gameObject.SetActive(false);
        transferer = GameObject.Find("transferer");
        first_time_click = false;
    }
    private void Update()
    {
        gameObject.GetComponent<Button>().interactable = (GameObject.Find("OpticBench(Clone)")) ? true : false;
    }
    void onclick()
    {
        bench = GameObject.Find("OpticBench(Clone)");
        if (bench != null)
        { 
            secondary_canvas = GameObject.Find("Secondary Canvas");
            if (secondary_canvas != null)
            {
                secondary_canvas.SetActive(false);
                secondary_check = true;
            }
            bench.GetComponent<Tajurbah_Gah.DragDropController>().enabled = false;
            if (curr_cam == null)
                curr_cam = GameObject.Find("upr_cam").GetComponent<Camera>();
            curr_cam.enabled = true;
            maincam.enabled = false;
            //mainUI.gameObject.SetActive(false);
            mainUI.gameObject.GetComponent<Canvas>().enabled = false;
            benchUI.gameObject.SetActive(true);
            if(!first_time_click)
            {
                experiment_controller.steps_update(2);
                first_time_click = true;
            }
        }
    }

    public void cam_switch(Camera new_cam)
    {
        curr_cam.enabled = false;
        new_cam.enabled = true;
        curr_cam = new_cam;
        //Debug.Log("Cam Switched");
    }

    public void revert()
    {
        if (secondary_check == true)
        {
            secondary_check = false;
            secondary_canvas.SetActive(true);
            transferer.GetComponent<PivotTransferer>().transfer();
            secondary_canvas.transform.Find("Position-slider 2").GetComponent<SecondarySlider>().enablecall();
            bench.GetComponent<Tajurbah_Gah.DragDropController>().enabled = true;
            Transform curr_upright = benchUI.GetComponent<benchctrscr>().get_curr_upright();
            if (curr_upright.GetComponent<Outline>().enabled)
                curr_upright.GetComponent<Outline>().enabled = false;
            maincam.enabled = true;
            curr_cam.enabled = false;
            //mainUI.gameObject.SetActive(true);
            mainUI.gameObject.GetComponent<Canvas>().enabled = true;
            benchUI.gameObject.SetActive(false);
        }
        else
        {
            bench.GetComponent<Tajurbah_Gah.DragDropController>().enabled = true;
            Transform curr_upright = benchUI.GetComponent<benchctrscr>().get_curr_upright();
            if (curr_upright.GetComponent<Outline>().enabled)
                curr_upright.GetComponent<Outline>().enabled = false;
            transferer.GetComponent<PivotTransferer>().transfer();
            maincam.enabled = true;
            curr_cam.enabled = false;
            //mainUI.gameObject.SetActive(true);
            mainUI.gameObject.GetComponent<Canvas>().enabled = true;
            benchUI.gameObject.SetActive(false);
        }
    }
}
