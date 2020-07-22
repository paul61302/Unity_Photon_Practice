using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Header("輸出文字")]
    public Text textPrint;

    public InputField playerIF;
    public InputField roomCreateIF;
    public InputField roomJoinIF;

    public string namePlayer, nameCreateRoom, nameJoinRoom;

    public string NamePlayer { get => namePlayer; set => namePlayer=value; }
    public string NameCreateRoom { get => nameCreateRoom; set => nameCreateRoom = value; }
    public string NameJoinRoom { get => nameJoinRoom; set => nameJoinRoom = value; }

    private void Start()
    {
        
    }

    public void Connect()
    {
        
    }
}
