using System;
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

        public event Action Prev;
        public event Action Next;

        private void Awake()
        {
            prev.onClick.AddListener(OnPrev);
            next.onClick.AddListener(OnNext);
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
