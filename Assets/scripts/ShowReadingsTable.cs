using UnityEngine;

public class ShowReadingsTable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject readingsTable;
    GameObject numpad;
    private void Start()
    {
        numpad = GameObject.Find("Numpad Canvas");
    }
    public void showTable()
    {
        if(readingsTable != null)
        {
            readingsTable.SetActive(true);
            numpad.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void goBack()
    {
        readingsTable.SetActive(false);
        numpad.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
