using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points instance;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int points, totalPoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        text.text = (points + "/" + totalPoints);
    }

    // Update is called once per frame
    public void Hitted()
    {
        points++;
        text.text = (points + "/" + totalPoints);
    }
}
