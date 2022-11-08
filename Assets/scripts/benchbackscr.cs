using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class benchbackscr : MonoBehaviour
{
    private Button back;
    private benchbtn rev;
    // Start is called before the first frame update
    void Start()
    {
        back = this.GetComponent<Button>();
        back.onClick.AddListener(onclick);
        rev = FindObjectOfType<benchbtn>();
    }

    // Update is called once per frame
    void onclick()
    {
        rev.revert();
    }
}
