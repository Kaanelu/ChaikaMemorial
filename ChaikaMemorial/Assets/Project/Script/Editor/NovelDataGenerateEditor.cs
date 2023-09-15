using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NovelDataGenerateEditor : EditorWindow
{

    public static EditorWindow? instance; //�C���X�^���X

    private Vector2 leftPaneScrollPosition = Vector2.zero;
    private Vector2 rightPaneScrollPosition = Vector2.zero;
    private string textFieldContent = "";
    private string[] listItems = new string[0];
    private int selectedListItemIndex = -1; // �I�����ꂽ���X�g�A�C�e���̃C���f�b�N�X
    // �e�X�g�E�B���h�E��\�����郁�j���[�A�C�e����ǉ����܂�
    [MenuItem("Custom/�m�x���f�[�^�N���X�쐬")]
    public static void ShowWindow()
    {
        if(instance != null)
        {
            Debug.Log("���łɃE�B���h�E�͑��݂��Ă��܂�");
            return;
        }
        // �E�B���h�E���쐬�܂��͕\�����܂�
        NovelDataGenerateEditor.instance = EditorWindow.GetWindow(typeof(NovelDataGenerateEditor));
    }

    // �E�B���h�E�̃R���e���c��`�悷�邽�߂̃��\�b�h
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        // ������GUI��\��
        EditorGUILayout.BeginVertical(GUILayout.Width(position.width * 0.3f));

        GUILayout.Label("Left Pane", EditorStyles.boldLabel);

        // �����ɍ�����GUI�v�f��ǉ����܂�
        textFieldContent = EditorGUILayout.TextField("Text Field", textFieldContent);

        if (GUILayout.Button("Add Item"))
        {
            if (!string.IsNullOrEmpty(textFieldContent))
            {
                // �e�L�X�g�t�B�[���h�̓��e�����X�g�ɒǉ�
                ArrayUtility.Add(ref listItems, textFieldContent);
                textFieldContent = "";
            }
        }

        leftPaneScrollPosition = EditorGUILayout.BeginScrollView(leftPaneScrollPosition);
        for (int i = 0; i < listItems.Length; i++)
        {
            // ���X�g�A�C�e�����N���b�N�ł��郉�x���ɕύX
            if (GUILayout.Button(listItems[i]))
            {
                selectedListItemIndex = i;
            }
        }
        EditorGUILayout.EndScrollView();

        EditorGUILayout.EndVertical();

        // �E����ListView��\��
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
