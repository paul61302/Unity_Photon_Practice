using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    public PhotonView pv;
    public Character character;

    void Start()
    {
        if (!pv.IsMine)
        {
            character.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
