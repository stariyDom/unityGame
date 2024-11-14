using UnityEngine;

public class PauseButtonPosition : MonoBehaviour
{
    public Camera MainCamera; // —сылка на основную камеру
    public Vector3 offset; // —мещение дл€ кнопки

    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();


        Vector3 screenPosition = new Vector3(-Screen.width / 2 + offset.x, Screen.height / 2 - offset.y, 0);
        Vector3 worldPosition = MainCamera.ScreenToWorldPoint(screenPosition);
        rectTransform.position = new Vector3(worldPosition.x, worldPosition.y, rectTransform.position.z);
    }
}

