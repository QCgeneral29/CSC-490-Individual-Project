using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private GameObject gameMode;
    private GameModeScript gameModeScript;

    public Text currentClass;

    public Text InfectionRiskText;
    public Text InfectionRadiusText;
    public Text StartingInfectionChanceText;
    public Text SocialDistanceText;

    public Slider InfectionRiskSlider;
    public Slider InfectionRadiusSlider;
    public Slider StartingInfectionChanceSlider;
    public Slider SocialDistanceSlider;

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

        InfectionRiskText.text = "Infection Risk: " + System.Math.Round(InfectionRiskSlider.value * 100) + "%";
        StartingInfectionChanceText.text = "Initial Infect Chance: " + System.Math.Round(StartingInfectionChanceSlider.value * 100) + "%";

        InfectionRadiusText.text = "Infection Radius: " + System.Math.Round(InfectionRadiusSlider.value * 100) / 100;
        SocialDistanceText.text = "Social Distance: " + System.Math.Round(SocialDistanceSlider.value * 100) / 100;
    }
}
