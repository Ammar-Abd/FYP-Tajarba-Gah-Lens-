using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    private int pagecount;
    private int curr_index;
    private List<Transform> pages;
    private GameObject page_num;

    private void OnEnable()
    {
        pages = new List<Transform>();
        page_num = GameObject.Find("page-num");
        pagecount = 0;
        curr_index = 0;
        foreach (Transform tr in this.transform)
        {
            if (tr.tag == "page")
            {
                pages.Add(tr);
                pagecount = pagecount + 1;
            }
        }
        refresh();
    }

    public void nextclick()
    {
        if (curr_index != pagecount - 1) curr_index = curr_index + 1;
        else
        {
            this.gameObject.SetActive(false);
            return;
        }
        refresh();
    }

    public void prevclick()
    {
        if (curr_index != 0) curr_index = curr_index - 1;
        refresh();
    }

    public void skipclick() { this.gameObject.SetActive(false); }

    private void refresh()
    {
        foreach (var i in pages)
        {
            i.gameObject.SetActive(false);
        }
        pages[curr_index].gameObject.SetActive(true);
        page_num.GetComponent<Text>().text = (curr_index + 1) + "/" + pagecount;
    }
}
