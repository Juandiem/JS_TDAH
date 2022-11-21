using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGame : MonoBehaviour
{
    public GameObject mainArea, cursorArea, cursor;
    public HealthBar healthBar;

    public float radiusMainArea = 130.0f, radiusCursorArea = 85.0f;

    public int maxHealth, currentHealth;
    public int damage;
    public float cd_dmgTime = 0.1f, cd_changeDir = 1.2f;
    public float clickMultiplier, penaltyMultiplier;

    float dmg_time, dir_time;
    float factorScaleArea = 1.0f;

    Vector3 cursorAreIniScale;
    Vector3 randomMove;


    // Start is called before the first frame update
    void Start()
    {
        dmg_time = cd_dmgTime;
        dir_time = 0.0f;
        healthBar.SetMaxHealth(maxHealth);
        cursorAreIniScale = cursorArea.transform.localScale;

        randomMove = new Vector3((float)(Random.Range(-10, 20) / 100.0f), (float)(Random.Range(-10, 20) / 100.0f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.getHealth() <= 0)
        {
            //terminar juego
        }
        else
        {
            checkCursorArea();
            checkMoveArea();

            moveArea();
            scaleArea();
        }
    }

    public bool isInMainArea(Vector3 pos)
    {
        float distance = Vector3.Distance(mainArea.transform.position, pos);

        return distance < radiusMainArea;
    }

    void checkCursorArea()
    {
        if (dmg_time >= cd_dmgTime)
        {
            float distance = Vector3.Distance(cursorArea.transform.position, cursor.transform.position);
            if (distance >= radiusCursorArea * factorScaleArea)
            {
                takeDamage(damage);
                dmg_time = 0.0f;
            }
        }
        else
            dmg_time += Time.deltaTime;
    }

    void checkMoveArea()
    {
        if (dir_time >= cd_changeDir)
        {
            dir_time = 0.0f;
            randomMove = new Vector3((float)(Random.Range(-10, 20) / 100.0f), (float)(Random.Range(-10, 20) / 100.0f), 0);

            cursorArea.transform.localPosition += randomMove;
        }
        else
            dir_time += Time.deltaTime;
    }

    void moveArea()
    {
        float distance = Vector3.Distance(mainArea.transform.position, cursorArea.transform.position) 
            + radiusCursorArea*factorScaleArea;
        if (distance < radiusMainArea)
        {
            cursorArea.transform.localPosition += randomMove;
        }
        else
        {
            randomMove = -randomMove.normalized*0.15f;
            cursorArea.transform.localPosition += randomMove;
        }
    }

    void scaleArea()
    {
        if (Input.GetMouseButtonDown(0))
        {
            factorScaleArea += 0.1f * clickMultiplier;
            if(factorScaleArea > .7f) 
                factorScaleArea = .7f;
        }
        else
        {
            factorScaleArea -= Time.deltaTime*penaltyMultiplier;
            if (factorScaleArea < 0.3f)
                factorScaleArea = 0.3f;
        }
        Vector3 newScale = cursorAreIniScale * factorScaleArea;
        cursorArea.transform.localScale = newScale;
    }

    public void takeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0) currentHealth = 0;
        healthBar.setHealth(currentHealth);
    }
}
