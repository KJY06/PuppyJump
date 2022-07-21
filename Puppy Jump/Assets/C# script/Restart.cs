using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnclickToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
