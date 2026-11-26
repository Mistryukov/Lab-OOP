using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLib
{
    /// <summary>
    /// Хранит множество объектов класса Person. Позволяет проводить операции
    /// над отдельными объектами и группами объектов класса Person
    /// </summary>
    public class PersonList
    {
        //TODO: XML
        private const int DefaultListLenght = 4;

        //TODO: XML
        private const int GrowthFactor = 2;
        
        /// <summary>
        /// Приватный массив элементов класса Person
        /// </summary>
        private Person[] _items;

        /// <summary>
        /// Приватный счетчик элементов массива объектов класса Person
        /// </summary>
        private int _count;

        /// <summary>
        /// Свойство объекта класса PersonList "Счетчик элементов"
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию объекта класса PersonList
        /// </summary>
        public PersonList()
        {
            _items = new Person[DefaultListLenght];
            _count = 0;
        }

        /// <summary>
        /// Добавляет существующую персону в список
        /// </summary>
        /// <param name="item"></param>
        public void Add(Person item)
        {
            if (_count == _items.Length)
            {
                Expand();
            }
            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Увеличивает размер списка в заданное количество раз
        /// </summary>
        private void Expand()
        {
            Person[] newItems = new Person[_items.Length * GrowthFactor];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        /// <summary>
        /// Уменьшает размер списка в заданное количество раз
        /// </summary>
        private void Shrink()
        {
            Person[] newItems = new Person[_items.Length / GrowthFactor];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        /// <summary>
        /// Проверяет подаваемый индекс на  выход за допустимые границы
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void IndexCheck(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        //TODO: XML
        public Person this[int index]
        {
            get
            {
                IndexCheck(index);
                return _items[index];
            }
            set
            {
                IndexCheck(index);
                _items[index] = value;
            }
        }

        /// <summary>
        /// Удаляет из списка персону, соответствующую заданному индексу
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            IndexCheck(index);
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            if (_count == _items.Length / 2)
            {
                Shrink();
            }
            _items[_count] = null;
        }

        /// <summary>
        /// Возвращает индекс персоны из списка по заданному названию персоны
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Индекс персоны или "-1" при отсутствии персоны в списке</returns>
        public int IndexOf(Person item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Очищает список, удаляя всех персон
        /// </summary>
        public void ClearList()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = null;
            }
            _count = 0;
        }

        /// <summary>
        /// Удаляет из списка персону по заданному названию
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Person item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }
    }
}
