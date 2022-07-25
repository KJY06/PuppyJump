using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    private float currentTime;
    private float maxTime;

    public int point;
    private int highscore;

    private string KeyString = "HighScore";

    [SerializeField] private Text PointText;
    [SerializeField] private Text HI;
    private void Awake()
    {
        highscore = PlayerPrefs.GetInt(KeyString);
    }
    private void Start()
    {
        maxTime = 0.1f;
        point = 0;
        PointText.text = $"{point}";
        HI.text = $"HI : {highscore}";
    }
    private void Update()
    {
        AddPoint();
        HighScore(); 
    }
    void AddPoint()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            point += 1;
            PointText.text = $"{point}";
        }
    }
    void HighScore()
    {
        if (highscore < point)
        {
            PlayerPrefs.SetInt(KeyString, point);
        }
    }
}
