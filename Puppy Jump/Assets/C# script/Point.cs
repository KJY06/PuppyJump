using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    private float currentTime;
    public GameObject Text;
    private float maxTime;
    public int point;
    private int highscore;
    private string KeyString = "HighScore";
    [SerializeField] Text PointText;
    [SerializeField] Text HI;
    private Item i;

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt(KeyString);
    }
    private void Start()
    {
        i = FindObjectOfType<Item>();
        maxTime = 0.1f;
        point = 0;
        PointText.text = $"{point}";
        HI.text = $"HI : {highscore}";
    }
    private void Update()
    {
        AddPoint();
        Jump();
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
        if(highscore < point)
        {
            PlayerPrefs.SetInt(KeyString, point);
        }
    }
    void Jump()
    {
        if(point % 100 == 0 && point > 0)
        {
            Debug.Log($"point % 100: {point % 100}");
            i.spawncnt = 1;
        }
    }
}
