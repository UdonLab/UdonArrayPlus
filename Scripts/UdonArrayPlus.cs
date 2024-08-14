using System;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

// Some work has a legacy of compatibility with UdonSharp 0.x version, and then I referred to some of Varneon's codes in the upgrade.
// Varneon's VUdon-ArrayExtensions license: MIT License
// Reference code: https://github.com/Varneon/VUdon-ArrayExtensions/blob/main/Packages/com.varneon.vudon.array-extensions/Runtime/UdonArrayExtensions.cs

namespace UdonLab
{
    public class UdonArrayPlus : UdonSharpBehaviour
    {
        public static T[] Add<T>(T[] _array, T _value, bool duplicates = true)
        {
            if (!duplicates)
            {
                if (IndexOf(_array, _value) != -1)
                    return _array;
            }
            var length = _array.Length;
            var _newArray = new T[length + 1];
            Array.Copy(_array, _newArray, length);
            _newArray.SetValue(_value, length);
            return _newArray;
        }
        public static T[] Add<T>(ref T[] _array, T _value, bool duplicates = true)
        {
            return _array = Add(_array, _value, duplicates);
        }
        public static T[] Insert<T>(T[] array, int index, T item, bool duplicates = true)
        {
            if (!duplicates)
            {
                if (IndexOf(array, item) != -1)
                    return array;
            }
            var length = array.Length;

            index = Mathf.Clamp(index, 0, length);

            var newArray = new T[length + 1];

            newArray.SetValue(item, index);

            if (index == 0)
            {
                Array.Copy(array, 0, newArray, 1, length);
            }
            else if (index == length)
            {
                Array.Copy(array, 0, newArray, 0, length);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index, newArray, index + 1, length - index);
            }

