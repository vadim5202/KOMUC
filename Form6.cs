using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_интерактивного_обучающего_пособия
{
    public partial class Form6 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
                                        // Объявляем элементы управления
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form6()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Работа с клиентами",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50,
                ForeColor = Color.Black
        };
            this.Controls.Add(lblTitle);

            // Основной текст
            lblContent = new Label
            {
                Font = new System.Drawing.Font("Arial", 12),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
                Dock = DockStyle.Top,
                Height = 200,
                ForeColor = Color.Black
            };
            this.Controls.Add(lblContent);

            // Кнопка "Далее"
            btnNext = new Button
            {
                Text = "Далее →",
                Dock = DockStyle.Bottom,
                Height = 40,
                ForeColor = Color.Black
            };
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            // Радиокнопки для теста (по умолчанию скрыты)
            rbOption1 = new RadioButton { Visible = false, Dock = DockStyle.Top };
            rbOption2 = new RadioButton { Visible = false, Dock = DockStyle.Top };
            rbOption3 = new RadioButton { Visible = false, Dock = DockStyle.Top };
            this.Controls.Add(rbOption3);
            this.Controls.Add(rbOption2);
            this.Controls.Add(rbOption1);

            // Кнопка "Проверить" (скрыта по умолчанию)
            btnCheck = new Button
            {
                Text = "Далее",
                Visible = false,
                Dock = DockStyle.Bottom,
                Height = 40,
                ForeColor = Color.Black
            };
            btnCheck.Click += BtnCheck_Click;
            this.Controls.Add(btnCheck);

            // Кнопка "Завершить"
            btnFinish = new Button
            {
                Text = "Завершить",
                Visible = false,
                Dock = DockStyle.Bottom,
                Height = 40,
                ForeColor = Color.Black
            };
            btnFinish.Click += BtnFinish_Click;
            this.Controls.Add(btnFinish);
        }
        private void ShowStage()
        {
            // Скрываем все тестовые элементы
            rbOption1.Visible = false;
            rbOption2.Visible = false;
            rbOption3.Visible = false;
            btnCheck.Visible = false;
            btnFinish.Visible = false; // Скрываем кнопку "Завершить" пока не закончено

            switch (stage)
            {
                case 0:
                    lblContent.Text = "📘 Теория: Как работать с клиентами?\n\n" +
                                      "Успех бизнеса зависит от правильного подхода к клиентам. Важные аспекты работы с клиентами:\n" +
                                      "✔ Привлечение новых клиентов.\n" +
                                      "✔ Удержание существующих клиентов.\n" +
                                      "✔ Персонализированный подход.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "📌 Вопрос: Клиент пришел на встречу с вопросами по новым продуктам.\n" +
                                      "Как вы поступите в этой ситуации?\n\n" +
                                      "Ответ:\n" +
                                      "1.Выслушайте клиента\n" +
                                      "2.Предоставьте полную информацию\n" +
                                      "3.Ответьте на вопросы\n" +
                                      "4.Убелите клиента в надежности и качестве\n";
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (1/6):\n\n" +
                                      "Какой из способов лучше всего помогает понять потребности клиента?";
                    ShowTestOptions("A) Открытые вопросы", "B) Демонстрация продукта", "C) Указание на скидки", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (2/6):\n\n" +
                                      "Какой метод улучшает понимание между продавцом и клиентом?";
                    ShowTestOptions("A) Активное слушание", "B) Быстрое оформление заказа", "C) Использование сложных терминов", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (3/6):\n\n" +
                                      "Какой вопрос лучше выявляет потребности клиента?";
                    ShowTestOptions("A) Вам нравится наш ассортимент?", "B) Какие задачи вы хотите решить?", "C) Вы хотите оформить заказ?", 2);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (4/6):\n\n" +
                                      "Как стоит вести разговор с клиентом?";
                    ShowTestOptions("A) Перебивать и быстро предлагать товар", "B) Внимательно слушать и задавать уточняющие вопросы", "C) Говорить только о характеристиках товара", 2);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (5/6):\n\n" +
                                      "Что важно учитывать при анализе потребностей клиента?";
                    ShowTestOptions("A) Только цену продукта", "B) Опыт и предпочтения клиента", "C) Время года", 2);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (6/6):\n\n" +
                                      "Как можно эффективно выявить ключевые потребности клиента?";
                    ShowTestOptions("A) Говорить только о популярных товарах", "B) Спрашивать о проблемах и ожиданиях", "C) Предлагать товары с наибольшей скидкой", 2);
                    break;

                case 8:
                    string resultMessage;
                    if (correctAnswers <= 2)
                    {
                        resultMessage = "😞 Вам стоит повторить задание!";
                    }
                    else if (correctAnswers <= 4)
                    {
                        resultMessage = "🙂 Неплохо, но можно лучше!";
                    }
                    else
                    {
                        resultMessage = "🎉 Отличный результат! Вы хорошо понимаете потребности клиентов!";
                    }

                    lblContent.Text = $"🎉 Задание завершено!\n\nПравильных ответов: {correctAnswers}/6\n\n{resultMessage}";
                    btnNext.Text = "Закрыть";
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void ShowTestOptions(string option1, string option2, string option3, int correctIndex)
        {
            rbOption1.Text = option1;
            rbOption2.Text = option2;
            rbOption3.Text = option3;

            rbOption1.Visible = true;
            rbOption2.Visible = true;
            rbOption3.Visible = true;
            btnCheck.Visible = true;

            correctAnswerIndex = correctIndex;
            btnNext.Visible = false;
            ForeColor = Color.Black;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            stage++;
            ShowStage();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            int selectedAnswer = rbOption1.Checked ? 1 : rbOption2.Checked ? 2 : rbOption3.Checked ? 3 : 0;

            if (selectedAnswer == correctAnswerIndex)
            {
                correctAnswers++;
            }

            stage++;
            ShowStage();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
