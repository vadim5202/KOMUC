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
    public partial class Form5 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form5()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Анализ эффективности продаж",
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
                    lblContent.Text = "📘 Теория: Зачем нужен анализ продаж?\n\n" +
                                      "Анализ продаж помогает:\n" +
                                      "✔ Определить, какие товары продаются лучше всего.\n" +
                                      "✔ Узнать, какие клиенты приносят наибольшую прибыль.\n" +
                                      "✔ Найти причины снижения продаж и способы их увеличения.\n\n" +
                                      "🔹 Методы анализа:\n" +
                                      "- ABC-анализ (определяет ключевые товары).\n" +
                                      "- Анализ динамики продаж (изменение продаж со временем).\n" +
"- Сегментирование клиентов (разделение по категориям).";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "Продажи за три месяца:\n" +
                                      "🟢 Январь: 150 000 ₽\n" +
                                      "🟢 Февраль: 170 000 ₽\n" +
                                      "🟢 Март: 200 000 ₽\n\n" +
                                     "📌 Вопрос: Какой тренд можно увидеть в данных?\n\n" +
                                      "Ответ: Рост продаж";
                    
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Какой метод анализа помогает определить ключевые товары?";
                    ShowTestOptions("A) ABC-анализ", "B) Анализ динамики", "C) Финансовый анализ", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Какой метод выявляет сезонные колебания спроса?";
                    ShowTestOptions("A) Сегментирование клиентов", "B) Анализ динамики", "C) ABC-анализ", 2);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Что НЕ является целью анализа продаж?";
                    ShowTestOptions("A) Поиск эффективных каналов", "B) Определение затрат", "C) Улучшение стратегии", 2);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Какой анализ помогает определить целевые группы клиентов?";
                    ShowTestOptions("A) Сегментирование клиентов", "B) ABC-анализ", "C) Анализ динамики", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Что показывает анализ динамики продаж?";
                    ShowTestOptions("A) Изменение продаж во времени", "B) Прибыль компании", "C) Количество клиентов", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Какой метод анализа используется для изучения ключевых клиентов?";
                    ShowTestOptions("A) ABC-анализ", "B) Анализ динамики", "C) Сегментирование клиентов", 3);
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
                        resultMessage = "🎉 Отличный результат! Вы хорошо понимаете анализ потребностей клиента!";
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
                correctAnswers++;

            stage++;
            ShowStage();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
