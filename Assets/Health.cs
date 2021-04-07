using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    // Component Variables
    private GameObject gameMode;
    private GameModeScript gameModeScript;
    public Material greenMaterial;
    public Material redMaterial;
    private MeshRenderer meshRenderer;
    private NavMeshAgent socialDistanceCollider;
    private SphereCollider infectionCollider;

    // Inital Variables. Will be changed by gamemode
    public bool isInfected = false;
    public float socialDistance = 3f;
    public float infectionRisk = 0.50f;
    public float infectionRadius = 3f;

    private bool infectOnce = true;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gameMode = GameObject.Find("GameMode");
            gameModeScript = gameMode.GetComponent<GameModeScript>();
            
        }catch(System.NullReferenceException e)
        {
            Debug.LogError(e);
        }

        meshRenderer = this.GetComponent<MeshRenderer>();
        socialDistanceCollider = this.GetComponent<NavMeshAgent>();
        infectionCollider = this.GetComponent<SphereCollider>();

        if (gameMode != null)
        {
            // Roll to see if this pawn should start infected or not
            float infectRoll = Random.Range(1,100);
            if (infectRoll < (gameModeScript.StartingInfectedChance * 100) )
            {
                this.isInfected = true;
            }

            // Set other variables decided in GameMode
            this.infectionRisk = gameModeScript.InfectionRisk;
            this.socialDistance = gameModeScript.SocialDistance;
            this.infectionRadius = gameModeScript.InfectionRadius;

            socialDistanceCollider.radius = socialDistance;
            infectionCollider.radius = infectionRadius;
        }
        else
        {
            // If gamemode is not found, set defaults
            Debug.LogError(this.name + " says GameMode empty not found!");
            socialDistanceCollider.radius = socialDistance;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInfected)
        {
            meshRenderer.material = redMaterial;
        }else
        {
            meshRenderer.material = greenMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Person")
        {
            if (infectOnce)
            {
                Health otherHealthScript = other.GetComponent<Health>();

                if (this.isInfected && !otherHealthScript.isInfected)
                {
                    infectOnce = false;
                    float infectRoll = Random.Range(1, 100);
                    if (infectRoll < (infectionRisk * 100)) otherHealthScript.isInfected = true;
                    //Debug.Log(infectRoll);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        infectOnce = true;
    }
}
