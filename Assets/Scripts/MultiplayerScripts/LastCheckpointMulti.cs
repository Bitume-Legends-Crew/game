using Photon.Pun;
using UnityEngine;

public class LastCheckpointMulti : MonoBehaviour
{
    public static bool PassedLastCheckpointPlayer = false;
    public bool FirstPass;
    public static PhotonView pv;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vehicle")
        {
            if (!FirstPass)
                FirstPass = true;
            
            if(FirstPass)
                PassedLastCheckpointPlayer = true;
        }

        pv = other.GetComponent<PhotonView>();
    }
}