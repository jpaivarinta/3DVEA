using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Reset : MonoBehaviour
{

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}