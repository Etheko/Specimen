using UnityEngine;
using UnityEngine.UI;

public class LeaveBt : MonoBehaviour
{

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void QuitGame()
    {
        Application.Quit();
    }
}
