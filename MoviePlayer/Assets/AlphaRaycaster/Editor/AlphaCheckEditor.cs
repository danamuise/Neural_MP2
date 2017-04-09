using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(AlphaCheck)), CanEditMultipleObjects]
public class AlphaCheckEditor : Editor
{
	private SerializedProperty alphaThreshold;
	private SerializedProperty includeMaterialAlpha;

	private void OnEnable ()
	{
		alphaThreshold = serializedObject.FindProperty("AlphaThreshold");
		includeMaterialAlpha = serializedObject.FindProperty("IncludeMaterialAlpha");
	}

	public override void OnInspectorGUI ()
	{
		var activeGo = Selection.activeGameObject;
		if (activeGo)
		{
			var image = activeGo.GetComponent<Image>();
			if (image)
			{
				var path = AssetDatabase.GetAssetPath(image.mainTexture);
				if (path != string.Empty && !image.sprite.packed)
				{
					var textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                    if (!textureImporter)
                    {
                        EditorGUILayout.HelpBox("Assign a custom source image to the Image component to configure alpha checking.\nBuilt-in Unity images are not supported.", MessageType.Warning);
                        return;
                    }
                    
					if (!textureImporter.isReadable)
					{
						EditorGUILayout.HelpBox("The texture is not readable. Alpha check won't have effect.", MessageType.Warning);
						if (GUILayout.Button("FIX"))
						{
							textureImporter.isReadable = true;
							AssetDatabase.ImportAsset(path);
						}
						return;
					}
				}
				else if (!image.sprite.packed)
				{
					EditorGUILayout.HelpBox("Assign a source image to the Image component to configure alpha checking.", MessageType.Warning);
					return;
				}

                var blockingChilds = activeGo.GetComponentsInChildren<CanvasRenderer>(false)
                    .Where(child => child.gameObject != activeGo && (!child.GetComponent<CanvasGroup>() || child.GetComponent<CanvasGroup>().blocksRaycasts)).ToList();
                if (blockingChilds.Count > 0)
                {
                    EditorGUILayout.HelpBox("Some of the child objects may be blocking the raycast.", MessageType.Warning);
                    if (GUILayout.Button("FIX"))
                    {
                        foreach (var blockingChild in blockingChilds)
                        {
                            var canvasGroup = blockingChild.GetComponent<CanvasGroup>() ? blockingChild.GetComponent<CanvasGroup>() : blockingChild.gameObject.AddComponent<CanvasGroup>();
                            canvasGroup.blocksRaycasts = false;
                        }
                    }
                }
			}
			else
			{
				EditorGUILayout.HelpBox("Can't find Image component. Alpha check is only possible for UI objects with an Image.", MessageType.Error);
				return;
			}
		}
		else return;

		serializedObject.Update();
		EditorGUILayout.PropertyField(alphaThreshold);
		EditorGUILayout.PropertyField(includeMaterialAlpha);
		serializedObject.ApplyModifiedProperties();
	}
}
