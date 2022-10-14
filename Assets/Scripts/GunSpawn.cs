using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    private bool hasCollide = false;

    //Enable this if you still need the old script
    //private Spawner spawn; Delete this when everything gets corrected.
    private PowerUpSpawner spawn;
    private float time = 2f;

    void Start()
    {
        //spawn = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();     delete this also
        spawn = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapons player = hitInfo.GetComponent<Weapons>();
        if(player != null && !hasCollide)
        {
            hasCollide = !hasCollide;
            Destroy(gameObject);
            player.getGun();
            spawn.gun_limit--;
        }

    }
}
