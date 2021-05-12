using UnityEngine;

public class LightShadowRay : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject player;

    private Vector3 origin;
    private int closesLighttIndex;
    private ControlAndMovement control;
    private MeshRenderer mesh;

    void Start()
    {
        origin = Vector3.zero;
        mesh = GetComponent<MeshRenderer>();
        control = player.GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayCastShadowPlayer();
    }

    public void RayCastShadowPlayer()
    {
        if (Physics.Linecast(transform.position, player.transform.position, out RaycastHit HitPlayer))
        {
            //Debug.Log(HitPlayer.collider.tag);
            if (HitPlayer.collider.gameObject.CompareTag("Player"))
            {
                //Debug.Log("VendoShadow");
                //Debug.Log(HitPlayer.collider.tag);
                RayCastLightShadow();
                //mesh.enabled = true;
            }

        }
        Debug.DrawRay(transform.position, player.transform.position - transform.position);
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
            if (hit.collider.gameObject.CompareTag("Shadow"))
            {
                //Debug.Log("CanSeeShadow");
                control.CanSeeShadow();
            }
        }
        Debug.DrawRay(origin,transform.position - origin);
    }

}
