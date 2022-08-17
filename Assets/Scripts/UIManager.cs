using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI KillCountText;
    public GameObject GameOverPanel;
    public GameObject TutorialPanel;
    public GameObject MobileInputs;

    private void Start()
    {
        KillCountText.text = "Kills: 0";
        GameOverPanel.SetActive(false);

        #if !PLATFORM_ANDROID
        MobileInputs.SetActive(false);
        TutorialPanel.SetActive(true);
        GameManager.Instance.IsPause = true;
        #endif
    }

    private void Update()
    {
        KillCountText.text = "Kills: " + GameManager.Instance.KillCount.ToString();

        if(GameManager.Instance.Player.IsDead)
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void CloseTutorialPanel()
    {
        TutorialPanel.SetActive(false);
        GameManager.Instance.IsPause = false;
    }

}
