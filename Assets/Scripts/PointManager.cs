using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TextMeshProUGUI txtPoint;

    public int point;

    public void AddPoint(int add)
    {
        point += add;
        txtPoint.SetText(point.ToString());
    }
}
