using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class InputVerificationV2 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<row> rows;
    public GameObject incompletePopUp;
    public GameObject incorrectFieldPopUp;
    public GameObject successPoPup;
    public Button submit;
    void Start()
    {
        submit.onClick.AddListener(verify);
        incompletePopUp.SetActive(false);
        successPoPup.SetActive(false);
        incorrectFieldPopUp.SetActive(false);
    }
    public void verify()
    {
        rows = new List<row>();
        foreach (Transform rowObj in gameObject.transform)
        {
            try
            {
                Debug.Log(rowObj.name);
                row r = new row(rowObj);
                rows.Add(r);
            }
            catch (FormatException)
            {
                rows = null;
                StartCoroutine(showPopUp(this.incompletePopUp));
                return;
            }
        }
        if (fieldsAreValid() == false || answerIsValid() == false)
        {
            StartCoroutine(showPopUp(this.incorrectFieldPopUp));
            return;
        }
        if (fieldsAreValid() == true && answerIsValid() == true)
        {
            StartCoroutine(showPopUp(this.successPoPup));
        }
        

    }
    private bool fieldsAreValid()
    {
        foreach (row r in rows)
        {
            if (!r.verifyFields())
            {
                return false;
            }
        }
        return true;
    }
    private bool answerIsValid()
    {
        foreach(row r in rows)
        {
            if (!r.verifyFocalLength())
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator showPopUp(GameObject popUp)
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(2);
        popUp.SetActive(false);
    }

    public class row
    {
        private float objectNeedle;
        private float imageNeedle;
        private float distanceBetweenObjectAndImage;
        private float L1;
        private float L2;
        private float distanceBetweenL1L2;
        private float focalLength;
        public row(Transform rowObj)
        {
            List<float> columns = new List<float>();
            foreach (Transform col in rowObj)
            {
                try
                {
                    columns.Add(float.Parse(col.gameObject.GetComponent<TMP_InputField>().text));
                }
                catch (FormatException Fe)
                {
                    throw Fe;
                }
            }
            objectNeedle = columns[0];
            imageNeedle = columns[1];
            distanceBetweenObjectAndImage = columns[2];
            L1 = columns[3];
            L2 = columns[4];
            distanceBetweenL1L2 = columns[5];
            focalLength = columns[6];
        }
        private bool distanceBetweenObjectAndImageIsValid()
        {
            if(distanceBetweenObjectAndImage <= 65 && distanceBetweenObjectAndImage >= 57)
            {
                return true;
            }
            return false;
        }
        private bool distanceBetweenL1L2IsValid()
        {
            if(distanceBetweenL1L2 <= 7 && distanceBetweenL1L2 >= 3)
            {
                return true;
            }
            return false;
        }
        public bool verifyFields()
        {
            if (distanceBetweenL1L2IsValid() && distanceBetweenObjectAndImageIsValid())
            {
                return true;
            }
            return false;
            
        }
        
        public bool verifyFocalLength()
        {
            if (focalLength <= 16 && focalLength >= 14.5)
            {
                return true;
            }
            return false;
        }

    }
}
