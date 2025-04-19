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
    public partial class Form16 : Form
    {
        private int stage = 0; // Этап задания
        private int correctAnswers = 0; // Количество правильных ответов
        private Label lblContent;
        private Button btnNext, btnCheck, btnFinish;
        private RadioButton rbOption1, rbOption2, rbOption3;
        private int correctAnswerIndex; // Индекс правильного ответа
        public Form16()
        {
            InitializeComponent();
            SetupUI();
            ShowStage();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }
        private void SetupUI()
        {
            // Заголовок
            Label lblTitle = new Label
            {
                Text = "Знание ассортимента товара",
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
                    lblContent.Text = "📘 Теория: Знание ассортимента товаров\n\n" +
                                      "Знание ассортимента — это ключевой навык для продавца-консультанта. " +
                                      "Оно включает в себя знание характеристик, особенностей и различий товаров, " +
"чтобы эффективно предложить покупателю наилучший вариант.\n\n" +
                                      "🔹 Важные аспекты ассортимента:\n" +
                                      "- Разнообразие товаров: продавец должен понимать все категории товаров в магазине.\n" +
                                      "- Характеристики товаров: знание технических характеристик, размера, цвета и прочих особенностей.\n" +
                                      "- Специальные предложения: продавец должен быть в курсе всех акций, скидок и бонусов.";
                    break;

                case 1:
                    lblContent.Text = "📊 Пример:\n\n" +
                                      "В магазине продаются три модели телевизоров: A, B и C. Модель A имеет 4K разрешение, " +
                                      "модель B — Smart TV, а модель C — обладает лучшими динамиками и звуковой системой.\n\n" +
                                      "📌 Вопрос: Какую модель лучше предложить клиенту, который ищет телевизор с лучшим качеством изображения?";
                    break;

                case 2:
                    lblContent.Text = "❓ Тест (вопрос 1/6): Что важно знать о товаре при консультации покупателя?";
                    ShowTestOptions("A) Цвет товара", "B) Характеристики товара", "C) История бренда", 2);
                    break;

                case 3:
                    lblContent.Text = "❓ Тест (вопрос 2/6): Какой аспект ассортимента важен для предложения товаров с учетом потребностей клиента?";
                    ShowTestOptions("A) Разнообразие товаров", "B) Специальные предложения", "C) Страна производства", 1);
                    break;

                case 4:
                    lblContent.Text = "❓ Тест (вопрос 3/6): Какую информацию продавец должен знать о скидках и акциях в магазине?";
                    ShowTestOptions("A) Все скидки и акции", "B) Только скидки на товары популярных брендов", "C) Скидки на товары в наличии", 1);
                    break;

                case 5:
                    lblContent.Text = "❓ Тест (вопрос 4/6): Что нужно учитывать при выборе товара для клиента?";
                    ShowTestOptions("A) Предпочтения и требования клиента", "B) Личные предпочтения консультанта", "C) Только бренд товара", 1);
                    break;

                case 6:
                    lblContent.Text = "❓ Тест (вопрос 5/6): Какой из этих факторов важен при консультировании по телевизорам?";
                    ShowTestOptions("A) Характеристики изображения", "B) Объем памяти", "C) Тип коробки", 1);
                    break;

                case 7:
                    lblContent.Text = "❓ Тест (вопрос 6/6): Какую модель телевизора порекомендуете клиенту, который хочет качественное изображение?";
                    ShowTestOptions("A) Модель с 4K разрешением", "B) Модель с лучшими динамиками", "C) Модель с большим экраном", 1);
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
                        resultMessage = "🎉 Отличный результат! Вы хорошо разбираетесь в ассортименте товаров!";
                    }

                    lblContent.Text = $"🎉 Задание завершено!\n\nПравильных ответов: {correctAnswers}/6\n\n{resultMessage}";
                    btnNext.Text = "Закрыть";
                    btnFinish.Visible = true;
                    break;
            }
        }

        private void Form16_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
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
