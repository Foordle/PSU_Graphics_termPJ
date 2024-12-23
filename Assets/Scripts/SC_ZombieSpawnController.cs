using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ZombieSpawnController : MonoBehaviour
{
    public int initialZombiePerWave = 1;
    public int currentZombiePerWave;

    public float spawndelay=3;
    public int currentWave = 0;
    public float waveCoolDownSec = 10.0f;

    public bool inCoolDown;
    public float coolDownCounter=0;

    public List<SC_Zombie> currentZombieAlives;

    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentZombiePerWave = initialZombiePerWave;
        StartNextWave();
    }
    public void StartNextWave()
    {
        currentZombieAlives.Clear();
        currentWave++;
        StartCoroutine(SpawnWave());
    }
    public IEnumerator SpawnWave()
    {
        for(int i = 0; i < currentZombiePerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            var zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            SC_Zombie zombieScript = zombie.GetComponent<SC_Zombie>();

            currentZombieAlives.Add(zombieScript);

            yield return new WaitForSeconds(spawndelay);
        }
    }
    // Update is called once per frame
    void Update()
    {
        List<SC_Zombie> zombiesToRemove = new List<SC_Zombie>();
        foreach(SC_Zombie zombie in currentZombieAlives)
        {
            if (zombie.isDead)
            {
                zombiesToRemove.Add(zombie);
            }
        }
        foreach(SC_Zombie zombie in zombiesToRemove)
        {
            currentZombieAlives.Remove(zombie);
        }
        zombiesToRemove.Clear();

        if(currentZombieAlives.Count==0 && inCoolDown == false)
        {
            StartCoroutine(WaveCoolDown());
        }
        if (inCoolDown)
        {
            coolDownCounter-=Time.deltaTime;
        }
        else
        {
            coolDownCounter = waveCoolDownSec;
        }
    }
    private IEnumerator WaveCoolDown()
    {
        inCoolDown = true;
        yield return new WaitForSeconds(waveCoolDownSec);
        inCoolDown = false;

        currentZombiePerWave *= 2;
        StartNextWave();
    }
}
