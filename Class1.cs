using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_интерактивного_обучающего_пособия
{
    internal class Class1
    {
        // Метод для отображения вариантов ответа
        public static void ShowTestOptions(
            RadioButton rb1, RadioButton rb2, RadioButton rb3,
            string option1, string option2, string option3,
            Button btnCheck, Button btnNext,
            out int correctAnswerIndex, int correctIndex)
        {
            rb1.Text = option1;
            rb2.Text = option2;
            rb3.Text = option3;

            rb1.Visible = true;
            rb2.Visible = true;
            rb3.Visible = true;
            btnCheck.Visible = true;

            btnNext.Visible = false;

            correctAnswerIndex = correctIndex;
        }

        // Метод для проверки выбранного ответа
        public static bool CheckAnswer(RadioButton rb1, RadioButton rb2, RadioButton rb3, int correctIndex)
        {
            int selected = rb1.Checked ? 1 : rb2.Checked ? 2 : rb3.Checked ? 3 : 0;
            return selected == correctIndex;
        }

        // Метод для скрытия вариантов
        public static void HideTestOptions(RadioButton rb1, RadioButton rb2, RadioButton rb3, Button btnCheck)
        {
            rb1.Visible = false;
            rb2.Visible = false;
            rb3.Visible = false;
            btnCheck.Visible = false;
        }
    }
}
