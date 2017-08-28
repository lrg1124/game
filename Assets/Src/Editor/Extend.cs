using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour {

    [MenuItem("GameObject/UI/Image")]
    static void CreatImage() {
        if (Selection.activeTransform) {
            if (Selection.activeTransform.GetComponentInParent<Canvas>()) {
                GameObject go = new GameObject("Image", typeof(Image));
                go.GetComponent<Image>().raycastTarget = false;
                go.transform.SetParent(Selection.activeTransform);
            }
        }
    }

    [MenuItem("GameObject/UI/Text")]
    static void CreatText() {
        if (Selection.activeTransform) {
            if (Selection.activeTransform.GetComponentInParent<Canvas>()) {
                GameObject go = new GameObject("MText", typeof(MText));
                go.transform.SetParent(Selection.activeTransform);
            }
        }
    }

}
