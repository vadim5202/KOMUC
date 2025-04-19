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
    public partial class Form18 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form18()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form18_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Навыки презентации товара",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50,
                ForeColor = Color.Black,
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
                ForeColor = Color.Black,
            };
            this.Controls.Add(lblContent);

            // Кнопка "Далее"
            btnNext = new Button
            {
                Text = "Далее →",
                Dock = DockStyle.Bottom,
                Height = 40,
                ForeColor = Color.Black,
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
                ForeColor = Color.Black,
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
                ForeColor = Color.Black,
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
                    lblContent.Text = "📘 Теория: Как проводить успешную презентацию товара?\n\n" +
                                      "Презентация товара — это процесс, в котором продавец демонстрирует преимущества продукта клиенту, " +
                                      "помогая ему принять решение о покупке.Умение проводить качественную презентацию важно для успешных продаж.\n\n" +
                                      "🔹 Этапы успешной презентации:\n" +
                                      "- Задавайте вопросы, чтобы выявить потребности клиента.\n" +
                                      "- Представляйте товар в контексте потребностей клиента.\n" +
                                      "- Выделяйте уникальные преимущества товара.\n" +
                                      "- Предлагайте решение и подталкивайте к действию.\n" +
                                      "- Обратите внимание на невербальное общение: ваш тон, уверенность и контакт с клиентом.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "Клиент заинтересовался ноутбуком, но сомневается в его производительности.\n\n" +
                                      "📌 Вопрос: Как вы должны представить товар в ответ на сомнение клиента?";
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Какой этап презентации товара предполагает выявление потребностей клиента?";
                    ShowTestOptions("A) Представление товара", "B) Задавание вопросов", "C) Подталкивание к действию", 2);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Как лучше всего демонстрировать товар, если клиент сомневается в его качестве?";
                    ShowTestOptions("A) Показать примеры использования товара", "B) Сказать, что товар лучший", "C) Попросить клиента поверить на слово", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Как правильно выделить уникальные преимущества товара?";
                    ShowTestOptions("A) Рассказать, чем товар отличается от других", "B) Просто повторить характеристики товара", "C) Сказать, что товар не имеет конкурентов", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Как важно внимание к невербальному общению при презентации товара?";
                    ShowTestOptions("A) Очень важно, ведь это создает доверие", "B) Не имеет значения", "C) Важно только в случае переговоров с руководством", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Когда лучше всего подталкивать клиента к действию?";
                    ShowTestOptions("A) Когда клиент ясно выразил интерес", "B) Когда клиент не задает вопросов", "C) Когда товар уже выбран", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Как можно помочь клиенту решить сомнения по поводу выбора товара?";
                    ShowTestOptions("A) Рассказать о положительных отзывах других покупателей", "B) Убедить его, что он не ошибется", "C) Игнорировать сомнения клиента", 1);
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
                        resultMessage = "🎉 Отличный результат! Вы отлично понимаете, как презентовать товар!";
                    }

                    lblContent.Text = $"🎉 Задание завершено!\n\nПравильных ответов: {correctAnswers}/6\n\n{resultMessage}";
                    btnNext.Text = "Закрыть";
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void Form18_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            stage++; ShowStage();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            int selectedAnswer = rbOption1.Checked ? 1 : rbOption2.Checked ? 2 : rbOption3.Checked ? 3 : 0;

            if (selectedAnswer == correctAnswerIndex)
                correctAnswers++;

            stage++;
            ShowStage();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13();
            form13.Show();
        }

    }
}
