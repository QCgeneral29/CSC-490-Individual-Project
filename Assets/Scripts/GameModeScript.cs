using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeScript : MonoBehaviour
{
    public float StartingInfectedChance = 0.05f;
    public float InfectionRisk = 0.50f;
    public float SocialDistance = 3f;
    public float InfectionRadius = 1.5f;
    public int MaxClasses = 7;
    public int currentClass = 0;

    public GameObject[] classrooms = new GameObject[7];

    private GameObject[] people;

    // Start is called before the first frame update
    void Start()
    {
        people = GameObject.FindGameObjectsWithTag("Person");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform AskForClassroom()
    {
        for(int i = 0; i < classrooms.Length; i ++)
        {
            Transform seat = classrooms[i].GetComponent<Classroom>().AskForSeat();
            if (seat != null) return seat;
        }

        return null;
    }

    public void NextClass()
    {
        currentClass++;
        shufflePeople();

        for (int i = 0; i < people.Length; i++)
        {
            people[i].GetComponent<Health>().RefreshVariables();
        }

        for (int i = 0; i < classrooms.Length; i++)
        {
            classrooms[i].GetComponent<Classroom>().EmptySeats();
            
        }

        for (int i = 0; i < people.Length; i++)
        {
            people[i].GetComponent<AIController>().NextClass();
        }
    }

    // https://stackoverflow.com/questions/273313/randomize-a-listt
    private void shufflePeople()
    {
        System.Random rand = new System.Random();

        int n = people.Length;
        while(n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            GameObject person = people[k];
            people[k] = people[n];
            people[n] = person;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("School");
    }
}
