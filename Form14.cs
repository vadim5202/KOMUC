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
    public partial class Form14 : Form
    {
        private int stage = 0;
        private int correctAnswers = 0;
        private int correctAnswerIndex;

        private Label lblTitle, lblContent;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private Button btnNext, btnCheck, btnFinish;
        private bool isExampleStage = true;
        public Form14()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            lblTitle = new Label
            {
                Text = "Задание: Основы общения с клиентами",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                ForeColor = Color.Black
            };
            Controls.Add(lblTitle);

            lblContent = new Label
            {
                Font = new System.Drawing.Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 250,
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
                ForeColor = Color.Black,
            };
            Controls.Add(lblContent);

            rbOption1 = new RadioButton { Dock = DockStyle.Top, Visible = false };
            rbOption2 = new RadioButton { Dock = DockStyle.Top, Visible = false };
            rbOption3 = new RadioButton { Dock = DockStyle.Top, Visible = false };
            Controls.Add(rbOption3);
            Controls.Add(rbOption2);
            Controls.Add(rbOption1);

            btnCheck = new Button
            {
                Text = "Далее",
                Dock = DockStyle.Bottom,
                Height = 40,
                Visible = false,
                ForeColor = Color.Black,
            };
            btnCheck.Click += BtnCheck_Click;
            Controls.Add(btnCheck);

            btnNext = new Button
            {
                Text = "Далее →",
                Dock = DockStyle.Bottom,
                Height = 40,
                ForeColor = Color.Black,
            };
            btnNext.Click += BtnNext_Click;
            Controls.Add(btnNext);

            btnFinish = new Button
            {
                Text = "Завершить",
                Dock = DockStyle.Bottom,
                Height = 40,
                Visible = false,
                ForeColor = Color.Black,
            };
            btnFinish.Click += BtnFinish_Click;
            Controls.Add(btnFinish);
        }

        private void Form14_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form14_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ShowStage()
        {
            rbOption1.Visible = false;
            rbOption2.Visible = false;
            rbOption3.Visible = false;
            btnCheck.Visible = false;
            btnNext.Visible = true;
            btnFinish.Visible = false;

            switch (stage)
            {
                case 0:
                    lblContent.Text =
                        "📘 Теория: Как выявить потребности клиента?\n\n" +
                        "Понимание нужд клиента — ключ к успешной продаже. Продавец должен:\n" +
                        "✔ Задавать уточняющие и открытые вопросы.\n" +
                        "✔ Быть внимательным к словам и жестам.\n" +
                        "✔ Слушать, а не только говорить.\n\n" +
                        "Методы:\n" +
                        "- Открытые вопросы (например, \"Что вы ищете?\").\n" +
                        "- Наблюдение за поведением клиента.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                        "Клиент заходит в магазин и выглядит растерянным. Как вы поступите?\n\n" +
                        "❓ Выберите лучший вариант:";
                    rbOption1.Text = "A) Подойти и предложить помощь";
                    rbOption2.Text = "B) Ждать, пока он сам обратится";
                    rbOption3.Text = "C) Заняться другими делами";

                    correctAnswerIndex = 1;
                    isExampleStage = true;

                    rbOption1.Visible = true;
                    rbOption2.Visible = true;
                    rbOption3.Visible = true;
                    btnCheck.Visible = true;
                    btnNext.Visible = false;
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Какой метод анализа помогает определить ключевые товары?";
                    ShowTestOptions("A) ABC-анализ", "B) Анализ динамики", "C) Финансовый анализ", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Почему важно уточнять потребности клиента?";
                    ShowTestOptions("A) Чтобы ускорить обслуживание", "B) Чтобы навязать товар", "C) Чтобы предложить подходящее", 3);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Что значит 'активное слушание'?";
                    ShowTestOptions("A) Перебивать", "B) Внимательно слушать и уточнять", "C) Смотреть в телефон", 2);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Какая черта НЕ относится к хорошему сервису?";
                    ShowTestOptions("A) Вежливость", "B) Быстрая реакция", "C) Игнорирование клиента", 3);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Что делать, если клиент долго не может выбрать товар?";
                    ShowTestOptions("A) Предложить варианты", "B) Оставить одного", "C) Ускорить выбор", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Что лучше всего укрепляет доверие клиента?";
                    ShowTestOptions("A) Улыбка и внимание", "B) Быстрые ответы", "C) Серьёзность", 1);
                    break;

                case 8:
                    string result;
                    if (correctAnswers <= 2)
                        result = $"Правильных ответов: {correctAnswers}/6\n\n\"😞 Вам стоит повторить задание!";
                    else if (correctAnswers <= 4)
                        result = $"Правильных ответов: {correctAnswers}/6\n\n🙂 Неплохо, но можно лучше!";
                    else
                        result = $"Правильных ответов: {correctAnswers}/6\n\n🎉 Отличный результат!";

                    lblContent.Text = "🎉 Задание завершено!\n\n" + result;
                    btnNext.Visible = false;
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void ShowTestOptions(string option1, string option2, string option3, int correctIndex)
        {
            rbOption1.Text = option1;
            rbOption2.Text = option2;
            rbOption3.Text = option3;
            correctAnswerIndex = correctIndex;

            rbOption1.Visible = true;
            rbOption2.Visible = true;
            rbOption3.Visible = true;

            isExampleStage = false;
            ForeColor = Color.Black;
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            int selected = rbOption1.Checked ? 1 : rbOption2.Checked ? 2 : rbOption3.Checked ? 3 : 0;
            if (selected == correctAnswerIndex)
                MessageBox.Show("✅ Верно!");
            else
                MessageBox.Show("❌ Неверно.");

            btnCheck.Visible = false;
            btnNext.Visible = true;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!isExampleStage)
            {
                int selected = rbOption1.Checked ? 1 : rbOption2.Checked ? 2 : rbOption3.Checked ? 3 : 0;
                if (selected == correctAnswerIndex)
                    correctAnswers++;
            }

            stage++;
            ShowStage();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form13 = new Form13(); // или ваша главная форма
            form13.Show();
        }
    }
}
