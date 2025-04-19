using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_интерактивного_обучающего_пособия
{
    public partial class Form9 : Form
    {
        private int stage = 0;
        private int correctAnswers = 0;

        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex;
        public Form9()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            Label lblTitle = new Label
            {
                Text = "Введение переговоров",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50,
                ForeColor = Color.Black
            };
            this.Controls.Add(lblTitle);

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

            btnNext = new Button
            {
                Text = "Далее →",
                Dock = DockStyle.Bottom,
                Height = 40,
                ForeColor = Color.Black
            };
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            rbOption1 = new RadioButton { Visible = false, Dock = DockStyle.Top };
            rbOption2 = new RadioButton { Visible = false, Dock = DockStyle.Top };
            rbOption3 = new RadioButton { Visible = false, Dock = DockStyle.Top };
            this.Controls.Add(rbOption3);
            this.Controls.Add(rbOption2);
            this.Controls.Add(rbOption1);

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
            rbOption1.Visible = false;
            rbOption2.Visible = false;
            rbOption3.Visible = false;
            btnCheck.Visible = false;
            btnFinish.Visible = false;

            switch (stage)
            {
                case 0:
                    lblContent.Text = "📘 Теория: Основы переговоров\n\n" +
                                      "Переговоры - это процесс обмена мнениями, в ходе которого стороны пытаются достичь согласия по важным вопросам.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "📌 Вопрос: Вы вступаете в переговоры о цене для крупной партии офисной бумаги. Как начать переговоры? \n\n" +
                                      "Ответ:Начать переговоры стоит с приветствия и установления доверительного контакта, " +
                                      "затем уточнить потребности клиента и ожидания по цене, после чего предложить аргументированное ценовое предложение, " +
                                      "подчёркивая выгоды сотрудничества. \n";
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6):\n\n" +
                                      "Что важно сделать перед началом переговоров?";
                    ShowTestOptions("A) Выяснить потребности клиента", "B) Немедленно предложить скидку", "C) Избегать обсуждения условий", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6):\n\n" +
                                      "Какой подход считается самым эффективным в переговорах?";
                    ShowTestOptions("A) Win-Win", "B) Давление", "C) Игнорирование возражений", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6):\n\n" +
                                      "Что помогает убедить клиента в выгоде предложения?";
                    ShowTestOptions("A) Аргументация на основе фактов", "B) Навязывание мнения", "C) Повышение цены", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6):\n\n" +
                                      "Какой из способов переговоров поможет найти компромисс?";
                    ShowTestOptions("A) Уступки", "B) Жесткий торг", "C) Игнорирование", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6):\n\n" +
                                      "Как следует отвечать на возражения клиента?";
                    ShowTestOptions("A) Спокойно анализировать и находить решение", "B) Игнорировать", "C) Немедленно снижать цену", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6):\n\n" +
                                      "Что НЕ рекомендуется делать при переговорах?";
                    ShowTestOptions("A) Давить на клиента", "B) Уточнять его потребности", "C) Искать компромисс", 1);
                    break;

                case 8:
                    string resultMessage;
                    if (correctAnswers >= 5)
                        resultMessage = "🎉 Отлично! Вы хорошо ведете переговоры.";
                    else if (correctAnswers >= 3)
                        resultMessage = "✅ Неплохо, но есть куда расти.";
                    else
                        resultMessage = "❌ Стоит пересмотреть стратегию переговоров.";

                    lblContent.Text = $"📊 Итог:\n\nВы ответили правильно на {correctAnswers} из 6 вопросов.\n\n{resultMessage}";
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
        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
