using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private GameObject gameMode;
    private GameModeScript gameModeScript;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();

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
        
    }

    public void NextClass()
    {
        navMeshAgent.SetDestination(gameModeScript.AskForClassroom().position);
    }
}
