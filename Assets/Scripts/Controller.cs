using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] public float CargoSpeed;
    [SerializeField] public float BlockerSpeed;
    [SerializeField] public float SliderSpeed;

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");              // [A/Left Arrow] -1 ---- 0 ---- 1 [D/Right Arrow]
        float y = Input.GetAxis("Vertical");                // [S/Down Arrow] -1 ---- 0 ---- 1 [W/Up Arrow]

        switch (x)          // Horizontal Input Check with Switch.
        {
            case 0f:        // If Horizontal Input equals zero, then break switch.
                break;
            default:        // Otherwise, add velocity to all Sliders.
                foreach (GameObject ga in GameObject.FindGameObjectsWithTag("Slider"))
                {
                    AddForwardVelocityToGameObject(ga, x, SliderSpeed);
                }
                foreach (GameObject gc in GameObject.FindGameObjectsWithTag("Blocker"))
                {
                    float rot = Mathf.Abs(gc.transform.rotation.eulerAngles.y);
                    if (rot == 90 || rot == 270)
                    {
                        AddForwardVelocityToGameObject(gc, x, BlockerSpeed);
                        Debug.Log("a");
                    }
                }
                break;
        }
        switch (y)          // Vertical Input Check with Switch.
        {
            case 0f:        // If Vertical Input equals zero, then break switch.
                break;
            default:        // Otherwise, add velocity to all Cargos and Blockers.
                foreach (GameObject gb in GameObject.FindGameObjectsWithTag("Cargo"))
                {
                    AddForwardVelocityToGameObject(gb, y, CargoSpeed);
                }
                foreach (GameObject gc in GameObject.FindGameObjectsWithTag("Blocker"))
                {
                    float rot = Mathf.Abs(gc.transform.rotation.eulerAngles.y);
                    if (rot == 0 || rot == 180)
                    {
                        AddForwardVelocityToGameObject(gc, y, BlockerSpeed);
                        Debug.Log("a");
                    }
                }
                break;
        }
    }

    private void AddForwardVelocityToGameObject(GameObject _GameObject, float _Axis, float _Speed)
    {
        _GameObject.GetComponent<Rigidbody>().velocity += _GameObject.GetComponent<Transform>().forward * _Axis * _Speed * Time.deltaTime;
        //Multiplying objects's forward vector by input axis and speed of object
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Ghost") && other.CompareTag("Slider") || other.CompareTag("Blocker") || other.CompareTag("Cargo"))
        {
            foreach (Lever button in FindObjectsOfType<Lever>())
            {
                button.canPush = false; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("Ghost") && other.CompareTag("Slider") && other.CompareTag("Blocker") || other.CompareTag("Cargo"))
        {
            foreach (Lever button in FindObjectsOfType<Lever>())
            {
                button.canPush = true;
            }
        }
    }
    // when Cargo or Blocker or Slider inside Ghost button can't push 


}
