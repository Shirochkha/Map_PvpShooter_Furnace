using UnityEngine;
using UnityEditor;

public class MassLinkToPrefab : MonoBehaviour
{
    public GameObject prefab;  // ������ �� ������
    public string objectTag = "Finish";  // ��� ��������, ������� ����� ��������� � �������

    [MenuItem("Tools/Link Objects to Prefab")]
    public static void LinkObjectsToPrefab()
    {
        // ��������� ������� ������ � ��� (������ �� ���� ������)
        string objectTag = "Finish";  // ����� ������ ���
        GameObject prefab = Selection.activeGameObject;  // �������, ��� ������ ������

        // ��������, ��� ������ ������
        if (prefab == null)
        {
            Debug.LogError("����������, �������� ������ � ����������.");
            return;
        }

        // ������ ��� ������� � ��������� �����
        GameObject[] objectsToLink = GameObject.FindGameObjectsWithTag(objectTag);

        if (objectsToLink.Length == 0)
        {
            Debug.LogWarning("�� ������� ������� � ����� " + objectTag);
            return;
        }

        foreach (GameObject obj in objectsToLink)
        {
            // ��������� ������� ��������� �������
            Vector3 position = obj.transform.position;
            Quaternion rotation = obj.transform.rotation;
            Vector3 scale = obj.transform.localScale;

            // ����������� ������ � �������
            GameObject linkedPrefab = (GameObject)PrefabUtility.SaveAsPrefabAssetAndConnect(obj, AssetDatabase.GetAssetPath(prefab), InteractionMode.UserAction);

            // ��������������� �������, ������� � �������
            linkedPrefab.transform.position = position;
            linkedPrefab.transform.rotation = rotation;
            linkedPrefab.transform.localScale = scale;

            Debug.Log($"������ {obj.name} �������� � ������� {prefab.name}.");
        }

        Debug.Log($"��� ������� � ����� {objectTag} ������� ��������� � �������.");
    }
}
