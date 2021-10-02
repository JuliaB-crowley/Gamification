using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Ennemies
{
    public GameObject shooterAmmo;
    public float timeBetweenShots, distanceEnnemyAmmo;
    bool isAbleToShoot = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 decalage = (playerCoordinates - transform.position).normalized * distanceEnnemyAmmo;
        if (isAbleToShoot == true)
        {
            isAbleToShoot = false;
            StartCoroutine(ShootCooldownCoroutine());
            Instantiate(shooterAmmo, transform.position + decalage, Quaternion.identity);
        }
    }

    IEnumerator ShootCooldownCoroutine()
    {
        yield return new WaitForSecondsRealtime(timeBetweenShots);
        isAbleToShoot = true;
    }
}
