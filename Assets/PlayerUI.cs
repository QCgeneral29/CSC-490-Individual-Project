using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private GameObject gameMode;
    private GameModeScript gameModeScript;

    public Text currentClass;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gameMode = GameObject.Find("GameMode");
            gameModeScript = gameMode.GetComponent<GameModeScript>();

        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentClass.text = "Current Class: " + gameModeScript.currentClass;
    }
}
