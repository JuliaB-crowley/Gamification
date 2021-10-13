using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int lifePoints;
    int actualLife;
    public Text lifeText, scoreText;
    public float fireBallCooldown, shieldCooldown, shieldDuration, invincibilityFramesDuration, timeInvincibility;
    bool canUseFireball = true, canUseShield = true, shieldIsInUse = false, isInInvicibility = false;
    int numberOfKills;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = lifePoints;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = (actualLife + " / " + lifePoints);
        scoreText.text = ("Score : " + numberOfKills);
    }

    public void TakeDamages()
    {
        if (shieldIsInUse == false)
        {
            if (isInInvicibility == false)
            {
                isInInvicibility = true;
                StartCoroutine(InvincibilityCoroutine());
                actualLife--;
                if (actualLife <= 0)
                {
                    //gameover
                }
            }
        }
    }
    IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSecondsRealtime(invincibilityFramesDuration);
        isInInvicibility = false;
    }

    public void FireBall()
    {
        if (canUseFireball)
        {
            canUseFireball = false;
            GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
            GameObject[] ammos = GameObject.FindGameObjectsWithTag("Ammo");
            foreach (GameObject ennemy in ennemies)
            {
                ennemy.GetComponent<Ennemies>().Die();
            }
            foreach(GameObject ammo in ammos)
            {
                ammo.GetComponent<Ammos>().Destroying();
            }
            StartCoroutine(FireBallCooldown());
        }

    }

    IEnumerator FireBallCooldown()
    {
        yield return new WaitForSecondsRealtime(fireBallCooldown);
        canUseFireball = true;
        
    }

    public void Shield()
    {
        if (canUseShield == true)
        {
            Debug.Log("Shield is in use");
            canUseShield = false;
            shieldIsInUse = true;
            StartCoroutine(ShieldDuration());
            StartCoroutine(ShieldCooldown());
        }
    }

    IEnumerator ShieldDuration()
    {
        yield return new WaitForSecondsRealtime(shieldDuration);
        Debug.Log("Shield is off");
        shieldIsInUse = false;
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSecondsRealtime(shieldCooldown);
        canUseShield = true;
    }

    public void UpdateScore()
    {
        numberOfKills++;
    }
}
