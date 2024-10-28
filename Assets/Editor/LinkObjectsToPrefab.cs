using UnityEngine;
using UnityEditor;

public class MassLinkToPrefab : MonoBehaviour
{
    public GameObject prefab;  // Ссылка на префаб
    public string objectTag = "Finish";  // Тег объектов, которые нужно привязать к префабу

    [MenuItem("Tools/Link Objects to Prefab")]
    public static void LinkObjectsToPrefab()
    {
        // Указываем вручную префаб и тег (замени на свои данные)
        string objectTag = "Finish";  // Укажи нужный тег
        GameObject prefab = Selection.activeGameObject;  // Убедись, что выбран префаб

        // Проверим, что выбран префаб
        if (prefab == null)
        {
            Debug.LogError("Пожалуйста, выберите префаб в инспекторе.");
            return;
        }

        // Найдем все объекты с указанным тегом
        GameObject[] objectsToLink = GameObject.FindGameObjectsWithTag(objectTag);

        if (objectsToLink.Length == 0)
        {
            Debug.LogWarning("Не найдены объекты с тегом " + objectTag);
            return;
        }

        foreach (GameObject obj in objectsToLink)
        {
            // Сохраняем текущее состояние объекта
            Vector3 position = obj.transform.position;
            Quaternion rotation = obj.transform.rotation;
            Vector3 scale = obj.transform.localScale;

            // Привязываем объект к префабу
            GameObject linkedPrefab = (GameObject)PrefabUtility.SaveAsPrefabAssetAndConnect(obj, AssetDatabase.GetAssetPath(prefab), InteractionMode.UserAction);

            // Восстанавливаем позицию, ротацию и масштаб
            linkedPrefab.transform.position = position;
            linkedPrefab.transform.rotation = rotation;
            linkedPrefab.transform.localScale = scale;

            Debug.Log($"Объект {obj.name} привязан к префабу {prefab.name}.");
        }

        Debug.Log($"Все объекты с тегом {objectTag} успешно привязаны к префабу.");
    }
}
