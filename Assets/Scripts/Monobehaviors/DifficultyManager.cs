using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public Dropdown difficultyDropdown;

    private void Start()
    {
        // Добавьте обработчик события для Dropdown
        difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
    }

    // Метод, который будет вызван при изменении выбранной опции
    void OnDifficultyChanged(int index)
    {
        // Получите выбранную опцию
        string selectedDifficulty = difficultyDropdown.options[index].text;

        // Ваш код для изменения сложности игры в соответствии с выбором
        // Например, вы можете установить уровень сложности или вызвать соответствующий метод
        Debug.Log("Выбранная сложность: " + selectedDifficulty);
    }
}