using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int lifePoints;
    int actualLife;
    public Text lifeText;
    public float fireBallCooldown, shieldCooldown, shieldDuration;
    bool canUseFireball = true, canUseShield = true, shieldIsInUse = false;
    // Start is called before the first frame update
    void Start()
    {
        actualLife = lifePoints;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = (actualLife + " / " + lifePoints);
    }

    public void TakeDamages()
    {
        if (shieldIsInUse == false)
        {
            actualLife--;
            if (actualLife <= 0)
            {
                //gameover
            }
        }
    }

    public void FireBall()
    {
        if (canUseFireball)
        {
            canUseFireball = false;
            GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");
            foreach (GameObject ennemy in ennemies)
            {
                ennemy.GetComponent<Ennemies>().Die();
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
            canUseShield = false;
            shieldIsInUse = true;
            StartCoroutine(ShieldDuration());
            StartCoroutine(ShieldCooldown());
        }
    }

    IEnumerator ShieldDuration()
    {
        yield return new WaitForSecondsRealtime(shieldDuration);
        shieldIsInUse = false;
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSecondsRealtime(shieldCooldown);
        canUseShield = true;
    }
}
