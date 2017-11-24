using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human
{
    string firstname, lastname;
    private int age;

    public int Age { get; private set; }
    public string Firstname
    {
        get { return firstname;  }
        set
        {
            if (value.Length > 7)
                Firstname = value;
                
        }
    }


    public Human(string firstname, string lastname, int age)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.Age = age;
    }


}


public class StartScript : MonoBehaviour
{
    int i = 5;
    float f = 3.5f;
    string name = "Вася";
    public float speed = 0.1f;

	void Start ()
    { 
        Human human = new Human("Иван", "Иванов", 24);
        Debug.Log(human.Age);
        human.Firstname = "AAA";
        Debug.Log(human.Firstname);

        Debug.Log(6);


    }

    void Update ()
    {
        //i = i + 1;
        i += 1;
        //i++;
        Debug.Log(i);
        Debug.Log(name);

        transform.Translate(speed, 0.001f, 0);
        transform.Rotate(5, 10, 0);
        if (transform.position.y > 4)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            speed += 0.01f;
        }
    }


}



