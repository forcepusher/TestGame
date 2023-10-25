# TestGame
  
Поиграть в вебе можно тут https://forcepusher.github.io/test/  
В папке Builds/Android билд для Android.  
  
- В игре реализована возможность одновременного действия эффектов от нескольких монеток, в том числе одинаковых накладывающихся друг на друга эффектов.  
- Используется DI фреймворк Reflex для проброса зависимостей (аналог Zenject или VContainer). Уменьшение связанности, тестируемость, разделение ответственностей, легкость замены компонентов.  
- Так же для UI использовался UniRx. UI кода тут немного, используется для демонстрации отвязки логики игровой симуляции от слоя UI.  
- Класс CrossPlatformInput реализован на асинхронных тиках. Так же он реализует IDisposable и инъектится в Character паттерном стратегия, через интерфейс IInputSource.  
- Полностью соблюден LSP и OCP для реализации монеток с новыми эффектами. Все необходимые свойства для модификации поведения персонажа раскрыты в интерфейсе IRunner, который используется для соблюдения DIP, чтобы зависимости были от абстракции, а не от конкретики класса Character.  
- В игре реализован бесконечный генератор уровня, который так же соблюдает LSP и OCP для добавления монеток с новыми эффектами.  
- Везде на сколько возможно поддерживается SRP.  
- Эффекты монеток и ввод реализованы без MonoBehaviour.  
- Отсутствуют циклические зависимости.  