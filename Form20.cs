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
    public partial class Form20 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form20()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Обслуживание и лояльность клиентов",
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
                    lblContent.Text = "📘 Теория: Обслуживание и лояльность клиентов\n\n" +
                                      "Обслуживание клиентов — это ключевой элемент успешной работы компании. Качество обслуживания напрямую влияет на лояльность клиентов и их желание вернуться в магазин.\n\n" +
"🔹 Основные принципы обслуживания:\n" +
                                      "- Быстрое реагирование на запросы клиентов.\n" +
                                      "- Вежливость и уважение.\n" +
                                      "- Индивидуальный подход к каждому клиенту.\n\n" +
                                      "🔹 Что важно для лояльности клиентов:\n" +
                                      "- Программы лояльности.\n" +
                                      "- Скидки и акции для постоянных клиентов.\n" +
                                      "- Высокий уровень обслуживания.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "Клиент вернулся в магазин и был рад, что продавец помнил его предпочтения и предложил скидку по программе лояльности.\n\n" +
                                      "📌 Вопрос: Какое влияние на клиента оказала программа лояльности?\n\n" +
                                      "Ответ: Программа лояльности повысила удовлетворенность клиента и его приверженность магазину.";

                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Какое качество является ключевым для обслуживания клиентов?";
                    ShowTestOptions("A) Быстрое реагирование на запросы", "B) Умение продавать дорогостоящие товары", "C) Долгие беседы с клиентами", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Какое из утверждений лучше всего описывает лояльность клиентов?";
                    ShowTestOptions("A) Приверженность клиентом магазину, основанная на положительном опыте", "B) Покупка товаров только по акции", "C) Постоянные жалобы клиентов", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Какой из способов увеличивает лояльность клиентов?";
                    ShowTestOptions("A) Программа лояльности и скидки", "B) Удлинение рабочего времени", "C) Постоянные изменения ассортимента", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Какую роль играет индивидуальный подход в обслуживании клиентов?";
                    ShowTestOptions("A) Он повышает удовлетворенность клиента", "B) Он делает клиента более требовательным", "C) Он не влияет на удовлетворенность", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Какое из утверждений не относится к хорошему обслуживанию?";
                    ShowTestOptions("A) Вежливое и внимательное отношение", "B) Быстрое обслуживание", "C) Игнорирование пожеланий клиента", 3);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Какую стратегию стоит использовать для повышения лояльности клиентов?";
                    ShowTestOptions("A) Регулярные акции и скидки", "B) Игнорирование запросов клиентов", "C) Частая смена ассортимента", 1);
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
                        resultMessage = "🎉 Отличный результат! Вы отлично понимаете важность обслуживания и лояльности клиентов!";
                    }

                    lblContent.Text = $"🎉 Задание завершено!\n\nПравильных ответов: {correctAnswers}/6\n\n{resultMessage}";
                    btnNext.Text = "Закрыть";
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void Form20_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form20_FormClosing(object sender, FormClosingEventArgs e)
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
