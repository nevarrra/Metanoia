using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : StaticNPC
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoThoughSpeeches(this.ID);
    }
}
