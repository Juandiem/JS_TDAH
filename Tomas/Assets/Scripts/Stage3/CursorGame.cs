using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGame : MonoBehaviour
{
    public GameObject mainArea;
    public GameObject cursorArea;
    public GameObject cursor;
    public HealthBar healthBar;

    public float radiusMainArea = 130.0f;
    public float radiusCursorArea = 85.0f;

    public int maxHealth;
    public int currentHealth;

    public int damage;

    public float cd_dmgTime = 0.1f;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = cd_dmgTime;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.getHealth() <= 0)
        {
            //terminar juego
        }
        else
        {
            if (time >= cd_dmgTime)
                checkCursorArea();
            else
                time += Time.deltaTime;
        }
    }

    public bool isInMainArea(Vector3 pos)
    {
        float distance = Vector3.Distance(mainArea.transform.position, pos);

        return distance < radiusMainArea;
    }

    void checkCursorArea()
    {
        float distance = Vector3.Distance(cursorArea.transform.position, cursor.transform.position);
        if (distance >= radiusCursorArea)
        {
            takeDamage(damage);
            time = 0.0f;
        }
    }

    public void takeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0) currentHealth = 0;
        healthBar.setHealth(currentHealth);
    }
}
