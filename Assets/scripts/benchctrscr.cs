using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class benchctrscr : MonoBehaviour
{
    public GameObject upright;
    public GameObject concave_lens_upright;
    private GameObject bench;
    private int upr_count;
    private int lens_upr_count;
    private int max_lens_uprights;
    private Transform curr_upright;
    private List<Transform> uprights;
    private int curr_index;
    private Slider slider;
    private Button add;
    private Button add_lens;
    private Button remove;
    private Button next;
    private Button prev;
    [HideInInspector] public int pivotted_upr;
    private Toggle pivot;
    private benchbtn cam_controller;
    private Text upright_num;
    private int max_uprights;
    [HideInInspector] public GameObject lowend;
    [HideInInspector] public GameObject highend;
    [HideInInspector] public float maxdiff;
    [HideInInspector] public bool check;

    private bool first_time_upr_check;
    private bool first_time_lens_upr_check;
    void Start()
    {
        upright_num = GameObject.Find("Upright_num").GetComponent<Text>();
        add = GameObject.Find("Add_Upright").GetComponent<Button>();
        remove = GameObject.Find("Remove_Upright").GetComponent<Button>();
        next = GameObject.Find("Next_Upright").GetComponent<Button>();
        prev = GameObject.Find("Prev_Upright").GetComponent<Button>();
        pivot = GameObject.Find("pivot_upright").GetComponent<Toggle>();
        add_lens = GameObject.Find("Add_Lens_Upright").GetComponent<Button>();
        add.onClick.AddListener(addclick);
        remove.onClick.AddListener(removeclick);
        next.onClick.AddListener(nextclick);
        prev.onClick.AddListener(prevclick);
        add_lens.onClick.AddListener(addlensclick);
        check = false;
        curr_index = 0;
        upr_count = 1;
        max_uprights = 6;
        lens_upr_count = 0;
        max_lens_uprights = 1;
        pivotted_upr = -1;
        first_time_lens_upr_check = false;
        first_time_upr_check = false;
    }
    private void Update()
    {
        add.interactable = (upr_count-lens_upr_count < max_uprights-max_lens_uprights) ? true : false;
        add_lens.interactable = (lens_upr_count < max_lens_uprights) ? true : false;
        next.interactable = (upr_count == 1) ? false : true;
        remove.interactable = (upr_count == 1) ? false : true;
        next.interactable = (curr_index == upr_count - 1) ? false : true;
        prev.interactable = (curr_index == 0) ? false : true;
        if (!first_time_upr_check && upr_count - lens_upr_count >= 2) experiment_controller.steps_update(3);
        if(!first_time_lens_upr_check && lens_upr_count > 0)
        {
            experiment_controller.steps_update(4);
        }
        //Debug.Log(curr_index);

    }
    private void OnEnable()
    {
        //Debug.Log("OnEnable called");
        bench = GameObject.Find("OpticBench(Clone)");
        if (bench != null)
        {
            //Debug.Log("in enable func");
            //curr_index = 0;
            check = true;
            lowend = GameObject.Find("low-end");
            highend = GameObject.Find("high-end");
            //Debug.Log(lowend);
            //Debug.Log(highend);
            update_uprights();
            //Debug.Log(upr_count);
            maxdiff = Vector3.Distance(lowend.transform.position, highend.transform.position);
            slider = GameObject.Find("Position-slider").GetComponent<Slider>();
            cam_controller = FindObjectOfType<benchbtn>();
            switch_upright(0);
        }
    }

    void addclick()
    {
        if(uprights.Count < max_uprights-max_lens_uprights) {

            GameObject new_upr = Instantiate(upright, curr_upright.transform.position, curr_upright.transform.rotation);
            Transform t = new_upr.transform;
            new_upr.transform.SetParent(curr_upright.parent);
            new_upr.transform.localScale = curr_upright.transform.localScale;
            update_uprights(t);
            Invoke("nextclick", 0.1f);
        }
    }
    void addlensclick()
    {
        if (lens_upr_count < max_lens_uprights){
            GameObject new_upr = Instantiate(concave_lens_upright, curr_upright.transform.position, curr_upright.transform.rotation);
            Transform t = new_upr.transform;
            new_upr.transform.SetParent(curr_upright.parent);
            new_upr.transform.localScale = curr_upright.transform.localScale;
            update_uprights(t);
            lens_upr_count++;
            Invoke("nextclick", 0.1f);
        }   
    }
    void removeclick()
    {
        if (upr_count == 1) return;
        Transform tbd_upright = curr_upright;
        if (curr_index == upr_count - 1)
        { 
            prevclick(); 
        }
        else { 
            nextclick(); 
            curr_index--; 
        }
        if (tbd_upright.name.Contains("Lens")) { 
            lens_upr_count--; 
        }
        DestroyImmediate(tbd_upright.gameObject);
        update_uprights();
        upright_num.text = "Upright " + (curr_index + 1);

        //Debug.Log(curr_index);
        //Debug.Log(upr_count);
    }
    void nextclick()
    {
        if (curr_index == upr_count - 1)
        {
            //Debug.Log("no next");
            return;
        }
        switch_upright(1);
        //Debug.Log(curr_index);
        cam_controller.cam_switch(curr_upright.Find("upright_cam").transform.Find("upr_cam").GetComponent<Camera>());
        //Debug.Log(curr_index);
        //Debug.Log(upr_count);
    }
    void prevclick()
    {
        if (curr_index == 0) return;
        switch_upright(-1);
        cam_controller.cam_switch(curr_upright.Find("upright_cam").transform.Find("upr_cam").GetComponent<Camera>());
        //Debug.Log(curr_index);
        //Debug.Log(upr_count);
    }

    private void switch_upright(int change)
    {
        curr_index = curr_index + change;
        //Debug.Log("curr_index = " + curr_index);
        if (curr_upright != null)
            curr_upright.GetComponent<Outline>().enabled = false;
        curr_upright = uprights[curr_index];
        curr_upright.GetComponent<Outline>().enabled = true;
        slider.GetComponent<positionsliderscr>().upright = curr_upright.gameObject;
        slider.GetComponent<positionsliderscr>().enablecall();

        if (curr_index == pivotted_upr) pivot.SetIsOnWithoutNotify(true);
        else pivot.SetIsOnWithoutNotify(false);

        //Debug.Log("pivotted: " + pivotted_upr);
        //Debug.Log("curr_index: " + curr_index);
        upright_num.text = "Upright " + (curr_index + 1);
    }

    void update_uprights()
    {
        uprights = new List<Transform>();
        upr_count = 0;
        foreach (Transform tr in GameObject.Find("Uprights").transform)
        {
            upr_count++;
            if (tr.tag == "upright")
                uprights.Add(tr);
        }
    }
    void update_uprights(Transform t)
    {
        upr_count++;
        uprights.Add(t); 
    }
    public Transform get_curr_upright() { 
        return curr_upright;
    }

    public void clickToggle(bool tog) 
    {
        if (tog == true) pivotted_upr = curr_index;
        else pivotted_upr = -1;
        //Debug.Log("pivotted after change: " + pivotted_upr); 
    }

    public Transform get_pivotted_upright() { 
        return uprights[pivotted_upr];
    }
    public int get_pivotted_index() { 
        return pivotted_upr;
    }
}
