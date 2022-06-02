// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectAndJoinRandom.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Utilities, 
// </copyright>
// <summary>
//  Simple component to call ConnectUsingSettings and to get into a PUN room easily.
// </summary>
// <remarks>
//  A custom inspector provides a button to connect in PlayMode, should AutoConnect be false.
//  </remarks>                                                                                               
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

using UnityEngine;

//using Photon.Pun;
using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
    /// <summary>Simple component to call ConnectUsingSettings and to get into a PUN room easily.</summary>
    /// <remarks>A custom inspector provides a button to connect in PlayMode, should AutoConnect be false.</remarks>
    public class ConnectAndJoinRandom : MonoBehaviourPunCallbacks
    {
        /// <summary>Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts.</summary>
        /// <summary>Used as PhotonNetwork.GameVersion.</summary>
        /// <summary>Max number of players allowed in room. Once full, a new room will be created by the next connection attemping to join.</summary>
        [Tooltip(
            "The max number of players allowed in room. Once full, a new room will be created by the next connection attemping to join.")]
        // below, we implement some callbacks of the Photon Realtime API.
        // Being a MonoBehaviourPunCallbacks means, we can override the few methods which are needed here.
        // the following methods are implemented to give you some context. re-implement them as needed.
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("OnDisconnected(" + cause + ")");
        }
    }
}
