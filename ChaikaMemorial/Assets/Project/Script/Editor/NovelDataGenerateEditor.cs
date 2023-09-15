using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NovelDataGenerateEditor : EditorWindow
{

    public static EditorWindow? instance; //インスタンス

    private Vector2 leftPaneScrollPosition = Vector2.zero;
    private Vector2 rightPaneScrollPosition = Vector2.zero;
    private string textFieldContent = "";
    private string[] listItems = new string[0];
    private int selectedListItemIndex = -1; // 選択されたリストアイテムのインデックス
    // テストウィンドウを表示するメニューアイテムを追加します
    [MenuItem("Custom/ノベルデータクラス作成")]
    public static void ShowWindow()
    {
        if(instance != null)
        {
            Debug.Log("すでにウィンドウは存在しています");
            return;
        }
        // ウィンドウを作成または表示します
        NovelDataGenerateEditor.instance = EditorWindow.GetWindow(typeof(NovelDataGenerateEditor));
    }

    // ウィンドウのコンテンツを描画するためのメソッド
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        // 左側のGUIを表示
        EditorGUILayout.BeginVertical(GUILayout.Width(position.width * 0.3f));

        GUILayout.Label("Left Pane", EditorStyles.boldLabel);

        // ここに左側のGUI要素を追加します
        textFieldContent = EditorGUILayout.TextField("Text Field", textFieldContent);

        if (GUILayout.Button("Add Item"))
        {
            if (!string.IsNullOrEmpty(textFieldContent))
            {
                // テキストフィールドの内容をリストに追加
                ArrayUtility.Add(ref listItems, textFieldContent);
                textFieldContent = "";
            }
        }

        leftPaneScrollPosition = EditorGUILayout.BeginScrollView(leftPaneScrollPosition);
        for (int i = 0; i < listItems.Length; i++)
        {
            // リストアイテムをクリックできるラベルに変更
            if (GUILayout.Button(listItems[i]))
            {
                selectedListItemIndex = i;
            }
        }
        EditorGUILayout.EndScrollView();

        EditorGUILayout.EndVertical();

        // 右側のListViewを表示
        EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));

        GUILayout.Label("Right Pane", EditorStyles.boldLabel);

        rightPaneScrollPosition = EditorGUILayout.BeginScrollView(rightPaneScrollPosition);

        if (selectedListItemIndex >= 0 && selectedListItemIndex < listItems.Length)
        {
            GUILayout.Label("Selected Item: " + listItems[selectedListItemIndex]);
        }

        EditorGUILayout.EndScrollView();

        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }
}
