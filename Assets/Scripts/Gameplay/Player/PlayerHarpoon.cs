using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarpoon : MonoBehaviour
{
    public GameObject harpoon;  //el objecto harpoon
    public GameObject harpoonPosition;  //la posicion donde queremos que regrese el harpon
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(1))
        {
            RealeaseHarpoon();
        }
        if (Input.GetMouseButtonDown(2))
        {
            ReatachHarpoon();
        }
    }

    private void RealeaseHarpoon()
    {
        harpoon.transform.parent = null;
    }

    private void ReatachHarpoon()
    {
        harpoon.transform.parent = gameObject.transform;
        harpoon.transform.position = harpoonPosition.transform.position;
        harpoon.transform.rotation = harpoonPosition.transform.rotation;
    }
}
