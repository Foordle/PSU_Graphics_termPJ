using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_UI : MonoBehaviour
{
    public SC_PlayerControl player;

    public GameObject menuCamera;
    public GameObject gameCamera;

    public GameObject menuPanel;
    public GameObject gamePanel;

    public Text hpText;
    public Text ammoText;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePanel.activeSelf)
        {
            hpText.text = player.CurrentHp + " / " + player.MaxHp;
            ammoText.text = player.CurrentAmmo + " / " + player.MaxAmmo;
        }
    }

    public void GameStart()
    {
        menuCamera.SetActive(false);
        gameCamera.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true);
    }
}
