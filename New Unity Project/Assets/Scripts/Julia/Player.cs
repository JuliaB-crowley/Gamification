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
    public Image spriteBouclier, spriteBoule;
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
            spriteBoule.color = new Color(1,1,1,0.2f);
            StartCoroutine(FireBallCooldown());
        }

    }

    IEnumerator FireBallCooldown()
    {
        StartCoroutine(FadeTo(1, fireBallCooldown));
        yield return new WaitForSecondsRealtime(fireBallCooldown);
        canUseFireball = true;
        
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = spriteBoule.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            spriteBoule.color = newColor;
            yield return null;
        }
    }

    IEnumerator FadeToBouclier(float aValue, float aTime)
    {
        float alpha = spriteBouclier.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            spriteBouclier.color = newColor;
            yield return null;
        }
    }

    public void Shield()
    {
        if (canUseShield == true)
        {
            Debug.Log("Shield is in use");
            canUseShield = false;
            shieldIsInUse = true;
            spriteBouclier.color = new Color(1, 1, 1, 0.2f);
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
        StartCoroutine(FadeToBouclier(1, shieldCooldown));
        yield return new WaitForSecondsRealtime(shieldCooldown);
        canUseShield = true;
    }

    public void UpdateScore()
    {
        numberOfKills++;
    }
}
