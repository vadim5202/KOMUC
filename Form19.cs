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
    public partial class Form19 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form19()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Правила оформления покупок и кассовой дисциплины",
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
                    lblContent.Text = "📘 Теория: Правила оформления покупок и кассовая дисциплина\n\n" +
                                      "Правильное оформление покупок и соблюдение кассовой дисциплины — это важный аспект работы продавца. " +
"Это включает в себя правильное заполнение чеков, соблюдение стандартов по работе с кассой и документами.\n\n" +
                                      "🔹 Основные моменты:\n" +
                                      "- Каждая покупка должна быть оформлена чеком.\n" +
                                      "- Чек должен содержать данные о товаре, сумме и налогах.\n" +
                                      "- Кассир обязан выдать клиенту чек и правильно провести оплату.\n" +
                                      "- Ошибки в оформлении чека могут привести к штрафам и недовольству клиентов.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "Кассир оформляет покупку товара на сумму 500 ₽. После проведения транзакции клиенту не был выдан чек.\n\n" +
                                      "📌 Вопрос: Какие нарушения были допущены в данной ситуации?\n\n" +
                                      "Ответ: Не был выдан чек.";

                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Какой документ должен быть выдан покупателю при каждой покупке?";
                    ShowTestOptions("A) Кассовый чек", "B) Счет-фактура", "C) Товарная накладная", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Какую информацию должен содержать чек?";
                    ShowTestOptions("A) Данные о товаре, сумме и налогах", "B) Только сумму покупки", "C) Товары и скидки", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Что может произойти, если покупателю не выдан чек?";
                    ShowTestOptions("A) Штрафы и недовольство клиента", "B) Не произойдут последствия", "C) Время на оплату увеличится", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Какая информация должна быть указана на кассовом чеке?";
                    ShowTestOptions("A) Товары, цена, сумма и налог", "B) Только наименование товара", "C) Только цена товара", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Кассир обязан при каждой покупке...";
                    ShowTestOptions("A) Выдавать клиенту чек", "B) Пропускать оформление покупки", "C) Списывать товар вручную", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Что может случиться в случае ошибок при оформлении покупки?";
                    ShowTestOptions("A) Штрафы и возможные претензии", "B) Ничего не произойдёт", "C) Увеличение прибыли магазина", 1);
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
                        resultMessage = "🎉 Отличный результат! Вы отлично усвоили правила оформления покупок и кассовой дисциплины!";
                    }

                    lblContent.Text = $"🎉 Задание завершено!\n\nПравильных ответов: {correctAnswers}/6\n\n{resultMessage}";
                    btnNext.Text = "Закрыть";
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void Form19_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
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