            return newArray;
        }
        public static T[] Insert<T>(ref T[] array, int index, T item, bool duplicates = true)
        {
            return array = Insert(array, index, item, duplicates);
        }
        public static bool Contains<T>(T[] array, T item)
        {
            return IndexOf(array, item) >= 0;
        }
        public static int[] FindAll<T>(T[] _array, T _value)
        {
            var _indexs = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(_value))
                {
                    _indexs = Add(_indexs, i);
                }
            }
            return _indexs;
        }
        public static T[] FindAllValue<T>(T[] _array, T _value)
        {
            var _newArray = new T[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(_value))
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int IndexOf<T>(T[] _array, T _value)
        {
            return Array.IndexOf(_array, _value);
        }
        public static int IndexOf<T>(T[] _array, T _value, out int index)
        {
            return index = Array.IndexOf(_array, _value);
        }
        public static T[] RemoveAt<T>(T[] array, int index)
        {
            int length = array.Length;

            if (index >= length || index < 0) { return array; }

            int maxIndex = length - 1;

            T[] newArray = new T[maxIndex];

            if (index == 0)
            {
                Array.Copy(array, 1, newArray, 0, maxIndex);
            }
            else if (index == maxIndex)
            {
                Array.Copy(array, 0, newArray, 0, maxIndex);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, maxIndex - index);
            }

            return newArray;
        }
        public static T[] RemoveAt<T>(ref T[] array, int index)
        {
            return array = RemoveAt(array, index);
        }
        public static T[] Remove<T>(T[] _array, T _value)
        {
            var index = IndexOf(_array, _value);
            if (index == -1)
                return _array;
            return RemoveAt(_array, index);
        }
        public static T[] Remove<T>(ref T[] _array, T _value)
        {
            return _array = Remove(_array, _value);
        }
        // String
        public static string[] StringsFindLikeAll(string[] _array, string _value)
        {
            string[] _newArray = new string[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Contains(_value))
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        // VRCUrl
        public static VRCUrl[] VRCUrlsFindLikeAll(VRCUrl[] _array, string _value)
        {
            VRCUrl[] _newArray = new VRCUrl[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].ToString().Contains(_value))
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        // Int
        public static int[] IntsSort(int[] _array, bool reverse = false)
        {
            int[] _newArray = new int[_array.Length];
            _array.CopyTo(_newArray, 0);
            if (!reverse)
            {
                for (int i = 0; i < _newArray.Length - 1; i++)
                    for (int j = i + 1; j < _newArray.Length; j++)
                        if (_newArray[i] > _newArray[j])
                            (_newArray[j], _newArray[i]) = (_newArray[i], _newArray[j]);
            }
            else
            {
                for (int i = 0; i < _newArray.Length - 1; i++)
                    for (int j = i + 1; j < _newArray.Length; j++)
                        if (_newArray[i] < _newArray[j])
                            (_newArray[j], _newArray[i]) = (_newArray[i], _newArray[j]);
            }
            return _newArray;
        }
        public static int[] IntsSort(ref int[] _array, bool reverse = false)
        {
            return _array = IntsSort(_array, reverse);
        }
        // Float
        public static float[] FloatsSort(float[] _array, bool reverse)
        {
            float[] _newArray = new float[_array.Length];
            _array.CopyTo(_newArray, 0);
            if (!reverse)
            {
                for (int i = 0; i < _newArray.Length - 1; i++)
                    for (int j = i + 1; j < _newArray.Length; j++)
                        if (_newArray[i] > _newArray[j])
                            (_newArray[j], _newArray[i]) = (_newArray[i], _newArray[j]);
            }
            else
            {
                for (int i = 0; i < _newArray.Length - 1; i++)
                    for (int j = i + 1; j < _newArray.Length; j++)
                        if (_newArray[i] < _newArray[j])
                            (_newArray[j], _newArray[i]) = (_newArray[i], _newArray[j]);
            }
            return _newArray;
        }
        public static float[] FloatsSort(ref float[] _array, bool reverse)
        {
            return _array = FloatsSort(_array, reverse);
        }
        // VRCPlayerApi
        public static VRCPlayerApi[] Players()
        {
            VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
            players = VRCPlayerApi.GetPlayers(players);
            return players;
        }
        public static VRCPlayerApi PlayersFindID(VRCPlayerApi[] players, int _id)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].playerId == _id)
                    return players[i];
            }
            return null;
        }
        public static VRCPlayerApi PlayersFindName(VRCPlayerApi[] players, string _name)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].displayName == _name)
                    return players[i];
            }
            return null;
        }
        public static int PlayersIndex(VRCPlayerApi[] players, VRCPlayerApi _player)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] == _player)
                    return i;
            }
            return -1;
        }
        public static int PlayersIndexID(VRCPlayerApi[] players, int _id)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].playerId == _id)
                    return i;
            }
            return -1;
        }
        public static int PlayersIndexName(VRCPlayerApi[] players, string _name)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].displayName == _name)
                    return i;
            }
            return -1;
        }
        public static VRCPlayerApi[] PlayersAdd(VRCPlayerApi[] players, VRCPlayerApi _player, bool force = false)
        {
            var index = PlayersIndex(players, _player);
            if (index != -1 && !force)
                return players;
            VRCPlayerApi[] newPlayers = new VRCPlayerApi[players.Length + 1];
            Array.Copy(players, newPlayers, players.Length);
            newPlayers[players.Length] = _player;
            return newPlayers;
        }
        public static VRCPlayerApi[] PlayersAdd(ref VRCPlayerApi[] players, VRCPlayerApi _player, bool force = false)
        {
            return players = PlayersAdd(players, _player, force);
        }
        public static VRCPlayerApi[] PlayersAddIndex(VRCPlayerApi[] players, VRCPlayerApi _player, int index, bool force = false)
        {
            if (index < 0 || index > players.Length)
            {
                return players;
            }
            else if (index == players.Length)
            {
                return PlayersAdd(players, _player);
            }
            else
            {
                int _index = PlayersIndex(players, _player);
                if (_index != -1 && !force)
                    return players;
                VRCPlayerApi[] newPlayers = new VRCPlayerApi[players.Length + 1];
                for (int i = 0; i < index; i++)
                {
                    newPlayers[i] = players[i];
                }
                newPlayers[index] = _player;
                for (int i = index + 1; i < players.Length + 1; i++)
                {
                    newPlayers[i] = players[i - 1];
                }
                return newPlayers;
            }
        }
        public static VRCPlayerApi[] PlayersAddIndex(ref VRCPlayerApi[] players, VRCPlayerApi _player, int index, bool force = false)
        {
            return players = PlayersAddIndex(players, _player, index, force);
        }
        public static VRCPlayerApi[] PlayersRemove(VRCPlayerApi[] players, VRCPlayerApi _player)
        {
            var index = PlayersIndex(players, _player);
            if (index == -1)
            {
                return players;
            }
            else
            {
                VRCPlayerApi[] newPlayers = new VRCPlayerApi[players.Length - 1];
                for (int i = 0; i < index; i++)
                {
                    newPlayers[i] = players[i];
                }
                for (int i = index; i < players.Length - 1; i++)
                {
                    newPlayers[i] = players[i + 1];
                }
                return newPlayers;
            }
        }
        public static VRCPlayerApi[] PlayersRemove(ref VRCPlayerApi[] players, VRCPlayerApi _player)
        {
            return players = PlayersRemove(players, _player);
        }
        public static VRCPlayerApi PlayersFindID(int _id)
        {
            VRCPlayerApi[] players = Players();
            return PlayersFindID(players, _id);
        }
        public static VRCPlayerApi PlayersFindName(string _name)
        {
            VRCPlayerApi[] players = Players();
            return PlayersFindName(players, _name);
        }
        // gameobject
        public static GameObject[] GameObjectsFindNameLikeAll(GameObject[] _array, string _name)
        {
            GameObject[] _newArray = new GameObject[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name.Contains(_name))
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static GameObject GameObjectsFindName(GameObject[] _array, string _name)
        {
            var index = GameObjectsIndexName(_array, _name);
            return index == -1 ? null : _array[index];
        }
        public static GameObject[] GameObjectsFindNameAll(GameObject[] _array, string _name)
        {
            GameObject[] _newArray = new GameObject[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int GameObjectsIndexName(GameObject[] _array, string _name)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                    return i;
            }
            return -1;
        }
        public static int[] GameObjectsIndexNameAll(GameObject[] _array, string _name)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static GameObject[] GameObjectsIndexNameAllValue(GameObject[] _array, string _name)
        {
            return GameObjectsFindNameAll(_array, _name);
        }
        // UdonBehaviour
        public static UdonBehaviour UdonBehavioursFindName(UdonBehaviour[] _array, string _name)
        {
            var index = UdonBehavioursIndexName(_array, _name);
            return index == -1 ? null : _array[index];
        }
        public static UdonBehaviour[] UdonBehavioursFindNameAll(UdonBehaviour[] _array, string _name)
        {
            UdonBehaviour[] _newArray = new UdonBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int[] UdonBehavioursIndexProgramVariable(UdonBehaviour[] _array, string programVariable)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) != null)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static int[] UdonBehavioursIndexProgramVariableValue(UdonBehaviour[] _array, string programVariable, object _value)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) == _value)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static UdonBehaviour[] UdonBehavioursFindProgramVariable(UdonBehaviour[] _array, string programVariable)
        {
            UdonBehaviour[] _newArray = new UdonBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) != null)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static UdonBehaviour[] UdonBehavioursFindProgramVariableValue(UdonBehaviour[] _array, string programVariable, object _value)
        {
            UdonBehaviour[] _newArray = new UdonBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) == _value)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int UdonBehavioursIndexName(UdonBehaviour[] _array, string _name)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                    return i;
            }
            return -1;
        }
        public static int[] UdonBehavioursIndexNameAll(UdonBehaviour[] _array, string _name)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        // UdonSharpBehaviour
        public static UdonSharpBehaviour[] UdonSharpBehavioursFindNameLikeAll(UdonSharpBehaviour[] _array, string _name)
        {
            UdonSharpBehaviour[] _newArray = new UdonSharpBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name.Contains(_name))
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static UdonSharpBehaviour UdonSharpBehavioursFindName(UdonSharpBehaviour[] _array, string _name)
        {
            var index = UdonSharpBehavioursIndexName(_array, _name);
            return index == -1 ? null : _array[index];
        }
        public static UdonSharpBehaviour[] UdonSharpBehavioursFindNameAll(UdonSharpBehaviour[] _array, string _name)
        {
            UdonSharpBehaviour[] _newArray = new UdonSharpBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int[] UdonSharpBehavioursIndexNameLikeAll(UdonSharpBehaviour[] _array, string _name)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name.Contains(_name))
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static int UdonSharpBehavioursIndexName(UdonSharpBehaviour[] _array, string _name)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                    return i;
            }
            return -1;
        }
        public static int[] UdonSharpBehavioursIndexNameAll(UdonSharpBehaviour[] _array, string _name)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].name == _name)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static UdonSharpBehaviour[] UdonSharpBehavioursFindTypeNameStartsWithAll(UdonSharpBehaviour[] _array, string typeName)
        {
            UdonSharpBehaviour[] _newArray = new UdonSharpBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetUdonTypeName().StartsWith(typeName))
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static UdonSharpBehaviour UdonSharpBehavioursFindTypeName(UdonSharpBehaviour[] _array, string typeName)
        {
            var index = UdonSharpBehavioursIndexTypeName(_array, typeName);
            return index == -1 ? null : _array[index];
        }
        public static UdonSharpBehaviour[] UdonSharpBehavioursFindTypeNameAll(UdonSharpBehaviour[] _array, string typeName)
        {
            UdonSharpBehaviour[] _newArray = new UdonSharpBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetUdonTypeName() == typeName)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int[] UdonSharpBehavioursIndexTypeNameStartsWithAll(UdonSharpBehaviour[] _array, string typeName)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetUdonTypeName().StartsWith(typeName))
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static int UdonSharpBehavioursIndexTypeName(UdonSharpBehaviour[] _array, string typeName)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetUdonTypeName() == typeName)
                    return i;
            }
            return -1;
        }
        public static int[] UdonSharpBehavioursIndexTypeNameAll(UdonSharpBehaviour[] _array, string typeName)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetUdonTypeName() == typeName)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static UdonSharpBehaviour[] UdonSharpBehavioursFindProgramVariable(UdonSharpBehaviour[] _array, string programVariable)
        {
            UdonSharpBehaviour[] _newArray = new UdonSharpBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) != null)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static UdonSharpBehaviour[] UdonSharpBehavioursFindProgramVariableValue(UdonSharpBehaviour[] _array, string programVariable, object _value)
        {
            UdonSharpBehaviour[] _newArray = new UdonSharpBehaviour[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) == _value)
                {
                    _newArray = Add(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int[] UdonSharpBehavioursIndexProgramVariable(UdonSharpBehaviour[] _array, string programVariable)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) != null)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
        public static int[] UdonSharpBehavioursIndexProgramVariableValue(UdonSharpBehaviour[] _array, string programVariable, object _value)
        {
            int[] _newArray = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].GetProgramVariable(programVariable) == _value)
                {
                    _newArray = Add(_newArray, i);
                }
            }
            return _newArray;
        }
    }
}
