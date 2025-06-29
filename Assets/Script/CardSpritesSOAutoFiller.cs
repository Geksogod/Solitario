using System.Collections.Generic;
using System.Text.RegularExpressions;
using Appodeal.Core.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Appodeal.Core.Script
{
    public class CardSpritesSOAutoFiller : EditorWindow
    {
        private CardSpritesSO cardSO;
        private string folderPath = "Assets/Image/Cards";

        [MenuItem("Solitaire/Auto Fill CardSpritesSO")]
        public static void ShowWindow()
        {
            GetWindow<CardSpritesSOAutoFiller>("Auto Fill CardSpritesSO");
        }

        private void OnGUI()
        {
            cardSO = (CardSpritesSO)EditorGUILayout.ObjectField("CardSpritesSO", cardSO, typeof(CardSpritesSO), false);
            folderPath = EditorGUILayout.TextField("Folder Path", folderPath);

            if (GUILayout.Button("Auto Fill"))
            {
                if (cardSO != null)
                    AutoFill();
                else
                    Debug.LogError("Assign CardSpritesSO first!");
            }
        }

        private void AutoFill()
        {
            var guids = AssetDatabase.FindAssets("t:Sprite", new[] { folderPath });
            var list = new List<CardSpriteData>();

            foreach (string guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);

                // Expecting name like: "10_of_hearts", "ace_of_spades"
                var filename = System.IO.Path.GetFileNameWithoutExtension(path);

                if (TryParse(filename, out CardSuit suit, out CardValue value))
                {
                    list.Add(new CardSpriteData { Suit = suit, Value = value, Sprite = sprite });
                }
            }

            cardSO.GetType().GetField("_cardSprites", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(cardSO, list);

            EditorUtility.SetDirty(cardSO);
            AssetDatabase.SaveAssets();

            Debug.Log($"Filled {list.Count} cards!");
        }

        private bool TryParse(string name, out CardSuit suit, out CardValue value)
        {
            suit = default;
            value = default;

            // Match e.g. "10_of_hearts", "ace_of_spades"
            var m = Regex.Match(name, @"^(?<value>\w+)_of_(?<suit>\w+)$");
            if (!m.Success)
                return false;

            var v = m.Groups["value"].Value.ToLower();
            var s = m.Groups["suit"].Value.ToLower();

            // Suit parse
            suit = s switch
            {
                "hearts" => CardSuit.Hearts,
                "diamonds" => CardSuit.Diamonds,
                "spades" => CardSuit.Spades,
                "clubs" => CardSuit.Clubs,
                _ => suit
            };

            // Value parse
            value = v switch
            {
                "ace" => CardValue.Ace,
                "jack" => CardValue.Jack,
                "queen" => CardValue.Queen,
                "king" => CardValue.King,
                _ => int.TryParse(v, out int n) ? (CardValue)n : value
            };

            return true;
        }

    }
}