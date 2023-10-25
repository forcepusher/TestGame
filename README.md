# TestGame
  
Поиграть в вебе можно тут https://forcepusher.github.io/test/  
В папке Builds/Android билд для Android.  
  
- В игре реализована возможность одновременного действия эффектов от нескольких монеток, в том числе одинаковых накладывающихся друг на друга эффектов.  
- Используется DI фреймворк Reflex для проброса зависимостей (альтернатива Zenject или VContainer).  
- Так же для UI использовался UniRx, хоть и тут UI кода совсем немного.  
- Класс CrossPlatformInput удалось реализовать на асинхронных тиках благодаря юнитивской имплементации SynchronizationContext и Task.Yield(). Он так же реализует IDisposable и инъектится в Character паттерном стратегия, через интерфейс IInputSource.  
- Полностью соблюден LSP и OCP для реализации новых монеток. Все необходимые свойства для модификации поведения персонажа раскрыты в интерфейсе IRunner, который используется для соблюдения DIP, чтобы зависимости были от абстракции, а не от конкретики класса Character.  
- Интерфейс IRunner наследует интерфейс IEffectTarget для возможности добавления эффектов.  
- В игре реализован бесконечный генератор уровня, который так же соблюдает LSP и OCP для добавления новых монеток.  
- Везде на сколько возможно поддерживается SRP.  
- Эффекты монеток и ввод реализованы без MonoBehaviour.  
