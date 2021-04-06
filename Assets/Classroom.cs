using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classroom : MonoBehaviour
{
    public Transform[] desks = new Transform[12];
    public bool[] isDeskAvailble = new bool[12];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < desks.Length; i++)
        {
            isDeskAvailble[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Transform AskForSeat()
    {
        for(int i = 0; i < desks.Length; i++)
        {
            if(isDeskAvailble[i])
            {
                isDeskAvailble[i] = false;
                return desks[i];
            }
        }

        return null;
    }

    public void EmptySeats()
    {
        for (int i = 0; i < desks.Length; i++)
        {
            isDeskAvailble[i] = true;
        }
    }
    
}
