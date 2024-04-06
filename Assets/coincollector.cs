using UnityEngine;

public class coincollector : MonoBehaviour
{
    // Start is called before the first frame update
    public float coin = 0;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "coin"){
            Destroy(other.gameObject);
            coin =coin + 0.5f;
        }
    }
}