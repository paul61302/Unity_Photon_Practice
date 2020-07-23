using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [Header("玩家預置物")]
    public GameObject prefabPlayer1;
    //public GameObject prefabPlayer2;
    Vector3 player1Position = new Vector3(-205, 14, 0);
    Vector3 player2Position = new Vector3(205, 14, 0);

    public GameObject canvas;

    public Sprite[] Glasses;
    

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
            print(player1Position);
        }
        else if(PlayersInRoom == 1)
        {
            GameObject Player2 = PhotonNetwork.Instantiate(prefabPlayer1.name, Vector3.zero, Quaternion.identity);
            Player2.transform.parent = canvas.transform;
            Player2.transform.localPosition = player2Position;
        }
        
    }

    private void Start()
    {
        SpawnPlayer();
        //ChangeGlasses();
    }

    public void ChangeGlasses(int i)
    {        
        GameObject Character1 = canvas.transform.GetChild(6).gameObject;
        GameObject glasses = Character1.transform.GetChild(5).gameObject;
        glasses.GetComponent<Image>().sprite = Glasses[i];
    }
}
