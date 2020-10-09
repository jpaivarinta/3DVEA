using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitKey : MonoBehaviour
{

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
