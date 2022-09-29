using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI KillCountText;
    public TextMeshProUGUI TutorialText;
    public GameObject GameOverPanel;
    public GameObject TutorialPanel;
    public GameObject MobileInputs;

    private void Start()
    {
        KillCountText.text = "Kills: 0";
        GameOverPanel.SetActive(false);

        GameManager.Instance.IsPause = true;
        TutorialPanel.SetActive(true);
        TutorialText.text = "Use the stick for moving and the buttons for attacking!";


#if !PLATFORM_ANDROID
        MobileInputs.SetActive(false);
        TutorialText.text = "Use \"WASD\" for move <br> \"Space\" for Attack <br> \"1 - 2\" for the Abilities";
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
