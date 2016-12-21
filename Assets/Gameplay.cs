using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gameplay : MonoBehaviour {
    public GameObject central_obj;
    List<char> list = new List<char>();     //list of character
    int num_letter = 1;                     //number of letter
    int cur_i = 0;                          //current iteration
    int cur_simon = 0;
    public AudioClip[] letter_sound = new AudioClip[26];
    public AudioClip[] reward_sound = new AudioClip[2];
    List<int> num_list = new List<int>();
    AudioSource aud;
    int game_mode = 1;
    // Use this for initialization
    void Start () {

        aud = GetComponent<AudioSource>();

        central_obj = GameObject.FindGameObjectWithTag("Central");
        BaseFunction();
    }
	
    void BaseFunction()
    {
        for (int i = cur_simon; i < num_letter; i++)
        {
            int l = Random.Range(1, 27);
            char c = MakeLetter(l);
            Debug.Log(c);
            num_list.Add(l);
            list.Add(c);
        }
        PlaySound();
        central_obj.SendMessage("GetList1", list);
    }

    void PlaySound()
    {
        Debug.Log(cur_i);
        Debug.Log(num_letter);
        aud.clip = letter_sound[num_list[cur_i]-1];
        aud.Play();
        cur_i++;
       
        if (cur_i < num_letter)
        {
            Invoke("PlaySound", 1);
        }
        
    }

    char MakeLetter(int l)
    {
        
        char c = 'a' ;
        switch (l)
        {
            case 1:
                c = 'a';
                break;
            case 2:
                c = 'b';
                break;
            case 3:
                c = 'c';
                break;
            case 4:
                c = 'd';
                break;
            case 5:
                c = 'e';
                break;
            case 6:
                c = 'f';
                break;
            case 7:
                c = 'g';
                break;
            case 8:
                c = 'h';
                break;
            case 9:
                c = 'i';
                break;
            case 10:
                c = 'j';
                break;
            case 11:
                c = 'k';
                break;
            case 12:
                c = 'l';
                break;
            case 13:
                c = 'm';
                break;
            case 14:
                c = 'n';
                break;
            case 15:
                c = 'o';
                break;
            case 16:
                c = 'p';
                break;
            case 17:
                c = 'q';
                break;
            case 18:
                c = 'r';
                break;
            case 19:
                c = 's';
                break;
            case 20:
                c = 't';
                break;
            case 21:
                c = 'u';
                break;
            case 22:
                c = 'v';
                break;
            case 23:
                c = 'w';
                break;
            case 24:
                c = 'x';
                break;
            case 25:
                c = 'y';
                break;
            case 26:
                c = 'z';
                break;

        }
        return c;

    }

	// Update is called once per frame
	void Update () {
	
	}

    public void Receive(bool success)
    {
        if(success)
        {
            //do success stuff, increase score, play sound
            aud.clip = reward_sound[0];
            aud.Play();
            if (game_mode == 0)
            {
                list.Clear();
                num_list.Clear();
                cur_i = 0;
                num_letter++;
            }

            if (game_mode == 1)
            {
                cur_i = 0;
                cur_simon = num_letter;
                num_letter++;
            }
        }
        else
        {
            //play fail sound
            aud.clip = reward_sound[1];
            aud.Play();
            num_letter = 1;

            if (game_mode == 0)
            {
                list.Clear();
                num_list.Clear();
                cur_i = 0;
            }

            if (game_mode == 1)
            {
                list.Clear();
                num_list.Clear();
                cur_i = 0;
                cur_simon = 0;
            }
        }

        //reset list
       
        //go back to the beginning
        Invoke("BaseFunction",2);
    }
}
