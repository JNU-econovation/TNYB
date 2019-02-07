using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    private string name;
    private string email;
    private int score_cashier;
    private int score_cinema;
    private int score_factory;
    private int money;
    
    public User(string name, string email)
    {
        this.name = name;
        this.email = email;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
