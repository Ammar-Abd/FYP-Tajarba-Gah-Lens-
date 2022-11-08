using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uprightscr : MonoBehaviour
{
    public Camera mycam;
    [HideInInspector] private float pos;
    private GameObject lowend;
    private GameObject highend;
    private float maxdiff;
    // Start is called before the first frame update
    void Start()
    {
        mycam.enabled = false;
        lowend = GameObject.Find("low-end");
        highend = GameObject.Find("high-end");
        maxdiff = Vector3.Distance(lowend.transform.position, highend.transform.position);
        pos = Vector3.Distance(this.transform.position, lowend.transform.position) / maxdiff;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = (lowend.transform.position.x - this.transform.position.x) / maxdiff;
    }

    public float get_pos() { return pos; }
}
