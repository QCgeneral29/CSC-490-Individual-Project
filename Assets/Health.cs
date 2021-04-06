using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GameObject gameMode;
    private GameModeScript gameModeScript;

    private bool isInfected = false;
    public float socialDistance = 3f;
    public Material greenMaterial;
    public Material redMaterial;
    private MeshRenderer meshRenderer;

    private BoxCollider socialDistanceCollider;

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
        socialDistanceCollider = this.GetComponent<BoxCollider>();

        if (gameMode != null)
        {

        }else
        {
            Debug.LogError(this.name + " says GameMode empty not found!");
            socialDistanceCollider.size = new Vector3(socialDistance, 2, socialDistance);
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
}
