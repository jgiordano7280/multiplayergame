using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class JoinGameButton : MonoBehaviour
{
    public void JoinGame()
    {
        NetworkManager.singleton.networkAddress = "localhost";
        NetworkManager.singleton.StartClient();
        transform.parent.gameObject.SetActive(false);
    }
}


