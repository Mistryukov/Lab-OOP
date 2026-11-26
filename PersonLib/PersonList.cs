using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLib
{
    /// <summary>
    /// //TODO: RSDN +
    /// Хранит множество объектов класса Person. Позволяет проводить операции
    /// над отдельными объектами и группами объектов класса Person
    /// </summary>
    public class PersonList
    {
        //TODO: XML +
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
            //TODO: refactor
            _items = new Person[4];
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

        private void Expand()
        {
            //TODO: RSDN +
            Person[] newItems = new Person[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        private void Shrink()
        {
            Person[] newItems = new Person[_items.Length / 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        public void IndexCheck(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public Person this[int index]
        {
            get
            {
                //TODO: RSDN  +
                //TODO: duplication +
                IndexCheck(index);
                //TODO: {} +
                return _items[index];
            }
            set
            {
                //TODO: duplication +
                IndexCheck(index);
                //TODO: {} +
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
            //TODO: refactor +
            //TODO: duplication +
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
            //TODO: not safe
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
