using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Property : MonoBehaviour
{
    public PhotonView pv;
    public Sprite[] Glasses;
    public Image NewGlasses;



    public void ChGlasses(int glasses)
    {
        NewGlasses.sprite = Glasses[glasses];
        //pv.RPC("RPCChangeGlasses", RpcTarget.All, glasses);
    }

    /*[PunRPC]
    public void RPCChangeGlasses(int index)
    {
        NewGlasses.sprite = Glasses[index];
    }*/

}
