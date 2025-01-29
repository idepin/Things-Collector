using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    public void Over()
    {
        Time.timeScale = 0;
        txtScore.SetText(PointManager.instance.point.ToString());
    }

    public void StartOver()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
