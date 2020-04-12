using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dir = Enums.Direction;

/*
 * Responsible for instantiating projectile depending on the button pressed.
 */
public class Attack : MonoBehaviour
{
    public GameObject projectile;
    public GameObject yellowCircle;
    public float startTimeBtwShots;

    private GameObject wizardPlayer;
    private float timeBtwShots;
    private Player playerClass;

    void Start()
    {
        wizardPlayer = gameObject;
        playerClass = (Player) wizardPlayer.GetComponent("Player");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (Input.GetKey(KeyCode.DownArrow))
                FireProjectile(dir.up);
            else if (Input.GetKey(KeyCode.UpArrow))
                FireProjectile(dir.down);
            else
                FireProjectile(dir.straight);
        }
    }

    private void FireProjectile(dir direction)
    {
        if (timeBtwShots <= 0)
        {
            if (direction == dir.up)
                SpawnProjectile(-135f, -45f);
            else if (direction == dir.down)
                SpawnProjectile(135f, 45f);
            else  // direction == dir.straight
                SpawnProjectile(180f, 0f);

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    private void SpawnProjectile(float angleFacingLeft, float angleFacingRight)
    {
        Vector3 spawnPos = wizardPlayer.transform.position +
                           (playerClass.isFacingRight() ? Vector3.right : Vector3.left);
        Instantiate(
            yellowCircle,
            spawnPos,
            Quaternion.identity
            );
        Instantiate(
            projectile, // projectile gameObject
            spawnPos, // Spawn pos of projectile
            playerClass.isFacingRight() // rotation of the spawned obj
                ? Quaternion.Euler(0, 0, angleFacingRight)
                : Quaternion.Euler(0, 0, angleFacingLeft)
        );
    }

}
