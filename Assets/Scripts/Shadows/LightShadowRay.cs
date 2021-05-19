using UnityEngine;

public class LightShadowRay : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject player;
    public float lightRadius;
    private Vector3 origin;
    private int closesLighttIndex;
    private ControlAndMovement control;
    private MeshRenderer mesh;

    void Start()
    {
        origin = Vector3.zero;
        mesh = GetComponent<MeshRenderer>();
        control = player.GetComponent<ControlAndMovement>();
        mesh.enabled = false;
        lightRadius = 30f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayCastLightShadow();
    }

    public void RayCastLightShadow()
    {
        float closestDistance = Mathf.Infinity;
        int closestLightId = 0;

        for (int i = 0; i < lights.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, lights[i].transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestLightId = i;
            }
        }

        origin = lights[closestLightId].transform.position;
       
        if (Physics.Linecast(origin, transform.position, out RaycastHit hit))
        {
            //Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("Shadow") && (closestDistance < lightRadius))
            {
                RayCastShadowPlayer();
            }
            else
            {
                mesh.enabled = false;
            }

        }
        Debug.DrawRay(origin, transform.position - origin);
    }

    public void RayCastShadowPlayer()
    {
        if (Physics.Linecast(transform.position, player.transform.position, out RaycastHit HitPlayer))
        {
            //Debug.Log(HitPlayer.collider.tag);
            if (HitPlayer.collider.gameObject.CompareTag("Player"))
            {
                mesh.enabled = true;
                if (this.transform.name == "Shadow - Cat")
                {
                    control.CanSeeShadow();
                }
            }
            else
            {
                mesh.enabled = false;
                //control.sawShadow = false;
            }

        }
        Debug.DrawRay(transform.position, player.transform.position - transform.position);
    }

}