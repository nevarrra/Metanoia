using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : StaticNPC
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoThoughSpeeches(this.ID);
    }
}
