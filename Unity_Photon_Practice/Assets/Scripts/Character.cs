using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class Character : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView pv;

    public Vector3 positionNext;    

    public Sprite[] Glasses;
    public Image NewGlasses;



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
        if (!pv.IsMine)
        {
            gameObject.transform.parent = FindObjectOfType<Canvas>().transform;
            gameObject.transform.localPosition = positionNext;
        }
        else
        {

        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.localPosition);
            //stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            positionNext = (Vector3)stream.ReceiveNext();
            print(positionNext);
        }
    }

    public void ChGlasses(int glasses)
    {
        pv.RPC("RPCChangeGlasses", RpcTarget.All, glasses);
    }

    [PunRPC]
    public void RPCChangeGlasses(int i)
    {
        NewGlasses.sprite = Glasses[i];
    }


}
