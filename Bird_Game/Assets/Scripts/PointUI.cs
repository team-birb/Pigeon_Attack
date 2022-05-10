using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointUI : MonoBehaviour
{
    private TextMeshProUGUI pointText;

    // Start is called before the first frame update
    void Start()
    {
        pointText = GetComponent<TextMeshProUGUI>();   
    }

    public void UpdatePointText(PointCounter pointCounter)
    {
        pointText.text = pointCounter.points.ToString();
    }
}
