using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ChatWindowController : MonoBehaviour
{
    [SerializeField] GameObject messagePanel;
    [SerializeField] ScrollRect scrollView;
    [SerializeField] GameObject textMessagePrefab;
    [SerializeField] TMP_InputField input;
    void Start()
    {
        if(scrollView  == null)
        {
            scrollView = GetComponentInChildren<ScrollRect>();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            var newNode = GameObject.Instantiate(textMessagePrefab, messagePanel.transform);

            var textInstance = newNode.GetComponent<TextMeshProUGUI>();
            textInstance.SetText("123abc, this is a test for adding new node to see the scrollbar");
            input.text = "";

            Invoke(nameof(ScrollToBottom), 0.1f);
        }
    }

    void ScrollToBottom()
    {
        scrollView.normalizedPosition = new Vector2(0, 0);
    }
}
