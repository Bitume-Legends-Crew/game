using Photon.Pun;
using UnityEngine;
using Mirror;
using NWH.VehiclePhysics2.Sound.SoundComponents;

namespace NWH.VehiclePhysics2.Multiplayer
{
    /// <summary>
    /// Adds multi-player functionality to a vehicle through Mirror networking.
    /// </summary>
    [RequireComponent(typeof(NetworkTransform))]
    [RequireComponent(typeof(NetworkIdentity))]
    [RequireComponent(typeof(VehicleController))]
    public class MirrorMultiplayerVehicle : NetworkBehaviour
    {
        private VehicleController _vehicleController;
        private NetworkIdentity _networkIdentity;
        private NetworkTransform _networkTransform;

        [SyncVar] public float steeringInput;
        [SyncVar] public float throttleInput;
        [SyncVar] public float brakesInput;
        public SyncListFloat volumes = new SyncListFloat();
        public SyncListFloat pitches = new SyncListFloat();
        [SyncVar] public byte lightsByteState;

        [SyncVar] public Vector3 vRbVelocity;
        [SyncVar] public Vector3 vRbAngVelocity;

        private void Awake()
        {
            _networkIdentity = GetComponent<NetworkIdentity>();
            _vehicleController = GetComponent<VehicleController>();
            _networkTransform = GetComponent<NetworkTransform>();

        }

        private void Start()
        {
            volumes = new SyncListFloat();
            pitches = new SyncListFloat();
            for(int i = 0; i < _vehicleController.soundManager.components.Count; i++)
            {
                volumes.Add(0);
                pitches.Add(0);
            }
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            Initialize();
        }

        public override void OnStartClient ()
        {
            base.OnStartClient();
            Initialize();
        }

        private void Initialize()
        {
            _vehicleController.multiplayerInstanceType = _networkIdentity.hasAuthority ?
                VehicleController.MultiplayerInstanceType.Local :
                VehicleController.MultiplayerInstanceType.Remote;

            _vehicleController.SetupMultiplayerInstance();
        }

        private void Update()
        {
            if (_networkIdentity.hasAuthority)
            {
                vRbVelocity = _vehicleController.vehicleRigidbody.velocity;
                vRbAngVelocity = _vehicleController.vehicleRigidbody.angularVelocity;

                steeringInput = _vehicleController.input.Steering;
                throttleInput = _vehicleController.input.Throttle;
                brakesInput = _vehicleController.input.Brakes;

                for (int i = 0; i < _vehicleController.soundManager.components.Count; i++)
                {
                    SoundComponent sc = _vehicleController.soundManager.components[i];
                    volumes[i] = sc.GetVolume();
                    pitches[i] = sc.GetPitch();
                }

                lightsByteState = _vehicleController.effectsManager.lightsManager.GetByteState();
            }
            else
            {
                _vehicleController.input.autoSetInput = false;
                _vehicleController.input.Steering = steeringInput;
                _vehicleController.input.Throttle = throttleInput;
                _vehicleController.input.Brakes = brakesInput;

                _vehicleController.vehicleRigidbody.velocity = vRbVelocity;
                _vehicleController.vehicleRigidbody.angularVelocity = vRbAngVelocity;

                for (int i = 0; i < _vehicleController.soundManager.components.Count; i++)
                {
                    SoundComponent sc = _vehicleController.soundManager.components[i];
                    sc.SetVolume(volumes[i]);
                    sc.SetPitch(pitches[i]);
                }

                _vehicleController.effectsManager.lightsManager.SetByteState(lightsByteState);
            }
        }
    }
}