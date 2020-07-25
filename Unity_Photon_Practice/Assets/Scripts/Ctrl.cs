using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl : MonoBehaviour
{
    public GameObject player;
    

    public void WearGlasses1(int index)
    {
        player.GetComponent<Character>().ChGlasses(index);
    }
}
