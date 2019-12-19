using System;
using System.IO;
using n_puzzle.Scripts.Web;
using UnityEngine;
using UnityEngine.UI;

namespace n_puzzle.Scripts.State
{
    public class PuzzleView : MonoBehaviour
    {
        [SerializeField] private Button prev;
        [SerializeField] private Button next;
        [SerializeField] private Text step;
        [SerializeField] private Dropdown fileList;
        [SerializeField] private GetMapJson getMapJson;
        public event Action Prev;
        public event Action Next;

        private void Awake()
        {
            prev.onClick.AddListener(OnPrev);
            next.onClick.AddListener(OnNext);
            fileList.onValueChanged.AddListener(OnFileChange);
        }

        private void OnFileChange(int num)
        {
            getMapJson.UpdateMap(Path.Combine(WebController.URL, "get", fileList.options[num].text));
        }

        public void SetStep(int currentStep)
        {
            step.text = currentStep.ToString();
        }

        protected virtual void OnPrev()
        {
            Prev?.Invoke();
        }

        protected virtual void OnNext()
        {
            Next?.Invoke();
        }

        public void AddFile(string file_name)
        {
            Debug.Log(file_name);
            fileList.options.Add (new Dropdown.OptionData() {text=file_name});
            fileList.value = 1;
            fileList.value = 0;
        }
    }
}
