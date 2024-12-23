using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SC_PlayerHP : MonoBehaviour
{
    public int HP = 100;
    public GameObject bloodyscreen;
    public RuntimeAnimatorController deadcontroller; // ∫Ø∞Ê«“ Animator Controller

    //public int damage = 20;
    public void TakeDamage(int damageAmount)
    {

        HP -= damageAmount;
        if (HP <= 0)
        {
            Debug.Log("Player Dead");
            PlayerDead();
        }
        else
        {
            Debug.Log("Player Hit");
            StartCoroutine(BloodyScreenEffect());
        }
    }

    private void PlayerDead()
    {
        GetComponent<SC_PlayerControl>().enabled = false;
        GetComponent<SC_PlayerMove>().enabled = false;
        GetComponentInChildren<Animator>().runtimeAnimatorController = deadcontroller;
    }

    private IEnumerator BloodyScreenEffect()
    {
        if(bloodyscreen.activeInHierarchy == false)
        {
            bloodyscreen.SetActive(true);
        }

        var image = bloodyscreen.GetComponentInChildren<UnityEngine.UI.Image>();

        // Set the initial alpha value to 1 (fully visible).
        Color startColor = image.color;
        startColor.a = 1f;
        image.color = startColor;

        float duration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the new alpha value using Lerp.
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            // Update the color with the new alpha value.
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;

            // Increment the elapsed time.
            elapsedTime += Time.deltaTime;

            yield return null; ; // Wait for the next frame.
        }


        if(bloodyscreen.activeInHierarchy == true)
        {
            bloodyscreen.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            TakeDamage(other.gameObject.GetComponent<SC_ZombieHand>().damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bloodyscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
