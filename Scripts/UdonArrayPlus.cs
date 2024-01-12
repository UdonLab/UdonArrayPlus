using System;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonLab
{
    public class UdonArrayPlus : UdonSharpBehaviour
    {
        public static T[] Add<T>(T[] _array, T _value, bool duplicates = true)
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
            return _newArray;
        }
        public static T[] AddIndex<T>(T[] _array, T _value, int index, bool duplicates = true)
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
                return Add(_array, _value);
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
                    _index = Add(_index, i);
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
                    _newArray = Add(_newArray, _array[i]);
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
        public static T[] RemoveIndex<T>(T[] _array, int index)
        {
            if (index < 0 || index >= _array.Length)
                return _array;
            T[] _newArray = new T[_array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                _newArray[i] = _array[i];
            }
            for (int i = index; i < _array.Length - 1; i++)
            {
                _newArray[i] = _array[i + 1];
            }
            return _newArray;
        }
        public static T[] Remove<T>(T[] _array, T _value)
        {
            int index = Index(_array, _value);
            if (index == -1)
                return _array;
            return RemoveIndex(_array, index);
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
        public static int VRCUrlsFind(VRCUrl[] _array, VRCUrl _value)
        {
            return VRCUrlsIndex(_array, _value);
        }
        public static int[] VRCUrlsFindAll(VRCUrl[] _array, VRCUrl _value)
        {
            int[] _index = new int[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].ToString() == _value.ToString())
                {
                    _index = Add(_index, i);
                }
            }
            return _index;
        }
        public static VRCUrl[] VRCUrlsFindAllValue(VRCUrl[] _array, VRCUrl _value)
        {
            VRCUrl[] _newArray = new VRCUrl[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].ToString() == _value.ToString())
                {
                    _newArray = VRCUrlsAdd(_newArray, _array[i]);
                }
            }
            return _newArray;
        }
        public static int VRCUrlsIndex(VRCUrl[] _array, VRCUrl _value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].ToString() == _value.ToString())
                    return i;
            }
            return -1;
        }
        public static VRCUrl[] VRCUrlsAdd(VRCUrl[] _array, VRCUrl _value, bool duplicates = true)
        {
            if (!duplicates)
            {
                int _index = VRCUrlsIndex(_array, _value);
                if (_index != -1)
                    return _array;
            }
            VRCUrl[] _newArray = new VRCUrl[_array.Length + 1];
            Array.Copy(_array, _newArray, _array.Length);
            _newArray[_array.Length] = _value;
            return _newArray;
        }
        public static VRCUrl[] VRCUrlsAddIndex(VRCUrl[] _array, VRCUrl _value, int index, bool duplicates = true)
        {
            if (!duplicates)
            {
                int _index = VRCUrlsIndex(_array, _value);
                if (_index != -1)
                    return _array;
            }
            if (index < 0 || index > _array.Length)
            {
                return _array;
            }
            else if (index == _array.Length)
            {
                return VRCUrlsAdd(_array, _value);
            }
            else
            {
                VRCUrl[] _newArray = new VRCUrl[_array.Length + 1];
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
        public static VRCUrl[] VRCUrlsRemoveIndex(VRCUrl[] _array, int index)
        {
            return RemoveIndex(_array, index);
        }
        public static VRCUrl[] VRCUrlsRemove(VRCUrl[] _array, VRCUrl _value)
        {
            int index = VRCUrlsIndex(_array, _value);
            if (index == -1)
                return _array;
            return RemoveIndex(_array, index);
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
            int index = PlayersIndex(players, _player);
            if (index != -1 && !force)
                return players;
            VRCPlayerApi[] newPlayers = new VRCPlayerApi[players.Length + 1];
            Array.Copy(players, newPlayers, players.Length);
            newPlayers[players.Length] = _player;
            return newPlayers;
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
        public static VRCPlayerApi[] PlayersRemove(VRCPlayerApi[] players, VRCPlayerApi _player)
        {
            int index = PlayersIndex(players, _player);
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
