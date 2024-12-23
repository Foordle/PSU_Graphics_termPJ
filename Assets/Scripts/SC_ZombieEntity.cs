using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ZombieEntity : MonoBehaviour
{
    public SC_ZombieHand zombieHand;
    public int zombieDamage;
    // Start is called before the first frame update
    void Start()
    {
        zombieHand.damage = zombieDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
