using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public DriveCar Controller;
    //public UIManager UI_Manager;
    [SerializeField] GameObject game;
    [SerializeField] Vector3 where;
    Rigidbody2D rb;
    private void Start()
    {
        rb = game.GetComponent<Rigidbody2D>();
    }
    /*private void Update()
    {
        where = Controller.respawnPoint;
    }*/
    public void UpdateRespawnPoint(Vector3 newRespawnPoint)
    {
        where = newRespawnPoint;
    }
    public void CheckPoint()
    {
        //game.SetActive(true);
        if (game.activeInHierarchy)
        {
            game.transform.position = where;
            game.transform.rotation = Quaternion.identity;
            
            if (rb == null)
            {
                rb = game.GetComponent<Rigidbody2D>();
                print("done");
            }
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                rb.angularVelocity = 0;
                rb.isKinematic = true;
                Invoke("NotKine", 1f);
            }
            else
            {
                print("null");
            }
        }
    }
    void NotKine()
    {
        rb.isKinematic = false;
    }
}
