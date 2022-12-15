using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPhoneQuest : Quest
{
    GameObject cellPhone;
    public CellPhoneQuest(GameObject gO)
    {
        this.cellPhone = gO;
        Start();
    }

    void Start()
    {
        Debug.Log("cellPhone assigned");
        title = "Encuentra el movil";
        description = "Busca movil en la oficina";

        goals.Add(new InteractWithGoal(cellPhone, "Encuentra el móvil", false, 0, 1));
        goals.Add(new TalkToMomGoal("Habla con mamá", false, 0, 1));


        cellPhone.SetActive(true);
    }
}
