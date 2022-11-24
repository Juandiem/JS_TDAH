using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CursorGame : MonoBehaviour
{
    public GameObject mainArea, cursorArea, cursor, blurr;
    public HealthBar healthBar;
    public Text currentTurn, myTurn;

    public float radiusMainArea = 130.0f, radiusCursorArea = 85.0f;

    public int maxHealth, currentHealth;
    public int damage;
    public float cd_dmgTime = 0.1f, cd_dirTime = 1.2f, cd_turnMinTime = 2.0f, cd_turnMaxTime = 8.0f;
    public float clickMultiplier, penaltyMultiplier;

    float dmg_time, dir_time, turnTime;
    float cd_turnTime;
    float factorScaleArea = 1.0f;

    int turnTries = -1, turnTriesMax;

    Vector3 cursorAreaIniScale;
    Vector3 randomMove;

    bool endGame = false;

    // Start is called before the first frame update
    void Start()
    {
        dmg_time = cd_dmgTime;
        dir_time = cd_dirTime;
        cd_turnTime = (float)Random.Range(cd_turnMinTime, cd_turnMaxTime);
        turnTime = cd_turnTime;

        healthBar.SetMaxHealth(maxHealth);
        cursorAreaIniScale = cursorArea.transform.localScale;

        myTurn.text = createNewNumber(9);

        turnTriesMax = Random.RandomRange(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (!endGame)
        {
            if (healthBar.getHealth() <= 0 || isSameTurn())
            {
                //terminar juego
                if (!isSameTurn())
                    Debug.Log("No tan Fino");
                else
                    Debug.Log("Fino");
                endGame = true;
            }
            else
            {
                checkCursorArea();
                checkMoveArea();
                updateTurn();

                moveArea();
                scaleArea();
            }
        }
        else
        {
            SceneManager.LoadScene(0);
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
        if (dir_time >= cd_dirTime)
        {
            dir_time = 0.0f;
            randomMove = new Vector3((float)(Random.Range(-10, 20) / 100.0f), (float)(Random.Range(-10, 20) / 100.0f), 0);

            cursorArea.transform.localPosition += randomMove;
        }
        else
            dir_time += Time.deltaTime;
    }

    void updateTurn()
    {
        if (turnTries >= turnTriesMax)
            currentTurn.text = myTurn.text;
        else
        {
            if (turnTime >= cd_turnTime)
            {
                turnTime = 0.0f;
                currentTurn.text = createNewNumber(9);
                turnTries++;

                cd_turnTime = (float)Random.Range(cd_turnMinTime, cd_turnMaxTime);
            }
            else
                turnTime += Time.deltaTime;
        }
    }

    bool isSameTurn()
    {
        return(currentTurn.text == myTurn.text && !blurr.activeSelf) ;
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
        Vector3 newScale = cursorAreaIniScale * factorScaleArea;
        cursorArea.transform.localScale = newScale;
    }

    public void takeDamage(int dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0) currentHealth = 0;
        healthBar.setHealth(currentHealth);
    }

    string createNewNumber(int digits)
    {
        string number = "";
        
        for(int i = 0; i <= digits; i++)
        {
            string c = Random.Range(0, 10).ToString();
            number += c;
        }
        return number;
    }
}
