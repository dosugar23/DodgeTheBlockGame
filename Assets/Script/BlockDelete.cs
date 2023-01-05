using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDelete : MonoBehaviour {

    public float gravitySpeedRateAdd = 10f;
    public float deleteAt = -10f;
    [SerializeField] private AudioSource deleteSound;

    void Start() {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / gravitySpeedRateAdd;
        //Debug.Log(GetComponent<Rigidbody2D>().gravityScale);
    }

    void Update() {
        if (transform.position.y < deleteAt) {
            
            Destroy(gameObject);
            deleteSound.Play();
        }
    }
}