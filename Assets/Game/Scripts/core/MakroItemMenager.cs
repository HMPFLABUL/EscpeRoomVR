using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MakroItemMenager : MonoBehaviour {

    private BigObject actualBigObj;
    public GameObject player;
    public GameObject backButton;
    public GameObject makroParent;
    private BigObject[] makroObjects;
    public GameObject standingParent;
    private StandingPoint[] standingObjects;
    private Vector3 playerPrevPos;
    public  GameObject raycster;
    [HideInInspector]
    public static bool playerMoved;

	// Use this for initialization
	void Start () {
        playerMoved = true;
       makroObjects = makroParent.GetComponentsInChildren<BigObject>(true);
       standingObjects = standingParent.GetComponentsInChildren<StandingPoint>(true);
     //  PlayerMoved();
        //  player
    }
	
	// Update is called once per frame
	void Update () {
        if (playerMoved)
            PlayerMoved();
	}
    
    public void MakroObjClick(BigObject BigObj)
    {
        actualBigObj = BigObj;

        var allChildren = actualBigObj.GetComponentsInChildren<Collider>();
        foreach (Collider child in allChildren)
        {
            // do whatever with child transform here
            child.enabled = true;
        }
        // actualBigObj.GetComponent<BoxCollider>().enabled = false;
        foreach (BigObject obj in makroObjects)
        {
            // do whatever with child transform here
            obj.GetComponent<Collider>().enabled = false;
        }
        foreach (StandingPoint obj in standingObjects)
        {
            // do whatever with child transform here
            obj.GetComponent<Collider>().enabled = false;
        }



        playerPrevPos = player.transform.position;
        //player.transform.position = actualBigObj.playerPosition;
        Vector3 playerPos = new Vector3(actualBigObj.transform.position.x+actualBigObj.playerPosition.x, DataPlayer.playerHeight, actualBigObj.transform.position.z + actualBigObj.playerPosition.z);
        StartCoroutine(MovePlayer(playerPos));
        
    }

    public void BackButtonClick()
    {
        var allChildren = actualBigObj.GetComponentsInChildren<Collider>();
        foreach (Collider child in allChildren)
        {
            // do whatever with child transform here
            child.enabled = false;
        }
        foreach (BigObject obj in makroObjects)
        {
            
            // do whatever with child transform here
            obj.GetComponent<Collider>().enabled = true;

        }
        foreach (StandingPoint obj in standingObjects)
        {
            // do whatever with child transform here
            obj.GetComponent<Collider>().enabled = true;
        }

        StartCoroutine(MovePlayerBack(playerPrevPos));
        
        //player.transform.position = new Vector3(0f,1.6f,0f);
    }

    IEnumerator MovePlayer(Vector3 end)
    {
        raycster.GetComponent<PhysicsRaycaster>().enabled = false;
        
        while (player.transform.position != end)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, end, 6f * Time.deltaTime);
            yield return null;
        }
        raycster.GetComponent<PhysicsRaycaster>().enabled = true;
        backButton.SetActive(true);
        yield return null;
    }
    IEnumerator MovePlayerBack(Vector3 end)
    {
        backButton.SetActive(false);
        raycster.GetComponent<PhysicsRaycaster>().enabled = false;

        while (player.transform.position != end)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, end, 6f * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        raycster.GetComponent<PhysicsRaycaster>().enabled = true;
    }

    public void PlayerMoved()
    {
        playerMoved = false;
        DataPlayer.StandingPoints temp = DataPlayer.playerActPoint;
        foreach (BigObject obj in makroObjects)
        {
            foreach (DataPlayer.StandingPoints pt in obj.avaiblePoints)
            {
                if (temp != pt)
                    obj.GetComponent<Collider>().enabled = false;
                else
                    obj.GetComponent<Collider>().enabled = true;
            }
        }
        
    }
}
