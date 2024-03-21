using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HostGameButton : MonoBehaviour
{
    public void HostGame()
    {
        NetworkManager.singleton.StartHost();
        transform.parent.gameObject.SetActive(false);
    }
}

