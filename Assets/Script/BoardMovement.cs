using UnityEngine;

public class BoardMovement : MonoBehaviour {
  public Transform[] waypoints;

  [SerializeField]
  private float moveSpeed = 1f;

  [HideInInspector]
  public int waypointIndex = 0;

  public bool moveAllowed = false;

  private void Start(){
    transform.position = waypoints[waypointIndex].transform.position;
  }

  private void Update(){
    if(moveAllowed){
      Move();
    }
  }

  private void Move(){
    if(waypointIndex <= waypoints.Length - 1){
      // transform.positon = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

      // TODO: when player reaches end, clear off path and add one point.
      if(transform.position == waypoints[waypointIndex].transform.position){
        waypointIndex += 1;
      }
    }
  }
}
