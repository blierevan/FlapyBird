using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDisplay : MonoBehaviour
{
    TextMeshProUGUI TMP;
    [SerializeField] FlappyMovementBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        TMP.text = player.score.ToString();
    }
}