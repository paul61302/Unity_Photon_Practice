using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    [Header("玩家預置物")]
    public GameObject prefabPlayer1;
    //public GameObject prefabPlayer2;
    Vector3 player1Position = new Vector3(-205, 14, 0);
    Vector3 player2Position = new Vector3(205, 14, 0);

    public GameObject canvas;


    /// <summary>
    /// 生成玩家物件
    /// </summary>
    private void SpawnPlayer()
    {
        int PlayersInRoom = PhotonNetwork.CountOfPlayersInRooms;
        if(PlayersInRoom == 0)
        {
            GameObject Player1 = PhotonNetwork.Instantiate(prefabPlayer1.name, Vector3.zero, Quaternion.Euler(0,180,0));
            Player1.transform.parent = canvas.transform;
            Player1.transform.localPosition = player1Position;
            Player1.transform.localScale = new Vector3(3, 3, 3);
        }
        else if(PlayersInRoom == 1)
        {
            GameObject Player2 = PhotonNetwork.Instantiate(prefabPlayer1.name, Vector3.zero, Quaternion.identity);
            Player2.transform.parent = canvas.transform;
            Player2.transform.localPosition = player2Position;
            Player2.transform.localScale = new Vector3(3, 3, 3);
        }
        
    }

    /*public void WearGlasses(int index)
    {
        prefabPlayer1.GetComponent<Property>().ChGlasses(index);
    }*/

    private void Start()
    {
        SpawnPlayer();
        //ChangeGlasses();
    }

    public void OnEvent(EventData photonEvent)
    {
        
    }

    public override void OnEnable()

    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}
