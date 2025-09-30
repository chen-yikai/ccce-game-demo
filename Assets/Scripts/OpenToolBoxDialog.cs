using UnityEngine;

public class OpenDialog : MonoBehaviour
{
    public GameObject toolBoxDialog;
    public void onClick()
    {
        toolBoxDialog.SetActive(!toolBoxDialog.activeSelf);
    }
}
