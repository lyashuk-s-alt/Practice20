using System;

namespace ExplicitInterfacesPractice
{
    // =========================================================================
    // ІНТЕРФЕЙСИ З ОДНАКОВИМИ МЕТОДАМИ
    // =========================================================================

    interface ILeft
    {
        void Execute();
    }

    interface IRight
    {
        void Execute();
    }

    // =========================================================================
    // КЛАС З ЯВНОЮ РЕАЛІЗАЦІЄЮ ІНТЕРФЕЙСІВ
    // =========================================================================

    class Controller : ILeft, IRight
    {
        // Явна реалізація методу інтерфейсу ILeft (модифікатор public заборонений)
        void ILeft.Execute()
        {
            Console.WriteLine("Виконано дію лівого контролера (ILeft.Execute): поворот ліворуч.");
        }

        // Явна реалізація методу інтерфейсу IRight (модифікатор public заборонений)
        void IRight.Execute()
        {
            Console.WriteLine("Виконано дію правого контролера (IRight.Execute): поворот праворуч.");
        }

        // Звичайний публічний метод самого класу для порівняння
        public void Status()
        {
            Console.WriteLine("Контролер активний та готовий до роботи.");
        }
    }

    // =========================================================================
    // ГОЛОВНИЙ КЛАС ПРОГРАМИ
    // =========================================================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо екземпляр класу Controller
            Controller controller = new Controller();

            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ: Виклик явно реалізованих методів ===\n");

            // Через звичайну змінну класу доступний лише власний публічний метод Status()
            controller.Status();

            // ПОМИЛКА КОМПІЛЯЦІЇ (закоментовано):
            // controller.Execute(); // Помилка CS1061: 'Controller' не містить визначення 'Execute'

            // Спосіб 1: Виклик через явне приведення типу в дужках
            Console.WriteLine("\n--- Спосіб 1: Пряме приведення типу ---");
            ((ILeft)controller).Execute();
            ((IRight)controller).Execute();

            // Спосіб 2: Збереження посилання у змінну відповідного інтерфейсного типу
            Console.WriteLine("\n--- Спосіб 2: Через інтерфейсні змінні ---");
            ILeft leftControl = controller;
            IRight rightControl = controller;

            leftControl.Execute();
            rightControl.Execute();
        }
    }
}
