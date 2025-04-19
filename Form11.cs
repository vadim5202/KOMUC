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
    public partial class Form11 : Form
    {
        private int stage = 0;
        private int correctAnswers = 0;

        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex;
        public Form11()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            Label lblTitle = new Label
            {
                Text = "Распределение задач в команде",
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
                    lblContent.Text = "📘 Теория: Распределение задач в команде\n\n" +
                                      "Распределение задач в команде важно для достижения эффективности работы. Важно учитывать навыки каждого участника команды и правильно делегировать задачи.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "📌 Вопрос: В вашей команде работают несколько человек, и необходимо распределить задачи. Как вы поступите? \n\n" +
                                      "Ответ: Определить приоритетные задачи, принять ко вниманию навыки и загрузку каждого сотрудника, " +
                                      "четко распределю обязанности и установлю сроки, обеспечивая контроль выполнения.\n";
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6):\n\n" +
                                      "Что важно учитывать при распределении задач в команде?";
                    ShowTestOptions("A) Сильные стороны каждого сотрудника", "B) Только общие цели", "C) Как можно быстрее выполнить все задачи", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6):\n\n" +
                                      "Какой способ распределения задач наиболее эффективен?";
                    ShowTestOptions("A) Разделение задач по уровням сложности", "B) Все задачи раздаются одинаково", "C) Учитывать личные предпочтения сотрудников", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6):\n\n" +
                                      "Какая проблема может возникнуть при неправильном распределении задач?";
                    ShowTestOptions("A) Несоответствие задач с квалификацией сотрудников", "B) Увлажнение рабочих сроков", "C) Повышение производительности", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6):\n\n" +
                                      "Как важно следить за выполнением задач в процессе работы?";
                    ShowTestOptions("A) Для выявления проблем на раннем этапе", "B) Чтобы работники чувствовали давление", "C) Это не важно", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6):\n\n" +
                                      "Что важно в процессе распределения задач?\n";
                    ShowTestOptions("A) Четкие сроки и ответственность", "B) Давление на сотрудников", "C) Отсутствие критериев оценки", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6):\n\n" +
                                      "Какая ошибка может привести к ухудшению работы команды?";
                    ShowTestOptions("A) Не учитывать загруженность каждого сотрудника", "B) Объяснять задачи очень подробно", "C) Делегировать все задачи одному сотруднику", 1);
                    break;

                case 8:
                    string resultMessage;
                    if (correctAnswers >= 5)
                        resultMessage = "🎉 Отлично! Вы понимаете, как эффективно распределять задачи.";
                    else if (correctAnswers >= 3)
                        resultMessage = "✅ Неплохо, но стоит улучшить распределение задач.";
                    else
                        resultMessage = "❌ Нужно больше внимания к распределению задач.";

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
            int selectedAnswer = rbOption1.
Checked ? 1 : rbOption2.Checked ? 2 : rbOption3.Checked ? 3 : 0;

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
        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
