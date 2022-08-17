using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI KillCountText;

    private void Start()
    {
        KillCountText.text = "Kills: 0";
    }

    private void Update()
    {
        KillCountText.text = "Kills: " + GameManager.Instance.KillCount.ToString();
    }
}
