using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun, IPunObservable
{
    public PhotonView pv;
    public Character character;

    public Vector3 positionNext;

    void Start()
    {
        if (!pv.IsMine)
        {
            //character.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (pv.IsMine)
        {

        }*/
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            positionNext = (Vector3)stream.ReceiveNext();
        }
    }
}
