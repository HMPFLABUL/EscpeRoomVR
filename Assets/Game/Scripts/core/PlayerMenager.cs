using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMenager : MonoBehaviour {

    public GameObject player;
    public GameObject pointsObj;
    private StandingPoint[] points;
    public StandingPoint begining;
    public float speed;
    public GameObject raycster;
    // Use this for initialization
    void Start () {
        points = pointsObj.GetComponentsInChildren<StandingPoint>();
        MovePlayer(begining);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MovePlayer(StandingPoint pt)
    {
        foreach(StandingPoint p in points)
        {
            p.gameObject.SetActive(true);
        }
        pt.gameObject.SetActive(false);
        StartCoroutine(Move(new Vector3(pt.transform.position.x,DataPlayer.playerHeight,pt.transform.position.z)));
        DataPlayer.playerActPoint = pt.point;
        MakroItemMenager.playerMoved = true;
    }
    private IEnumerator Move(Vector3 endPoint)
    {
        raycster.GetComponent<PhysicsRaycaster>().enabled = false;
        while ( player.transform.position != endPoint)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, endPoint, speed * Time.deltaTime);
            yield return null;
        }
        yield return null;
        raycster.GetComponent<PhysicsRaycaster>().enabled = true;
    }
}
