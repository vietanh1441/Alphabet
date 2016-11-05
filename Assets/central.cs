﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Here there are 2 list, one generated by the game, one by user input
//check correctness by compare 2 queue
public class central : MonoBehaviour {

    public List<char> list1 = new List<char>();
    public List<char> list2 = new List<char>();
    
    public GameObject gameplay_obj;
    int num = 1;
    int cur = 0;
	// Use this for initialization
	void Start () {
        gameplay_obj = GameObject.FindGameObjectWithTag("GamePlay");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetList1(List<char> list)
    {
        list1.Clear();
        list2.Clear();
        cur = 0;
        foreach (char c in list)
        {
            list1.Add(c);
        }
        num = list1.Count;
    }
    public void Ex()
    {

    }

    public void UserInput(string c)
    {
        
        list2.Add(c[0]);
        cur++;
        if (cur == num)
        {
            Check();
        }
    }

    void Check()
    {
        for (int i = 0; i < num; i++)
        {
            if (list1[i] != list2[i])
            {
                Debug.Log("Fail");
                gameplay_obj.SendMessage("Receive", false);
                return;
            }
        };

        Debug.Log("Success");
        gameplay_obj.SendMessage("Receive", true);



    }
}
