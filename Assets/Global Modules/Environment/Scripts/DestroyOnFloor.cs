using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tajurbah_Gah
{
    public class DestroyOnFloor : MonoBehaviour
    {
        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            GameObject temp = collision.gameObject;

            while (collision.transform.parent != null)
            {
                if (temp.GetComponent<ParentCheckController>())
                {
                    break;
                }
                else
                {
                    temp = temp.transform.parent.gameObject;
                }
            }
            if (temp.GetComponent<ParentCheckController>().dontDestroyOnFloor)
            {
                return;
            }
            else
            {
                Destroy(temp.gameObject);
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            GameObject temp = collision.gameObject;

            while (collision.transform.parent != null)
            {
                if (temp.GetComponent<ParentCheckController>())
                {
                    break;
                }
                else
                {
                    temp = temp.transform.parent.gameObject;
                }
            }
            if (temp.GetComponent<ParentCheckController>().dontDestroyOnFloor)
            {
                return;
            }
            else
            {
                Destroy(temp.gameObject);
            }
        }
    }
}
