using System;
using UnityEngine;
using UnityEngine.UI;

namespace n_puzzle.Scripts.State
{
    public class ConnectView : MonoBehaviour
    {
        [SerializeField] private Button connect;
        [SerializeField] private InputField inputURL;

        public event Action<string> Connect;

        private void Awake()
        {
            connect.onClick.AddListener(OnConnect);
        }

        protected virtual void OnConnect()
        {
            Connect?.Invoke(inputURL.text);
        }
    }
}
