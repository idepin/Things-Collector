using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadOnTimelineDone : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    private void Start()
    {
        playableDirector.stopped += Stop;
    }

    private void OnDestroy()
    {
        playableDirector.stopped -= Stop;
    }

    private void Stop(PlayableDirector playableDirector)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
