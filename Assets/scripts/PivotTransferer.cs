using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotTransferer : MonoBehaviour
{
    private GameObject bench_canvas;
    private Transform pivot_upr;
    private int pivot_index;

    public void transfer()
    {
        bench_canvas = GameObject.Find("Bench Canvas");
        pivot_index = bench_canvas.GetComponent<benchctrscr>().get_pivotted_index();
        if (pivot_index != -1)
            pivot_upr = bench_canvas.GetComponent<benchctrscr>().get_pivotted_upright();
        //Debug.Log(pivot_upr);
    }

    public Transform get_pivot() { 
        return pivot_upr; 
    }
    public int get_pivot_index() { 
        return pivot_index;
    }
}
