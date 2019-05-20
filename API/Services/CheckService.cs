using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckApp.Services
{
    public class CheckService : ICheckService
    {
        private string[] _words =
            { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Hundred", "Thousand", "Million", "Billion", "Trillion",
            "Eleven", "Twelve", "Twen", "Thir", "teen", "ty", "Fif",
            "Dollar", "Cent", "Zero" };
        private decimal _d = 0;
        private string _result;

        public CheckService()
        {

        }
        public CheckService(decimal n)
        {
            _d = n;

            Initialize();
        }


        public string Result => _result;

        public string MoneyToWords(decimal d)
        {
            _d = d;

            Initialize();

            return _result;
        }



        private string CreateString(ulong number)
        {
            _result = "";
            if (number == 0) return _result = _words[25] + " ";

            var groups = new Dictionary<int, Stack<int>>();
            var result = new Stack<string>();
            int groupId = 1;
            decimal n;
            ulong left = number;
            int right;
            int level;
            

            while (left > 0)
            {
                level = 1;
                var group = new Stack<int>();
                bool groupState = false;

                while (level <= 3)
                {
                    n = left * 0.1M;
                    left = (ulong)n;
                    right = (int)((n % 1) * 10);
                    group.Push(right);
                    groupState = right > 0 || (right == 0 && groupState == true) ? true : false;
                    level++;
                }

                if (groupState) groups.Add(groupId, group);

                groupId++;
            }

            foreach (var group in groups)
            {

                while (group.Value.Count > 0)
                {
                    var words = GetWords(group.Value);
                    var key = (group.Key > 1 ? _words[group.Key + 10] : "");
                    result.Push(words + (key.Length > 0 ? " " + key : ""));
                }
            }

            var count = result.Count;
            while (result.Count > 0)
            {
                var word = result.Pop();
                _result += (result.Count < count - 1 ? ", " : "") + word;
            }

            return _result;
        }



        private string GetWords(Stack<int> group)
        {
            string _1_s = "", _2_s = "", _3_s = "", group_s = "";
            int _1, _2, _3;

            _3 = group.Pop();   // 100
            _2 = group.Pop();   // 10
            _1 = group.Pop();   // 1

            if (_2 == 2) { _2_s = _words[18]; _2 = 21; }                            // 20 - 29
            if (_2 == 3) { _2_s = _words[19]; _2 = 21; }                            // 30 - 39
            if (_2 == 4) { _2_s = _words[_2]; _2 = 21; }                            // 40 - 49
            if (_2 == 5) { _2_s = _words[22]; _2 = 21; }                            // 50 - 59
            if ((_2 >= 6 && _2 <= 9) && _1 > 0) { _2_s = _words[_2]; _2 = 21; }     // 60 - 99
            if (_1 == 0 && _2 == 1) { _1 = 10; _2 = 0; }                            // 10
            if (_1 == 1 && _2 == 1) { _1 = 16; _2 = 0; }                            // 11
            if (_1 == 2 && _2 == 1) { _1 = 17; _2 = 0; }                            // 12
            if (_1 == 3 && _2 == 1) { _1 = 20; _2 = 19; }                           // 13
            if ((_1 >= 4 && _1 <= 9) && _2 == 1) { _2 = _1; _1 = 20; }              // 14 - 19

            _1_s += _1 > 0 ? (_2_s.Length > 0 ? " " : "") + _words[_1] : "";
            _2_s += _2 > 0 ? _words[_2] : "";
            _3_s += _3 > 0 ? _words[_3] + " " + _words[11] + (_2 > 0 || _1 > 0 ? " " : "") : "";

            group_s = _3_s + _2_s + _1_s;

            return group_s;
        }


        private void Initialize()
        {
            var left = (ulong)_d;

            var right = Convert.ToInt32(_d % 1 * 100);

            var dollars = CreateString(left) + " " + _words[23] + (left == 1 ? "" : "s");

            var cents = CreateString((ulong)right);

            cents = cents.Replace(" ", "-");

            var cents_s = " and " + cents + " " + _words[24] + (right == 1 ? "" : "s");

            _result = dollars + cents_s;

        }

    }
}
