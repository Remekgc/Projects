using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        print(Player.Lifes);
        Player.playerObject = gameObject;
    }
}
