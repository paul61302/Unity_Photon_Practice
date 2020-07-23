using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Header("輸出文字")]
    public Text textPrint;
    [Header("輸入欄位")]
    public InputField playerIF;
    //public InputField roomCreateIF;
    //public InputField roomJoinIF;
    public InputField roomIF;
    public Button btnCreate, btnJoin;

    public string namePlayer, /*nameCreateRoom, nameJoinRoom*/nameRoom;

    public string NamePlayer { get => namePlayer; set => namePlayer=value; }
    //public string NameCreateRoom { get => nameCreateRoom; set => nameCreateRoom = value; }
    //public string NameJoinRoom { get => nameJoinRoom; set => nameJoinRoom = value; }
    public string NameRoom { get => nameRoom; set => nameRoom = value; }

    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();   // 連線到伺服器
        
    }

    public void BtnCreateRoom()
    {
        PhotonNetwork.CreateRoom(NameRoom, new RoomOptions { MaxPlayers = 4 });
    }

    public void BtnJoinRoom()
    {
        PhotonNetwork.JoinRoom(NameRoom);
    }

    public void BtnJoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        textPrint.text = "連線成功!";
        PhotonNetwork.JoinLobby();              // 加入大廳        
    }

    public override void OnJoinedLobby()
    {
        textPrint.text = "進入大廳!";
        playerIF.interactable = true;
        //roomCreateIF.interactable = true;
        //roomJoinIF.interactable = true;
        roomIF.interactable = true;
        btnCreate.interactable = true;
        btnJoin.interactable = true;
    }

    public override void OnCreatedRoom()
    {
        textPrint.text = "建立房間成功，房名為：" + NameRoom;
    }

    public override void OnJoinedRoom()
    {
        textPrint.text = "加入房間成功，房名為：" + NameRoom;
        PhotonNetwork.LoadLevel("Room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        textPrint.text = "加入房間失敗，Code：" + returnCode + "\n" + "錯誤訊息：" + message;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        textPrint.text = "加入房間失敗，Code：" + returnCode + "\n" + "錯誤訊息：" + message;
    }
}
