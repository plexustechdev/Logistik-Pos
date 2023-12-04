using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SO_Customer))]
public class PreviewSpriteImage : Editor
{
    // SO_Customer customer;

    // private void OnEnable()
    // {
    //     customer = target as SO_Customer;
    // }

    // public override void OnInspectorGUI()
    // {
    //     base.OnInspectorGUI();
    //     DrawSpriteCharacter();
    //     DrawSpriteViewTable();
    // }

    // private void DrawSpriteCharacter()
    // {
    //     if (customer.SpriteCharacter is null) return;

    //     Texture2D texture = AssetPreview.GetAssetPreview(customer.SpriteCharacter);
    //     GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
    //     GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    // }

    // private void DrawSpriteViewTable()
    // {
    //     if (customer.SpriteTable is null) return;

    //     Texture2D texture = AssetPreview.GetAssetPreview(customer.SpriteTable);
    //     GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
    //     GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    // }
}
