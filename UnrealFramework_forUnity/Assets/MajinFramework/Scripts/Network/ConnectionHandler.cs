using System;
using System.Net;
#if NETCODE
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
#endif
using UnityEngine;

namespace Majingari.Network {
#if NETCODE_EXTENSION
    [RequireComponent(typeof(NetworkManager))]
    public class ConnectionHandler : NetworkDiscovery<DiscoveryBroadcastData, DiscoveryResponseData> {
        public static event Action ConnectionEstablished;
        public static event Action ConnectionShutdown;
        private NetworkManager netManager;
        public static event Action<IPEndPoint, DiscoveryResponseData> OnServerFound;

        void Awake() {
            netManager = GetComponent<NetworkManager>();
            netManager.OnServerStarted += OnServerStart;
            netManager.OnClientConnectedCallback += ClientNetworkReadyWrapper;
            netManager.OnClientDisconnectCallback += OnClientDisconnected;
        }

        void OnDestroy() {
            netManager.OnServerStarted -= OnServerStart;
            netManager.OnClientConnectedCallback -= ClientNetworkReadyWrapper;
            netManager.OnClientDisconnectCallback -= OnClientDisconnected;
        }

        private void OnClientDisconnected(ulong clientId) {
            if (clientId == netManager.LocalClientId) {
                Debug.Log("I'm disconnected");
                ConnectionShutdown?.Invoke();
                StopDiscovery();
            }
            else {
                Debug.Log($"Somone Disconnected {clientId}");
            }
        }

        private void OnServerStart() {
            ConnectionEstablished?.Invoke();
            StartServer();
        }

        private void ClientNetworkReadyWrapper(ulong clientId) {
            if (netManager.IsServer)
                return;

            if (clientId == netManager.LocalClientId) {
                Debug.Log("I'm(client) success connect to Server");
                ConnectionEstablished?.Invoke();
            }
        }

        protected override bool ProcessBroadcast(IPEndPoint sender, DiscoveryBroadcastData broadCast, out DiscoveryResponseData response) {

            Debug.Log($"Broadcast my Session {sender.Address} -- {sender.Port}");
            var sessionProp = ServiceLocator.Resolve<SessionState>();
            response = new DiscoveryResponseData() {
                ServerName = sessionProp.sessionName,
                Port = ((UnityTransport)netManager.NetworkConfig.NetworkTransport).ConnectionData.Port,
            };
            return true;
        }

        protected override void ResponseReceived(IPEndPoint sender, DiscoveryResponseData response) {
            OnServerFound?.Invoke(sender, response);
        }
    }
#else
public class ConnectionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
#endif
}