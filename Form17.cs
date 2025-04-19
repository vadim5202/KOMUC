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
    public partial class Form17 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form17()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Работа с возражениями клиента",
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
                    lblContent.Text = "📘 Теория: Как работать с возражениями клиента?\n\n" +
                                      "Возражения клиентов — это нормальная часть процесса продажи, и важно правильно на них реагировать. " +
                                      "Чем лучше продавец умеет работать с возражениями, тем выше вероятность успешной сделки.\n\n" +
                                      "🔹 Техники работы с возражениями:\n" +
                                      "- Слушайте возражение клиента внимательно.\n" +
                                      "- Подтвердите его точку зрения и покажите понимание.\n" +
                                      "- Представьте решение проблемы.\n" +
                                      "- Предложите альтернативу.\n" +
                                      "- Убедитесь в том, что клиент доволен результатом.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "Клиент говорит: 'Этот товар слишком дорогой!'\n\n" +
                                      "📌 Вопрос: Как вы должны отреагировать на это возражение?";
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Какую технику лучше всего использовать для обработки возражений?";
                    ShowTestOptions("A) Слушать возражение клиента", "B) Игнорировать возражение", "C) Объяснить, что клиент не прав", 1);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Какую реакцию будет лучше всего вызвать у клиента на возражение о высокой цене?";
                    ShowTestOptions("A) Согласиться с клиентом и показать альтернативу", "B) Игнорировать его мнение", "C) Попросить клиента уйти", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Какое из этих утверждений является эффективной техникой работы с возражением?";
                    ShowTestOptions("A) Подтвердить точку зрения клиента", "B) Начать спорить с клиентом", "C) Напомнить клиенту об акциях", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Что важно делать, когда клиент выражает сомнение в качестве товара?";
                    ShowTestOptions("A) Показать преимущества товара", "B) Подтвердить сомнение клиента", "C) Сказать, что товар не может быть плохим", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Как лучше всего предложить альтернативу клиенту?";
                    ShowTestOptions("A) Спросить, что именно не устраивает клиента и предложить другой вариант", "B) Просто указать на товары с меньшей ценой", "C) Принудительно предложить новый товар", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Как лучше всего завершить работу с возражением?";
                    ShowTestOptions("A) Убедиться, что клиент доволен решением", "B) Игнорировать клиентское мнение", "C) Оставить клиента без ответа", 1);
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
                        resultMessage = "🎉 Отличный результат! Вы хорошо знаете, как работать с возражениями!";
                    }

                    lblContent.Text = $"🎉 Задание завершено!\n\nПравильных ответов: {correctAnswers}/6\n\n{resultMessage}";
                    btnNext.Text = "Закрыть";
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void Form17_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form17_FormClosing(object sender, FormClosingEventArgs e)
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
