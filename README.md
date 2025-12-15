# BHS-test
Папка BHS test - задание 1
Файл review.cs - задание 2
## Задание 3
### Избыточное выделение памяти
Вызов "ToList()" создает промежуточный список в памяти, который хранит все отфильтрованные элементы.
### Двойная итерация коллекции
"Where()" создает отложенное выполнение, но "ToList()" форсирует итерацию всех элементов, затем "Count" обращается к свойству списка.
### Дублирование стандартного функционала
В LINQ уже есть "Count(predicate)", который делает ровно то же самое, но эффективнее
### Отсутствие валидации
Нет проверки входных параметров на "null"
## Улучшенное решение
```C#
public static class EnumerableExtensions
{
    // Вариант 1: Если действительно нужен свой метод
    public static int FilterAndCount<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        
        // Без ToList() - одна итерация
        return items.Count(predicate);
    }
    
    // Вариант 2: Просто используйте стандартный LINQ
    // items.Count(predicate) - нет необходимости в extension методе
}
```