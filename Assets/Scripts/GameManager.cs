using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int KillCount;
    public TextMeshProUGUI KillCountText;

    private void Start()
    {
        KillCountText.text = "Kills: 0";
    }

    private void Update()
    {
        KillCountText.text = "Kills: " + KillCount.ToString();
    }
}
