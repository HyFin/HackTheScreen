using System.Collections;
using System.Collections.Generic;
using VRTK.Controllables.PhysicsBased;
using UnityEngine;

public class DoorLock : MonoBehaviour {

    new Collider collider;
    public VRTK_PhysicsRotator[] Rotate;
    bool isAKey = false;

    bool KeyCollision(Collider target)
    {
        if (target.gameObject.tag.Equals("key"))
        {
            return true;
        }
        return false;
    }

    void setDoorState(bool boolState)
    {
        foreach(VRTK_PhysicsRotator X in Rotate)
        {
            X.isLocked = boolState;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("key"))
        {
            isAKey = true;
        }
    }

    // Use this for initialization
    void Start () {
        setDoorState(true);
        collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    collider = GetComponent<Collider>();
        //    collider.enabled = false;
        //    setDoorState(false);
        //}
        OnTriggerEnter(collider);
        if (isAKey)
        {
            collider.enabled = false;
            setDoorState(false);
        }
    }
}
