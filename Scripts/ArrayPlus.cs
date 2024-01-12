
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonLab
{
    public class ArrayPlus : UdonSharpBehaviour
    {
        public static T[] Add<T>(ref T[] _array, T _value, bool duplicates = true)
        {
            if (!duplicates)
            {
                int _index = Index(_array, _value);
                if (_index != -1)
                    return _array;
            }
            T[] _newArray = new T[_array.Length + 1];
            Array.Copy(_array, _newArray, _array.Length);
            _newArray[_array.Length] = _value;
            _array = _newArray;
            return _array;
        }
        public static T[] AddIndex<T>(ref T[] _array, T _value, int index, bool duplicates = true)
        {
            if (!duplicates)
            {
                int _index = Index(_array, _value);
                if (_index != -1)
                    return _array;
            }
            if (index < 0 || index > _array.Length)
            {
                return _array;
            }
            else if (index == _array.Length)
            {
                return Add(ref _array, _value);
            }
            else
            {
                T[] _newArray = new T[_array.Length + 1];
                for (int i = 0; i < index; i++)
                {
                    _newArray[i] = _array[i];
                }
                _newArray[index] = _value;
                for (int i = index + 1; i < _array.Length + 1; i++)
                {
                    _newArray[i] = _array[i - 1];
                }
                return _newArray;
            }
        }
        public static int Find<T>(T[] _array, T _value)
        {
            return Index(_array, _value);
        }
        public static int[] FindAll<T>(T[] _array, T _value)
        {
            int[] _index = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(_value))
                {
                    Add(ref _index, i);
                }
            }
            return _index;
        }
        public static T[] FindAllValue<T>(T[] _array, T _value)
        {
            T[] _newArray = new T[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(_value))
                {
                    Add(ref _newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int Index<T>(T[] _array, T _value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(_value))
                    return i;
            }
            return -1;
        }
        public static T[] RemoveIndex<T>(ref T[] _array, int index)
        {
            if (index < 0 || index >= _array.Length)
            {
                return _array;
            }
            else
            {
                T[] _newArray = new T[_array.Length - 1];
                for (int i = 0; i < index; i++)
                {
                    _newArray[i] = _array[i];
                }
                for (int i = index; i < _array.Length - 1; i++)
                {
                    _newArray[i] = _array[i + 1];
                }
                _array = _newArray;
                return _array;
            }
        }
        public static T[] Remove<T>(ref T[] _array, T _value)
        {
            int index = Index(_array, _value);
            if (index == -1)
                return _array;
            return RemoveIndex(ref _array, index);
        }
    }
}
