using Data;
using UnityEditor;
using UnityEngine;

namespace Utils {

    [CustomPropertyDrawer(typeof(ResultDataId))]
    public class ResultDataIdEditor : PropertyDrawer {

        private class ChangeIdRequestData {
            public SerializedProperty idProperty;
            public string newValue;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);
            var idProperty = property.FindPropertyRelative("_value");
            DrawLabel(position, label);
            DrawDropdown(position, idProperty);
            EditorGUI.EndProperty();
            property.serializedObject.ApplyModifiedProperties();
        }

        private void DrawDropdown(Rect position, SerializedProperty idProperty) {
            var dropdownPosition = position;
            dropdownPosition.width = dropdownPosition.width / 2;
            dropdownPosition.position = new Vector2(dropdownPosition.x + dropdownPosition.width, dropdownPosition.position.y);
            if (EditorGUI.DropdownButton(dropdownPosition, new GUIContent(idProperty.stringValue), FocusType.Passive)) {
                var menu = new GenericMenu();
                var results = ResultDataCollection.Instance.ResultsData;
                foreach (var resultData in results) {
                    menu.AddItem(new GUIContent(resultData.Id),
                        idProperty.stringValue == resultData.Id,
                        ChangeId, new ChangeIdRequestData() { idProperty = idProperty, newValue = resultData.Id }
                        );
                }
                menu.ShowAsContext();
            }
        }

        private static void DrawLabel(Rect position, GUIContent label) {
            var labelPosition = position;
            labelPosition.width = labelPosition.width / 2;
            EditorGUI.LabelField(position, label);
        }

        private void ChangeId(object resultDataId) {
            var changeIdRequestData = resultDataId as ChangeIdRequestData;
            changeIdRequestData.idProperty.stringValue = changeIdRequestData.newValue;
            changeIdRequestData.idProperty.serializedObject.ApplyModifiedProperties();
        }
    }
}

