using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace n_puzzle.Scripts.State
{
    public class ConnectView : MonoBehaviour
    {
        [SerializeField] private Button connect;
        [SerializeField] private TMP_InputField inputURL;

        public event Action<string> Connect;

        private void Awake()
        {
            connect.onClick.AddListener(OnConnect);
        }

        protected virtual void OnConnect()
        {
            if (inputURL.text.Length == 0)
            {
                Debug.Log("No input url!");
                return;
            }
            Container.URL = inputURL.text;
            Connect?.Invoke(inputURL.text);
        }
    }
}
