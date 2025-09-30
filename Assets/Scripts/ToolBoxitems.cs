using UnityEngine;
using UnityEngine.UI;

public class ToolBoxitems : MonoBehaviour
{

    public Sprite ItemImage;
    public Transform ToolGridLayout;
    public GameObject toolBoxDialog;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toolBoxDialog.SetActive(false);
        }
        foreach (Transform child in ToolGridLayout)
        {
            Destroy(child.gameObject);
        }
        foreach (ToolType tool in GameData.Tools)
        {
            GameObject newImageObject = new GameObject("GridItem");
            newImageObject.transform.SetParent(ToolGridLayout, false);
            newImageObject.AddComponent<RectTransform>();
            Image newImageComponent = newImageObject.AddComponent<Image>();
            newImageComponent.sprite = ItemImage;
            newImageComponent.SetNativeSize();
        }
    }
}
