using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    [Serializable]
    class Answer
    {
        public string Text { get; set; }
        public bool IsTrue  { get; set; }

        public override string ToString()
        {
            return $"{Text}\t{IsTrue}";
        }
    }
}
