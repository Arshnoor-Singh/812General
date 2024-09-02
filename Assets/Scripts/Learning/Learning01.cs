using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning01 : MonoBehaviour
{
    int number1 = 15;
    int number2 = 0;
    float number03 = 67f;
    string word = "stop talking";
    bool condition = true;

    private void Start()
    {
        DoSomeMath(45, 55);
    }

    bool DoSomeMath(int _parameter01, int _parameter02)
    {
        if(_parameter02 >= _parameter01)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
}
