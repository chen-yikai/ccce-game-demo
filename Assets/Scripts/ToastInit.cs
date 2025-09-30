using System.Collections;
using UnityEngine;

public class ToastInit : MonoBehaviour
{
    public bool autoHide = false;

    void OnEnable()
    {
        if (autoHide)
        {
            StartCoroutine(HideAfterDelay());
        }
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
