using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreStore : MonoBehaviour
{
    KeyValues kv;
    private void Start()
    {
        kv = KeyValues.Instance;
    }

    private void OnEnable()
    {
        kv.updateHighScore();
    }
}
